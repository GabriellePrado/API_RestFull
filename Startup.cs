
using API_RestFull.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using API_RestFull.Repository.Generic;
using API_RestFull.DB;
using API_RestFull.Service;
using System.Net.Http.Headers;
using Microsoft.Data.SqlClient;
using System.Net;
using API_RestFull.Hypermedia.Filters;
using API_RestFull.Hypermedia.Enricher;

namespace API_RestFull
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_RestFull", Version = "v1" });
            });

            //var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            //services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));


            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ConexaoSql>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });



            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connectionString);
            }

            services.AddMvc
                (options =>
                {
                    //a aplicação irá respeitar o cabeçalho 'Accept' enviado pelo navegador com base em suas preferencias, se xml ou json.
                    options.RespectBrowserAcceptHeader = true;

                    //Se for solicitado externamente que nossa API retorne um XML ou Json o código abaixo faz esse retorno.
                    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
                }).AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new ProdutoEnricher());
            filterOptions.ContentResponseEnricherList.Add(new SacolaEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ClienteEnricher());

            services.AddSingleton(filterOptions);

            //Versionamento da API
            services.AddApiVersioning();

            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_RestFull v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultAPI", "{controller=values}/{id?}");
            });
        }
        private void MigrateDatabase(string connection)
        {
            try
            {
                // Ignorar a validação do certificado SSL
                //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                ServicePointManager.ServerCertificateValidationCallback = null;

                //cria a conexão
                var evolveConnection = new SqlConnection(connection);
                //inicializa o evolve
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "DB/migration", "DB/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
    }
}
