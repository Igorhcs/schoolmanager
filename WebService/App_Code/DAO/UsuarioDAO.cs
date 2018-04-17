using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioDAO
/// </summary>
public class UsuarioDAO
{
    #region Variaveis
      
        BeanEscola u = new BeanEscola();
        System.Data.SqlClient.SqlConnection conn;
        #endregion

        #region Construtores
        public UsuarioDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion
        #region Metodos
        public int insertUsuario(BeanEscola u)
        {
            int i = 0;
            String sql = "INSERT INTO SchoolManager.dbo.cadescola(email,senha) VALUES(@email,@senha);";
            using (conn = new Connection().abrirConexao())
            {
                if(this.searchEmail(u.Email)){
                    return 2;
                }
                
                
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@email", u.Email);
                    command.Parameters.AddWithValue("@senha", u.Senha);
                   
                    try
                    {
                        i = command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Falha ao inserir usuario dados: " + e);
                    }
                }
            }
            return i;
        }
        public int deleteUsuario(BeanEscola u)
        {

            String sql = "DELETE FROM SchoolManager.dbo.cadescola WHERE cnpj = @pid";
            SqlConnection conn;
            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@pid", u.Cnpj);
                    try
                    {
                        i = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Falha ao deletar usuario: " + e);
                    }
                    conn.Close();
                }
            }
            return i;
        }
        public int updateUsuario(BeanEscola u)
        {
            String sql = "UPDATE SchoolManager.dbo.cadescola SET email = @email, senha = @senha"
            + "  WHERE cnpj= @id ;";

            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                if (this.searchEmailId(u.Email).ToString() != u.Cnpj.ToString())
                {                   
                    return 2;
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@senha", u.Senha);
                        command.Parameters.AddWithValue("@email", u.Email);
                        command.Parameters.AddWithValue("@id", u.Cnpj);
                        try
                        {                           
                            i = command.ExecuteNonQuery();
                            return i;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("Falha ao atualizar usuarios dados: " + e);
                            return i;
                        }

                    }
                }               
            }
        }
        public List<BeanEscola> selectAll()
        {
            List<BeanEscola> list = new List<BeanEscola>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.cadescola ORDER BY cnpj DESC";
            SqlConnection conn;
           // BeanUsuario usu = new BeanUsuario();

            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                BeanEscola usu = new BeanEscola();
                                usu.Cnpj = objDataReader["cnpj"].ToString();
                                usu.Email = objDataReader["email"].ToString();
                                usu.Senha = objDataReader["senha"].ToString();
                                
                                
                                list.Add(usu);
                            }                           
                            objDataReader.Close();
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Erros ao selecionar todos usuarios: " + e);
                    }
                }
            }
            return list;
        }
        public Boolean login(String email, String senha)
        {
           
            String sql = "SELECT * FROM SchoolManager.dbo.cadescola WHERE email = @email AND senha = @senha";
            SqlConnection conn;
            Boolean r = false;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@senha", senha);
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            r = true;
                            objDataReader.Close();
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Erros ao fazer login: " + e);
                    }
                }
            }
            return r;
        }
        public Boolean searchEmail(String email)
        {

            String sql = "SELECT * FROM SchoolManager.dbo.cadescola WHERE email = @email";
            SqlConnection conn;
            Boolean r = false;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@email", email);
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            r = true;
                            objDataReader.Close();
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Erros ao verificar email: " + e);
                    }
                }
            }
            return r;
        }
        public int searchEmailId(String email)
        {
            Debug.WriteLine("MetodoSearch: : " + email);
            String sql = "SELECT * FROM SchoolManager.dbo.cadescola WHERE email = @email";
            SqlConnection conn;
            int r = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@email", email);
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                Debug.WriteLine("Metodo: ID: - " + objDataReader["cnpj"]);
                                r = Convert.ToInt32(objDataReader["cnpj"].ToString());
                                objDataReader.Close();
                                return r;
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Erros ao verificar email: " + e);
                    }
                }
            }
            return r;
        }
        #endregion
}