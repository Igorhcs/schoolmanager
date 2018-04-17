using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conneciton
/// </summary>
public class Connection
{
        #region Construtor
        public Connection()
        {
            //
            // TODO: Add constructor logic here
            //
            // abrirConexao();
        }
        #endregion



        #region Metodos
        public SqlConnection conexao()
        {
            SqlConnection cn = null;
            string conect = "Data Source=ISAQUE-PC\\SQLEXPRESS;Initial Catalog=SchoolManager;Integrated Security=True";
			//string conect = "Data Source=D6203NE829\\MSSQLSERVER2;Initial Catalog=SchoolManager;User Id=sa;Password=ctecnico";
            //string conect = "Data Source=POWERCAETANO;Initial Catalog=ProjetoFB;User Id=Alex;Password=alex1313";
            //string conect = "Data Source=POWERCAETANO\\SQLEXPRESS;Initial Catalog=mercearia;Integrated Security=True";
            try
            {
                cn = new SqlConnection(conect);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao conectar no SQL SERVER " + ex);
            }


            return cn;
        }

        public SqlConnection abrirConexao()
        {
            SqlConnection cn = conexao();

            try
            {
                cn.Open();
                Console.WriteLine("Conexao aberta///////////////////////");
                return cn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Conexao com falha///////////////////////");
                throw e;
            }


        }

        public void fecharConexao(SqlConnection cn)
        {
            try
            {
                cn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao fechar conexao///////////////////////");
                throw e;
            }
        }

        #endregion
    }
