using System;
namespace Teste_WKTech.Models
{
    public class WKCategoria
    {
        public WKCategoria()
        {
            this.listaProduto = new List<WKProduto>();
        }

        public Int64 id { get; set; }
        public String nome { get; set; }
        public List<WKProduto> listaProduto { get; set; }
    }
}

