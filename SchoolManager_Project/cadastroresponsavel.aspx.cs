using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cadastroresponsavel : System.Web.UI.Page
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
                    nome_responsavel = tb_nome.Text,
                    login = tb_login.Text,
                    senha = tb_pass.Text,

                });
                rel = ws.responsavelIn(json);
                if (rel == "0")
                {
                    Session["msg"] = "Problema ao inserir responsável";
                    Response.Redirect("cadastroresponsavel.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Responsável inserido com sucesso!";
                    Response.Redirect("cadastroresponsavel.aspx");
                }
                else if (rel == "2")
                {

                    Session["msg"] = "Responsável já cadastrado no sistema!";
                    Response.Redirect("cadastroresponsavel.aspx");
                }
                Response.Redirect("cadastroresponsavel.aspx");
            }
            else
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    nome_responsavel = tb_nome.Text,
                    login = tb_login.Text,
                    senha = tb_pass.Text,
                });
                rel = ws.updateResponsavel(json);
                Debug.WriteLine("Valor do retorno: " + rel);
                if (rel == "0")
                {
                    Session["msg"] = "Problemas ao atualizar responsavel";
                    Response.Redirect("cadastroresponsavel.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Responsável atualizado com sucesso!";
                    Response.Redirect("cadastroresponsavel.aspx");
                }
                else if (rel == "2")
                {
                    Session["msg"] = "Responsável já cadastrado no sistema!";
                    Response.Redirect("cadastroresponsavel.aspx");
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

        String idresponsavel = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        String nome_responsavel = ((Label)listaUsuarios.Rows[i].FindControl("Lnome")).Text;
        String login = ((Label)listaUsuarios.Rows[i].FindControl("Llogin")).Text;
        String senha = ((Label)listaUsuarios.Rows[i].FindControl("Lsenha")).Text;

        id.Text = idresponsavel;
        tb_nome.Text = nome_responsavel;
        tb_login.Text = login;
        tb_pass.Text = senha;
    }
    protected void listaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        listaUsuarios.EditIndex = -1;
        Debug.WriteLine("RowCancelingEdit chamado");
        tb_pass.Text = "";
        tb_login.Text = "";
        id.Text = "";
        tb_nome.Text = "";
        tb_login.Focus();
        fillGrid();
    }
    protected void listaUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Debug.WriteLine("RowUpdating chamado");

    }
    protected void fillGrid()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<BeanResponsavel> list = new List<BeanResponsavel>();


        //1ª FORMA DE PREENCHER O GRID
        list = serializer.Deserialize<List<BeanResponsavel>>(ws.responsavelAll());

        listaUsuarios.DataSource = null;
        listaUsuarios.DataSource = list;
        listaUsuarios.DataBind();
    }

    protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        String idresponsavel = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        Debug.WriteLine("RowDeleting chamado Indice da Linha: " + i + "ID:" + idresponsavel);
        BeanResponsavel u = new BeanResponsavel();
        u.Idresponsavel = int.Parse(idresponsavel);
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String result = ws.responsavelDel(serializer.Serialize(u));
        if (result == "0")
        {
            Session["msg"] = "Responsável não foi excluido!";
           // Response.Redirect(Request.RawUrl);
           // Response.Redirect("cadastroresponsavel.aspx");
        }
        else
        {
            Session["msg"] = "Responsável excluído com sucesso!";           
            Response.Redirect("cadastroresponsavel.aspx");
            
        }
    }
}