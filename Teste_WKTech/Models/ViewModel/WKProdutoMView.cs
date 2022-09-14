using System;
namespace Teste_WKTech.Models.ViewModel
{
    public class WKProdutoMView
    {
        public List<WKProduto> listaProduto { get; set; }

        public WKProdutoMView()
        {
            listaProduto = new List<WKProduto>();
        }

    }
}

