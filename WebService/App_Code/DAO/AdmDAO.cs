using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdmDAO
/// </summary>
public class AdmDAO
{
   //local onde declaramos todas a s variaveis
    #region Variaveis
        BeanADM adm = new BeanADM();
        System.Data.SqlClient.SqlConnection conn;
    #endregion

	//metodo construtor vazio
    public AdmDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Metodos
        public int insertADM(BeanADM adm)
        {
            int i = 0;
            String sql = "INSERT INTO SchoolManager.dbo.adm(nome,login,senha,status) VALUES(@nome,@login,@senha,@status);";
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome", adm.Nome);
                    command.Parameters.AddWithValue("@login", adm.Login);
                    command.Parameters.AddWithValue("@senha", adm.Senha);
                    command.Parameters.AddWithValue("@status", adm.Status);

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
        public int deleteADM(BeanADM adm)
        {
            String sql = "DELETE FROM SchoolManager.dbo.adm WHERE idadm = @pid";
            SqlConnection conn;
            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@pid",adm.Idadm);
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
        public int updateADM(BeanADM adm)
        {
            String sql = "UPDATE SchoolManager.dbo.adm SET nome = @nome, login = @login, senha = @senha, status = @status "
            +" WHERE idadm= @id ;";

            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome", adm.Nome);
                    command.Parameters.AddWithValue("@login", adm.Login);
                    command.Parameters.AddWithValue("@senha", adm.Senha);
                    command.Parameters.AddWithValue("@status", adm.Status);
                    command.Parameters.AddWithValue("@id", adm.Idadm);
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
        public List<BeanADM> selectAllADM()
        {
            List<BeanADM> list = new List<BeanADM>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.adm ORDER BY idadm DESC";
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
                                BeanADM adm = new BeanADM();
                                adm.Idadm = int.Parse(objDataReader["idadm"].ToString());
                                adm.Nome = objDataReader["nome"].ToString();
                                adm.Login = objDataReader["login"].ToString();
                                adm.Senha = objDataReader["senha"].ToString();
                                adm.Status = Convert.ToBoolean(objDataReader["status"]);
                                list.Add(adm);
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
        public List<BeanADM> selectIDADM(BeanADM a)
        {
            List<BeanADM> list = new List<BeanADM>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.adm WHERE idadm = @id";
            SqlConnection conn;
            // BeanUsuario usu = new BeanUsuario();

            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@id", a.Idadm);
                    try
                    {
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                BeanADM adm = new BeanADM();
                                adm.Idadm = int.Parse(objDataReader["idadm"].ToString());
                                adm.Nome = objDataReader["nome"].ToString();
                                adm.Login = objDataReader["login"].ToString();
                                adm.Senha = objDataReader["senha"].ToString();
                                adm.Status = Convert.ToBoolean(objDataReader["status"]);
                                list.Add(adm);
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
        public Boolean loginADM(String login, String senha)
        {

            String sql = "SELECT * FROM SchoolManager.dbo.adm WHERE login = @login AND senha = @senha";
            SqlConnection conn;
            Boolean r = false;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@login", login);
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
        public Boolean searchEmailADM(String email)
        {

            String sql = "SELECT * FROM SchoolManager.dbo.adm WHERE login = @email";
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