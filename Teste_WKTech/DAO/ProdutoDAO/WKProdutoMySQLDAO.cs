using System;
using Teste_WKTech.Models;
using MySql.Data.MySqlClient;

namespace Teste_WKTech.DAO.ProdutoDAO
{
    public class WKProdutoMySQLDAO : IWKProdutoDAO
    {
        public List<WKProduto> GetWKProdutos(String search = "")
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
                    sql = "SELECT * FROM WKBD.tb_produto LIMIT 100;";
                }
                else
                {
                    sql = "SELECT * FROM WKBD.tb_produto WHERE nome LIKE '%" + search + "%' LIMIT 100;";
                }

                MySqlCommand command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();

                List<WKProduto> toRtn = new List<WKProduto>();
                while (reader.Read())
                {
                    WKProduto produto = new WKProduto();
                    produto.id = Int64.Parse(reader["id"].ToString());
                    produto.nome = reader["nome"].ToString();
                    produto.quantidade = Int64.Parse(reader["quantidade"].ToString());

                    toRtn.Add(produto);
                }

                return toRtn;
            }
            catch(Exception e)
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

        public WKProduto InsertWKProduto(WKProduto produto)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "INSERT INTO WKBD.tb_produto (nome, quantidade) VALUES (@nome, @quantidade);SELECT LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(sql, conn, transaction);
                command.Parameters.Add(new MySqlParameter("nome", produto.nome));
                command.Parameters.Add(new MySqlParameter("quantidade", produto.quantidade));
                produto.id = Convert.ToInt64(command.ExecuteScalar());

                transaction.Commit();

                return produto;
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

        public Boolean RemoveWKProduto(Int64 id)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "DELETE FROM WKBD.tb_produto WHERE id = @id;";
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

        public Boolean UpdateWKProduto(WKProduto produto)
        {
            MySqlConnection? conn = null;
            MySqlDataReader? reader = null;
            MySqlTransaction? transaction = null;
            try
            {
                conn = new MySqlConnection(UtilDAO.strConnectionMySQL);
                conn.Open();
                transaction = conn.BeginTransaction();
                String sql = "UPDATE WKBD.tb_produto SET nome=@nome, quantidade=@quantidade WHERE id = @id;";
                MySqlCommand command = new MySqlCommand(sql, conn, transaction);
                command.Parameters.Add(new MySqlParameter("id", produto.id));
                command.Parameters.Add(new MySqlParameter("nome", produto.nome));
                command.Parameters.Add(new MySqlParameter("quantidade", produto.quantidade));
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
    }
}

