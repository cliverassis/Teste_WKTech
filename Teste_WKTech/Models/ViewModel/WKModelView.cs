using System;
namespace Teste_WKTech.Models.ViewModel
{
    public class WKModelView
    {
        public WKModelView()
        {
            listaProduto = new List<WKProduto>();
            listaCategoria = new List<WKCategoria>();
        }

        public List<WKCategoria> listaCategoria { get; set; }
        public List<WKProduto> listaProduto { get; set; }
    }
}

