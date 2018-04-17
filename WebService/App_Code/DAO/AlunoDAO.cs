using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AlunoDAO
/// </summary>
public class AlunoDAO
{
	//local onde declaramos todas a s variaveis
    #region Variaveis
        BeanAluno adm = new BeanAluno();
        System.Data.SqlClient.SqlConnection conn;
    #endregion

	//metodo construtor vazio
    public AlunoDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Metodos
        public int insertUsuario(BeanAluno al)
        {
           
            int i = 0;
            String sql = "INSERT INTO SchoolManager.dbo.cadaluno(nome_aluno,dt_nasc,turma_fk,responsavel_fk) VALUES(@nome_aluno,@dt_nasc,@turma_fk,@responsavel_fk);";
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome_aluno", al.Nome_aluno);
                    command.Parameters.AddWithValue("@dt_nasc", al.Dt_nasc);
                    command.Parameters.AddWithValue("@turma_fk", al.Turma.Nome_turma);
                    //command.Parameters.AddWithValue("@cadescola_fk", al.Escola.Cnpj);
                    command.Parameters.AddWithValue("@responsavel_fk", al.Responsavel.Idresponsavel);


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
        public int deleteUsuario(BeanAluno al)
        {
            String sql = "DELETE FROM SchoolManager.dbo.cadaluno WHERE idaluno = @pid";
            SqlConnection conn;
            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@pid",al.Idaluno);
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
        public int updateUsuario(BeanAluno al)
        {
            String sql = "UPDATE SchoolManager.dbo.cadaluno SET nome_aluno = @nome_aluno, dt_nasc = @dt_nasc, turma_fk = @turma_fk, cadescola_fk = @cadescola_fk "
            +" WHERE idaluno= @id ;";

            int i = 0;
            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@nome_aluno", al.Nome_aluno);
                    command.Parameters.AddWithValue("@dt_nasc", al.Dt_nasc);
                    command.Parameters.AddWithValue("@turma_fk", al.Turma.Nome_turma);
                    command.Parameters.AddWithValue("@cadescola_fk", al.Escola.Cnpj);
                    command.Parameters.AddWithValue("@id", al.Idaluno);
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
        public List<BeanAluno> selectAll()
        {
            List<BeanAluno> list = new List<BeanAluno>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.cadaluno ca,SchoolManager.dbo.responsavel res, "
            + " SchoolManager.dbo.turmas tu WHERE ca.responsavel_fk = res.idresponsavel AND ca.turma_fk = tu.nome_turma "
            +" ORDER BY ca.idaluno DESC";
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
                                BeanAluno al = new BeanAluno();
                                BeanEscola esc = new BeanEscola();
                                BeanResponsavel res = new BeanResponsavel();
                                BeanTurma tu = new BeanTurma();
                                al.Idaluno = int.Parse(objDataReader["idaluno"].ToString());
                                al.Nome_aluno = objDataReader["nome_aluno"].ToString();
                                al.Dt_nasc = Convert.ToDateTime(objDataReader["dt_nasc"].ToString());
                               
                                tu.Nome_turma = objDataReader["turma_fk"].ToString();
                               
                                al.Turma = tu;

                                /*esc.Cnpj = objDataReader["cadescola_fk"].ToString();
                                esc.Nome_escola = objDataReader["nome_escola"].ToString();
                                esc.Email = objDataReader["email"].ToString();
                                al.Escola = esc;*/
                                res.Idresponsavel = int.Parse(objDataReader["responsavel_fk"].ToString());
                                res.Nome_responsavel = objDataReader["nome_responsavel"].ToString();
                                al.Responsavel = res;
                     
                                list.Add(al);
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
        public List<BeanAluno> selectID(BeanAluno al)
        {
            List<BeanAluno> list = new List<BeanAluno>();
            String sql = "SELECT DISTINCT * FROM SchoolManager.dbo.cadaluno WHERE idaluno = @id";
            SqlConnection conn;
            // BeanUsuario usu = new BeanUsuario();

            using (conn = new Connection().abrirConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@id", al.Idaluno);
                    try
                    {
                        SqlDataReader objDataReader = command.ExecuteReader();
                        if (objDataReader.HasRows)
                        {
                            while (objDataReader.Read())
                            {
                                BeanAluno a = new BeanAluno();
                                BeanEscola esc = new BeanEscola();
                                BeanResponsavel res = new BeanResponsavel();
                                BeanTurma tu = new BeanTurma();
                                a.Idaluno = int.Parse(objDataReader["idaluno"].ToString());
                                a.Nome_aluno = objDataReader["nome_aluno"].ToString();
                                a.Dt_nasc = Convert.ToDateTime(objDataReader["dt_nasc"].ToString());
                                tu.Nome_turma = objDataReader["turma_fk"].ToString();
                                a.Turma = tu;
                                esc.Cnpj = objDataReader["cadescola_fk"].ToString();
                                a.Escola = esc;
                                res.Idresponsavel = int.Parse(objDataReader["idresponsavel_fk"].ToString());
                                a.Responsavel = res;
                                
                                list.Add(a);
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