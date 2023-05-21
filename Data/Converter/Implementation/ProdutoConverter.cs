using API_RestFull.Data.Converter.Contract;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace API_RestFull.Data.Converter.Implementation
{
    public class ProdutoConverter : IParse<ProdutoVO, Produto>, IParse<Produto, ProdutoVO>
    {
        public int Id { get; private set; }

        public Produto Parse(ProdutoVO origem)
        {
            if (origem == null) return null;
            return new Produto
            {
                Id = origem.Id,
                Nome = origem.Nome,
                Descricao = origem.Descricao,
                Valor = origem.Valor,
                TipoProduto = origem.TipoProduto
            };
        }

        public ProdutoVO Parse(Produto origem)
        {
            if (origem == null) return null;
            return new ProdutoVO
            {
                Id = origem.Id,
                Nome = origem.Nome,
                Descricao = origem.Descricao,
                Valor = origem.Valor,
                TipoProduto = origem.TipoProduto
            };
        }
        public List<Produto> Parse(List<ProdutoVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<ProdutoVO> Parse(List<Produto> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
