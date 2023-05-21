using API_RestFull.Data.Converter.Contract;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Data.Converter.Implementation
{
    public class ClienteConverter : IParse<ClienteVO, Cliente>, IParse<Cliente, ClienteVO>
    {
        public int Id { get; private set; }

        public Cliente Parse(ClienteVO origem)
        {
            if (origem == null) return null;
            return new Cliente {
                Id = origem.Id,
                Cpf = origem.Cpf,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Email = origem.Email
            };
        }

        public ClienteVO Parse(Cliente origem)
        {
            if (origem == null) return null;
            return new ClienteVO
            {
                Id = origem.Id,
                Cpf = origem.Cpf,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Email = origem.Email
            };
        }
        public List<Cliente> Parse(List<ClienteVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<ClienteVO> Parse(List<Cliente> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
