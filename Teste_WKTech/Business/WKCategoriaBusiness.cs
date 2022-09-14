using System;
using Teste_WKTech.Models;

namespace Teste_WKTech.Business
{
    public class WKCategoriaBusiness
    {
        private DAO.CategoriaDAO.IWKCategoriaDAO categoriaDAO;

        public WKCategoriaBusiness()
        {
            categoriaDAO = new DAO.CategoriaDAO.WKCategoriaMySQLDAO();
        }

        public List<WKCategoria> GetWKCategoria(String search = "")
        {
            return categoriaDAO.GetWKCategoria(search);
        }

        public Boolean InsertWKCategoria(WKCategoria categoria)
        {
            try
            {
                Facade.WKFachada.GetInstance().GetWKCategoria().Add(categoriaDAO.InsertWKCategoria(categoria));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public Boolean RemoveWKCategoria(Int64 id)
        {
            return categoriaDAO.RemoveWKCategoria(id);
        }

        public Boolean UpdateWKCategoria(WKCategoria categoria)
        {
            try
            {
                return categoriaDAO.UpdateWKCategoria(categoria);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

