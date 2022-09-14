using System;
using Teste_WKTech.Business;
using Teste_WKTech.Models;

namespace Teste_WKTech.Facade
{
    public class WKFachada
    {
        private WKCategoriaBusiness _categoriaBus;
        private WKProdutoBusiness _produtoBus;
        static public WKFachada? _instance = null;

        static public WKFachada GetInstance()
        {
            if (_instance != null)
                return _instance;

            _instance = new WKFachada();

            return _instance;
        }

        private WKFachada()
        {
            _categoriaBus = new WKCategoriaBusiness();
            _produtoBus = new WKProdutoBusiness();
        }

        #region Métodos referentes a classe WKProduto
        public List<WKProduto> GetWKProdutos(String search = "")
        {
            return _produtoBus.GetWKProdutos(search);
        }

        public Boolean InsertWKProduto(WKProduto produto)
        {
            return _produtoBus.InsertWKProduto(produto);
        }

        public Boolean RemoveWKProduto(Int64 id)
        {
            return _produtoBus.RemoveWKProduto(id);
        }

        public Boolean UpdateWKProduto(WKProduto produto)
        {
            return _produtoBus.UpdateWKProduto(produto);
        }
        #endregion

        #region Métodos referentes a classe WKCategoria
        public List<WKCategoria> GetWKCategoria(String search = "")
        {
            return _categoriaBus.GetWKCategoria(search);
        }

        public Boolean InsertWKCategoria(WKCategoria _categoria)
        {
            return _categoriaBus.InsertWKCategoria(_categoria);
        }

        public Boolean RemoveWKCategoria(Int64 id)
        {
            return _categoriaBus.RemoveWKCategoria(id);
        }

        public Boolean UpdateWKCategoria(WKCategoria _categoria)
        {
            return _categoriaBus.UpdateWKCategoria(_categoria);
        }
        #endregion
    }
}