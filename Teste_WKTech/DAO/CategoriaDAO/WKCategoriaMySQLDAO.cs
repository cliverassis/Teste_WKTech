using System;
using MySql.Data.MySqlClient;
using Teste_WKTech.Models;

namespace Teste_WKTech.DAO.CategoriaDAO
{
    public class WKCategoriaMySQLDAO : IWKCategoriaDAO
    {
        public List<WKCategoria> GetWKCategoria(String search = "")
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                String sql;

                if (search != null && search.Count() == 0)
                {
                    sql = "SELECT * FROM WKBD.tb_categoria LIMIT 100;";
                }
                else
                {
                    sql = "SELECT * FROM WKBD.tb_categoria WHERE nome LIKE '%" + search + "%' LIMIT 100;";
                }

                MySqlCommand command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();

                List<WKCategoria> toRtn = new List<WKCategoria>();
                while (reader.Read())
                {
                    WKCategoria categoria = new WKCategoria();
                    categoria.id = Int64.Parse(reader["id"].ToString());
                    categoria.nome = reader["nome"].ToString();

                    toRtn.Add(categoria);
                }
                reader.Close();

                foreach (WKCategoria categoria in toRtn)
                {
                    sql = "SELECT prod.id, prod.nome FROM WKBD.tb_produto as prod INNER JOIN WKBD.tb_lig_prod_cat as lig ON lig.id_produto = prod.id WHERE id_categoria = @idCat;";
                    command = new MySqlCommand(sql, conn);
                    command.Parameters.Add(new MySqlParameter("idCat", categoria.id));
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        WKProduto produto = new WKProduto();
                        produto.id = Int64.Parse(reader["id"].ToString());
                        produto.nome = reader["nome"].ToString();

                        categoria.listaProduto.Add(produto);
                    }

                    reader.Close();
                }

                return toRtn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro - " + e.Message);

                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();

                if (reader != null)
                    reader.Close();
            }
        }

        public WKCategoria InsertWKCategoria(WKCategoria categoria)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "INSERT INTO WKBD.tb_categoria (nome) VALUES (@nome);SELECT LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(sql, conn, transaction);
                command.Parameters.Add(new MySqlParameter("nome", categoria.nome));
                categoria.id = Convert.ToInt64(command.ExecuteScalar());

                foreach (WKProduto produto in categoria.listaProduto)
                {
                    sql = "INSERT INTO WKBD.tb_lig_prod_cat (id_produto, id_categoria) VALUES (@id_prod, @id_cat);";
                    command = new MySqlCommand(sql, conn, transaction);
                    command.Parameters.Add(new MySqlParameter("id_prod", produto.id));
                    command.Parameters.Add(new MySqlParameter("id_cat", categoria.id));

                    command.ExecuteNonQuery();
                }

                transaction.Commit();

                return categoria;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro - " + e.Message);

                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();

                if (reader != null)
                    reader.Close();
            }
        }

        public Boolean RemoveWKCategoria(Int64 id)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "DELETE FROM WKBD.tb_categoria WHERE id = @id;";
                MySqlCommand command = new MySqlCommand(sql, conn, transaction);
                command.Parameters.Add(new MySqlParameter("id", id));

                command.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro - " + e.Message);

                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();

                if (reader != null)
                    reader.Close();
            }
        }

        public Boolean UpdateWKCategoria(WKCategoria categoria)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "UPDATE WKBD.tb_categoria SET nome=@nome WHERE id = @id;";
                MySqlCommand command = new MySqlCommand(sql, conn, transaction);
                command.Parameters.Add(new MySqlParameter("id", categoria.id));
                command.Parameters.Add(new MySqlParameter("nome", categoria.nome));
                command.ExecuteNonQuery();

                foreach (WKProduto produto in categoria.listaProduto)
                {
                    sql = "DELETE FROM WKBD.tb_lig_prod_cat WHERE id_categoria = @id_cat; INSERT INTO WKBD.tb_lig_prod_cat (id_produto, id_categoria) VALUES (@id_prod, @id_cat);";
                    command = new MySqlCommand(sql, conn, transaction);
                    command.Parameters.Add(new MySqlParameter("id_prod", produto.id));
                    command.Parameters.Add(new MySqlParameter("id_cat", categoria.id));

                    command.ExecuteNonQuery();
                }

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro - " + e.Message);

                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                if (conn != null)
                    conn.Close();

                if (reader != null)
                    reader.Close();
            }
        }
    }
}

