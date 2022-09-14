using System;
using Teste_WKTech.Models;

namespace Teste_WKTech.Business
{
    public class WKProdutoBusiness
    {
        private DAO.ProdutoDAO.IWKProdutoDAO produtoDAO;
        public WKProdutoBusiness()
        {
            this.produtoDAO = new DAO.ProdutoDAO.WKProdutoMySQLDAO();
        }

        public List<WKProduto> GetWKProdutos(String search = "")
        {
            return produtoDAO.GetWKProdutos(search);
        }

        public Boolean InsertWKProduto(WKProduto produto)
        {
            try
            {
                Facade.WKFachada.GetInstance().GetWKProdutos().Add(produtoDAO.InsertWKProduto(produto));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Boolean RemoveWKProduto(Int64 id)
        {
            return produtoDAO.RemoveWKProduto(id);
        }

        public Boolean UpdateWKProduto(WKProduto produto)
        {
            try
            {
                return produtoDAO.UpdateWKProduto(produto);
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}

