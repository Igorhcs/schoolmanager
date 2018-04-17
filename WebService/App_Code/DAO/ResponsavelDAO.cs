using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResponsavelDAO
/// </summary>
public class ResponsavelDAO
{
    #region Variaveis
        BeanResponsavel re = new BeanResponsavel();
        System.Data.SqlClient.SqlConnection conn;
    #endregion
	public ResponsavelDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Metodos
    public int insertUsuario(BeanResponsavel re)
    {
        int i = 0;
        String sql = "INSERT INTO SchoolManager.dbo.responsavel(nome_responsavel,login,senha) VALUES(@nome,@login,@senha);";
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@nome", re.Nome_responsavel);
                command.Parameters.AddWithValue("@login", re.Login);
                command.Parameters.AddWithValue("@senha", re.Senha);

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
    public int deleteUsuario(BeanResponsavel re)
    {
        String sql = "DELETE FROM SchoolManager.dbo.responsavel WHERE idresponsavel = @pid";
        SqlConnection conn;
        int i = 0;
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@pid", re.Idresponsavel);
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
    public int updateUsuario(BeanResponsavel re)
    {
        String sql = "UPDATE SchoolManager.dbo.responsavel SET nome_responsavel = @nome, login = @login, senha = @senha "
        + " WHERE idresponsavel= @id ;";

        int i = 0;
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@nome", re.Nome_responsavel);
                command.Parameters.AddWithValue("@login", re.Login);
                command.Parameters.AddWithValue("@senha", re.Senha);
                command.Parameters.AddWithValue("@id", re.Idresponsavel);
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
    public List<BeanResponsavel> selectAll()
    {
        List<BeanResponsavel> list = new List<BeanResponsavel>();
        String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.responsavel ORDER BY idresponsavel DESC";
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
                            BeanResponsavel re = new BeanResponsavel();
                            re.Idresponsavel = int.Parse(objDataReader["idresponsavel"].ToString());
                            re.Nome_responsavel = objDataReader["nome_responsavel"].ToString();
                            re.Login = objDataReader["login"].ToString();
                            re.Senha = objDataReader["senha"].ToString();
                            list.Add(re);
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
    #endregion
}