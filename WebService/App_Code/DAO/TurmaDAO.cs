using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TurmaDAO
/// </summary>
public class TurmaDAO
{
    #region Variaveis
        BeanTurma adm = new BeanTurma();
        System.Data.SqlClient.SqlConnection conn;
    #endregion
	public TurmaDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Metodos
    public int insertUsuario(BeanTurma tu)
    {
        int i = 0;
        String sql = "INSERT INTO SchoolManager.dbo.turmas(nome_turma) VALUES(@nome);";
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@nome", tu.Nome_turma);
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
    public int deleteUsuario(BeanTurma tu)
    {
        String sql = "DELETE FROM SchoolManager.dbo.turmas WHERE nome_turma = @pid";
        SqlConnection conn;
        int i = 0;
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@pid", tu.Nome_turma);
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
    public int updateUsuario(BeanTurma tu, String tuA)//perguntar pro professor esse metodo
    {
        String sql = "UPDATE SchoolManager.dbo.turmas SET nome_turma = @nome "
        + " WHERE nome_turma= @turmaA ;";

        int i = 0;
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@nome", tu.Nome_turma);
                command.Parameters.AddWithValue("@turmaA", tuA);
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
    public List<BeanTurma> selectAll()
    {
        List<BeanTurma> list = new List<BeanTurma>();
        String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.turmas ORDER BY nome_turma DESC";
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
                            BeanTurma tu = new BeanTurma();
                            tu.Nome_turma = objDataReader["nome_turma"].ToString();
                            list.Add(tu);
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