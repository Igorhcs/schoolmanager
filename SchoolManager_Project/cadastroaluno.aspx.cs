using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cadastroaluno : System.Web.UI.Page
{
    webService.WSControlSoapClient ws = new webService.WSControlSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logado"] == null)
        {
            Session["msg"] = "Sem permissão de acesso!";
            Response.Redirect("loginescola.aspx");
        }
        else
        {
            if (Session["logado"].ToString() != "OK")
            {
                Session["msg"] = "Sem permissão de acesso!";
                Response.Redirect("loginescola.aspx");
            }
        }
        fillGrid();
        String msg = "";
        if (Session["msg"] != null)
        {
            if (Session["msg"].ToString() != "")
            {
                msg = Session["msg"].ToString();
                bv.Text = msg;
                Session["msg"] = "";
            }
        }
    }
    protected void enviar_Click(object sender, EventArgs e)
    {

        Utils utils = new Utils();

        String rel = "";
        String json = "";
        BeanAluno ba = new BeanAluno();
        BeanTurma bt = new BeanTurma();
        BeanResponsavel br = new BeanResponsavel();
        if (id.Text == "")
            {
               
                    ba.Nome_aluno = tb_nome.Text;
                    ba.Dt_nasc = DateTime.Parse(tb_datanasc.Text);
                    bt.Nome_turma = tb_turma.Text;
                    ba.Turma = bt;
                    br.Idresponsavel = int.Parse(tb_responsavel.Text);
                    ba.Responsavel = br;
                    /*nome_aluno = tb_nome.Text,
                    dt_nasc = tb_datanasc.Text,
                    turma_fk = tb_turma.Text,
                    responsavel_fk = tb_responsavel.Text*/


                json = new JavaScriptSerializer().Serialize(ba);
                rel = ws.alunoIn(json);
                if (rel.Equals("\"0\""))
                {

                    Session["msg"] = "Problema ao inserir aluno";
                    Response.Redirect("cadastroaluno.aspx");
                }
                else if (rel.Equals("\"1\""))
                {

                    Session["msg"] = "Aluno inserido com sucesso!";
                    Response.Redirect("cadastroaluno.aspx");
                }
                else if (rel.Equals("\"2\""))
                {

                    Session["msg"] = "Aluno já cadastrado no sistema!";
                    Response.Redirect("cadastroaluno.aspx");
                }
            }
            else
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    idaluno = id.Text,
                    nome_aluno = tb_nome.Text,
                    dt_nasc = tb_datanasc.Text,
                    turma_fk = tb_turma.Text,
                    responsavel_fk = tb_responsavel.Text
                });
                rel = ws.alunoDel(json);
                Debug.WriteLine("Valor do retorno: " + rel);
                if (rel == "0")
                {
                    Session["msg"] = "Problemas ao atualizar aluno";
                    Response.Redirect("painelescola.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Aluno atualizado com sucesso!";
                    Response.Redirect("painelescola.aspx");
                }
                else if (rel == "2")
                {
                    Session["msg"] = "Aluno já cadastrado no sistema!";
                    Response.Redirect("painelescola.aspx");
                }
            }
        
    }
    protected void listaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
    {
        bv.Text = "";
        //listaUsuarios.EditIndex = e.NewEditIndex;
        Debug.WriteLine("RowEditing chamado");
        int i = e.NewEditIndex;
        Debug.WriteLine("Indice da Linha: " + i);

        String idaluno = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        String nome_aluno = ((Label)listaUsuarios.Rows[i].FindControl("Lnome")).Text;
        String dt_nasc = ((Label)listaUsuarios.Rows[i].FindControl("Ldtnasc")).Text;
        String turma_fk = ((Label)listaUsuarios.Rows[i].FindControl("Lturma")).Text;
        String responsavel_fk = ((Label)listaUsuarios.Rows[i].FindControl("Lresponsavel")).Text;

        id.Text = idaluno;
        tb_nome.Text = nome_aluno;
        tb_datanasc.Text = dt_nasc;
        tb_turma.Text = turma_fk;
        tb_responsavel.Text = responsavel_fk;
    }
    protected void listaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        listaUsuarios.EditIndex = -1;
        Debug.WriteLine("RowCancelingEdit chamado");
        tb_responsavel.Text = "";
        tb_turma.Text = "";
        id.Text = "";
        tb_nome.Text = "";
        tb_nome.Focus();
        fillGrid();
    }
    protected void listaUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Debug.WriteLine("RowUpdating chamado");

    }
    protected void fillGrid()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<BeanAluno> list = new List<BeanAluno>();


        //1ª FORMA DE PREENCHER O GRID
        list = serializer.Deserialize<List<BeanAluno>>(ws.alunoAll());

        listaUsuarios.DataSource = null;
        listaUsuarios.DataSource = list;
        listaUsuarios.DataBind();
    }

    protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        String idaluno = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        Debug.WriteLine("RowDeleting chamado Indice da Linha: " + i + "ID:" + idaluno);
        BeanAluno u = new BeanAluno();
        u.Idaluno = int.Parse(idaluno);
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String result = ws.alunoDel(serializer.Serialize(u));
        if (result == "0")
        {
            Session["msg"] = "Aluno não foi excluido!";
            Response.Redirect("cadastroaluno.aspx");
        }
        else
        {
            Session["msg"] = "Aluno excluído com sucesso!";
            Response.Redirect("cadastroaluno.aspx");
        }
    }
}