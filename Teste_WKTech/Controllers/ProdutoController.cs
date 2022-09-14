using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_WKTech.Models.ViewModel;
using Teste_WKTech.Models;

namespace Teste_WKTech.Controllers
{
    public class ProdutoController : Controller
    {
        public PartialViewResult Inicio()
        {
            WKProdutoMView model = new WKProdutoMView();
            model.listaProduto = Facade.WKFachada.GetInstance().GetWKProdutos();

            return PartialView(model);
        }

        public String BuscarProduto(String nome)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Facade.WKFachada.GetInstance().GetWKProdutos(nome != null ? nome : ""));
        }
        
        [HttpPost]
        public Boolean InsertWKProduto(WKProduto produto)
        {
            return Facade.WKFachada.GetInstance().InsertWKProduto(produto);
        }

        [HttpPost]
        public Boolean UpdateWKProduto(WKProduto produto)
        {
            return Facade.WKFachada.GetInstance().UpdateWKProduto(produto);
        }

        [HttpPost]
        public Boolean RemoveWKProduto(Int64 id)
        {
            return Facade.WKFachada.GetInstance().RemoveWKProduto(id);
        }
    }
}

