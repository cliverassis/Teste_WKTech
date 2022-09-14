using System;
using Teste_WKTech.Models;
namespace Teste_WKTech.DAO.ProdutoDAO
{
    public interface IWKProdutoDAO
    {
        public List<WKProduto> GetWKProdutos(String search = "");
        public WKProduto InsertWKProduto(WKProduto produto);
        public Boolean UpdateWKProduto(WKProduto produto);
        public Boolean RemoveWKProduto(Int64 id);
    }
}

