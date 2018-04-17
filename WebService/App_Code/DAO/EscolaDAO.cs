using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EscolaDAO
/// </summary>
public class EscolaDAO
{
	//local onde declaramos todas a s variaveis
    #region Variaveis
        BeanEscola adm = new BeanEscola();
        System.Data.SqlClient.SqlConnection conn;
    #endregion

	//metodo construtor vazio
    public EscolaDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Metodos
        public int insertEscola(BeanEscola esc)
        {
            int i = 0;
            String sql = "INSERT INTO SchoolManager.dbo.cadescola(nome_escola,email,cnpj,senha) VALUES(@nome_escola,@email,@cnpj,@senha);";
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome_escola", esc.Nome_escola);
                    command.Parameters.AddWithValue("@email", esc.Email);
                    command.Parameters.AddWithValue("@cnpj", esc.Cnpj);
                    command.Parameters.AddWithValue("@senha", esc.Senha);

                    try
                    {
                        i = command.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Falha ao inserir dados: " + e);
                    }
                }
            }
            return i;
        }
        public int deleteEscola(BeanEscola esc)
        {
            String sql = "DELETE FROM SchoolManager.dbo.cadescola WHERE cnpj = @pid";
            SqlConnection conn;
            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@pid",esc.Cnpj);
                    try
                    {
                        i = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Falha ao deletar dados: " + e);
                    }
                    conn.Close();
                }
            }
            return i;
        }
        public int updateEscola(BeanEscola esc)
        {
            String sql = "UPDATE SchoolManager.dbo.cadescola SET nome_escola = @nome_escola, email = @email, senha = @senha WHERE cnpj= @id ";

            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome", esc.Nome_escola);
                    command.Parameters.AddWithValue("@email", esc.Email);
                    command.Parameters.AddWithValue("@senha", esc.Senha);
                    command.Parameters.AddWithValue("@id", esc.Cnpj);
                    try
                    {
                        i = command.ExecuteNonQuery();
                        return i;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Falha ao atualizar dados: " + e);
                        return i;
                    }

                }
            }
        }
        public List<BeanEscola> escolaAll()
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
                                BeanEscola esc = new BeanEscola();
                                esc.Cnpj = objDataReader["cnpj"].ToString();
                                esc.Nome_escola = objDataReader["nome_escola"].ToString();
                                esc.Email = objDataReader["email"].ToString();
                                esc.Senha = objDataReader["senha"].ToString();
                                list.Add(esc);
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
        public List<BeanEscola> selectCNPJ(BeanEscola a)
        {
            List<BeanEscola> list = new List<BeanEscola>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.cadescola WHERE cnpj = @cnpj";
            SqlConnection conn;
            // BeanUsuario usu = new BeanUsuario();

            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@cnpj", a.Cnpj);
                    try
                    {
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                BeanEscola esc = new BeanEscola();
                                esc.Cnpj = objDataReader["cnpj"].ToString();
                                esc.Nome_escola = objDataReader["nome_escola"].ToString();
                                esc.Email = objDataReader["email"].ToString();
                                esc.Senha = objDataReader["senha"].ToString();
                                list.Add(esc);
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
        public Boolean loginEscola(String email, String senha)
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
    #endregion
}