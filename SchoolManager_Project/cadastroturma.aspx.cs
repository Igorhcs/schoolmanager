using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cadastroturma : System.Web.UI.Page
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
        
        if (id.Text == "")
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    nome_turma = tb_nome.Text,
                });
                rel = ws.turmaIn(json);
                if (rel == "0")
                {

                    Session["msg"] = "Problema ao inserir turma";
                    Response.Redirect("cadastroturma.aspx");
                }
                else if (rel == "1")
                {

                    Session["msg"] = "Turma inserida com sucesso!";
                    Response.Redirect("cadastroturma.aspx");
                }
                else if (rel == "2")
                {

                    Session["msg"] = "Turma já cadastrada no sistema!";
                    Response.Redirect("cadastroturma.aspx");
                }
                Response.Redirect("cadastroturma.aspx");
            }
            else
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    nome_turma = tb_nome.Text,
                });
                rel = ws.updateTurma(json, turmaantes);
                Debug.WriteLine("Valor do retorno: " + rel);
                if (rel == "0")
                {
                    Session["msg"] = "Problemas ao atualizar turma";
                    Response.Redirect("painelescola.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Turma atualizada com sucesso!";
                    Response.Redirect("painelescola.aspx");
                }
                else if (rel == "2")
                {
                    Session["msg"] = "Turma já cadastrada no sistema!";
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
        String nome_turma = ((Label)listaUsuarios.Rows[i].FindControl("Lturma")).Text;
  
        tb_nome.Text = nome_turma;

    }
    protected void listaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        listaUsuarios.EditIndex = -1;
        Debug.WriteLine("RowCancelingEdit chamado");
        tb_nome.Text = "";
       
        fillGrid();
    }
    protected void listaUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Debug.WriteLine("RowUpdating chamado");

    }
    protected void fillGrid()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<BeanTurma> list = new List<BeanTurma>();


        //1ª FORMA DE PREENCHER O GRID
        list = serializer.Deserialize<List<BeanTurma>>(ws.turmaAll());

        listaUsuarios.DataSource = null;
        listaUsuarios.DataSource = list;
        listaUsuarios.DataBind();
    }

    protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        String nome_turma = ((Label)listaUsuarios.Rows[i].FindControl("Lturma")).Text;
        Debug.WriteLine("RowDeleting chamado Indice da Linha: " + i + "TURMA:" + nome_turma);
        BeanTurma u = new BeanTurma();
        u.Nome_turma = nome_turma;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String result = ws.turmaDel(serializer.Serialize(u));
        if (result == "0")
        {
            Session["msg"] = "Turma não foi excluida!";
            Response.Redirect("cadastroturma.aspx");
        }
        else
        {
            Session["msg"] = "Turma excluída com sucesso!";
            Response.Redirect("cadastroturma.aspx");
        }
    }

    public string turmaantes { get; set; }
}