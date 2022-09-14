using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste_WKTech.Models.ViewModel;
using Teste_WKTech.Models;

namespace Teste_WKTech.Controllers
{
    public class CategoriaController : Controller
    {
        public PartialViewResult Inicio()
        {
            WKCategoriaMView model = new WKCategoriaMView();
            model.listaCategoria = Facade.WKFachada.GetInstance().GetWKCategoria();

            return PartialView(model);
        }

        public String BuscarCategoria(String nome)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Facade.WKFachada.GetInstance().GetWKCategoria(nome != null ? nome : ""));
        }
        
        [HttpPost]
        public Boolean InsertWKCategoria(WKCategoria Categoria)
        {
            return Facade.WKFachada.GetInstance().InsertWKCategoria(Categoria);
        }

        [HttpPost]
        public Boolean UpdateWKCategoria(WKCategoria Categoria)
        {
            return Facade.WKFachada.GetInstance().UpdateWKCategoria(Categoria);
        }

        [HttpPost]
        public Boolean RemoveWKCategoria(Int64 id)
        {
            return Facade.WKFachada.GetInstance().RemoveWKCategoria(id);
        }
    }
}

