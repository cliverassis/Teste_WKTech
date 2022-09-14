using System;
using Teste_WKTech.Models;

namespace Teste_WKTech.DAO.CategoriaDAO
{
    public interface IWKCategoriaDAO
    {
        public List<WKCategoria> GetWKCategoria(String search = "");
        public WKCategoria InsertWKCategoria(WKCategoria categoria);
        public Boolean UpdateWKCategoria(WKCategoria categoria);
        public Boolean RemoveWKCategoria(Int64 id);
     
    }
}

