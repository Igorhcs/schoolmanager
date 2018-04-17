using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HistoricoDAO
/// </summary>
public class HistoricoDAO
{
    #region Variaveis
        BeanHistorico his = new BeanHistorico();
        System.Data.SqlClient.SqlConnection conn;
    #endregion

	public HistoricoDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Metodos
    public List<BeanHistorico> selectAll()
    {
        List<BeanHistorico> list = new List<BeanHistorico>();
        String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.historico ORDER BY idhistorico DESC";
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
                            BeanHistorico his = new BeanHistorico();
                            BeanAluno al = new BeanAluno();
                            his.Idhistorico = int.Parse(objDataReader["idhistorico"].ToString());
                            al.Idaluno = int.Parse(objDataReader["idaluno_fk"].ToString());
                            his.Aluno = al;
                            his.Msg = objDataReader["msg"].ToString();
                            list.Add(his);
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
    public int deleteHistorico(BeanHistorico his)
    {
        String sql = "DELETE FROM SchoolManager.dbo.adm WHERE idhistorico = @pid";
        SqlConnection conn;
        int i = 0;
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@pid", his.Idhistorico);
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

    public int insertHistorico(BeanHistorico his)
    {
        int i = 0;
        String sql = "INSERT INTO SchoolManager.dbo.historico(idaluno_fk,msg,dt_hora) VALUES(@idaluno_fk,@msg,@data);";
        using (conn = new Connection().abrirConexao())
        {
            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@idaluno_fk", his.Aluno.Idaluno);
                command.Parameters.AddWithValue("@msg", his.Msg);
                command.Parameters.AddWithValue("@data", DateTime.Now);

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
    #endregion
}