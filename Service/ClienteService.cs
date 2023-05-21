using API_RestFull.Data.Converter.Implementation;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using API_RestFull.Repository.Generic;
using API_RestFull.Service.Interface;
using System.Collections.Generic;

namespace API_RestFull.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _repository;
        private readonly ClienteConverter _converter;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
            _converter = new ClienteConverter();
        }
        public ClienteVO Create(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Create(clienteEntity);
            return _converter.Parse(clienteEntity);
        }

        public ClienteVO Update(ClienteVO cliente)
        {
            var clienteEntity = _converter.Parse(cliente);
            clienteEntity = _repository.Update(clienteEntity);
            return _converter.Parse(clienteEntity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ClienteVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());

        }
        public ClienteVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        /*public async Task<Colaborador> ExistsByCpfAsync(string colaboradorCpf)
        {
            try
            {
                string sql = $"{baseSql} AND cpf = @Cpf";

                var colaboradors = await _dbConnector.QueryAsync<Colaborador>(sql, new { Cpf = colaboradorCpf });

                return colaboradors.FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        */
    }
}
