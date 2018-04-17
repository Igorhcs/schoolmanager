using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cadastroadm : System.Web.UI.Page
{
    webService.WSControlSoapClient ws = new webService.WSControlSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logado"] == null)
        {
            Session["msg"] = "Sem permissão de acesso!";
            Response.Redirect("login.aspx");
        }
        else
        {
            if (Session["logado"].ToString() != "OK")
            {
                Session["msg"] = "Sem permissão de acesso!";
                Response.Redirect("login.aspx");
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

        if (!utils.eValido(tb_login.Text))
        {
            bv.Text = "Email inválido";
            tb_login.Text = "";
            tb_login.Focus();
        }
        else if (tb_pass.Text.Length < 5)
        {
            bv.Text = "Campo senha deve conter 6 caracteres ou mais";
            tb_pass.Text = "";
            tb_pass.Focus();
        }
        else
        {
            if (id.Text == "")
            {
                json = new JavaScriptSerializer().Serialize(new
                { 
                    nome = tb_nome.Text,
                    login = tb_login.Text,
                    senha = tb_pass.Text,
                    status = tb_status.Text
                });
                rel = ws.admIn(json);
                if (rel == "0")
                {

                    Session["msg"] = "Problema ao inserir admin";
                    Response.Redirect("cadastroadm.aspx");
                }
                else if (rel == "1")
                {

                    Session["msg"] = "Admin inserido com sucesso!";
                    Response.Redirect("cadastroadm.aspx");
                }
                else if (rel == "2")
                {

                    Session["msg"] = "Admin já cadastrado no sistema!";
                    Response.Redirect("cadastroadm.aspx");
                }
            }
            else
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    nome = tb_nome.Text,
                    login = tb_login.Text,
                    senha = tb_pass.Text,
                    status = tb_status.Text
                });
                rel = ws.updateADM(json);
                Debug.WriteLine("Valor do retorno: " + rel);
                if (rel == "0")
                {
                    Session["msg"] = "Problemas ao atualizar admin";
                    Response.Redirect("cadastroadm.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Admin atualizado com sucesso!";
                    Response.Redirect("cadastroadm.aspx");
                }
                else if (rel == "2")
                {
                    Session["msg"] = "Admin já cadastrado no sistema!";
                    Response.Redirect("cadastroadm.aspx");
                }
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

        String idadm = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        String nome = ((Label)listaUsuarios.Rows[i].FindControl("Lnome")).Text;
        String login = ((Label)listaUsuarios.Rows[i].FindControl("Llogin")).Text;
        String senha = ((Label)listaUsuarios.Rows[i].FindControl("Lsenha")).Text;
        String status = ((Label)listaUsuarios.Rows[i].FindControl("Lstatus")).Text;

        id.Text = idadm;
        tb_nome.Text = nome;
        tb_login.Text = login;
        tb_pass.Text = senha;
        tb_status.Text = status;

    }
    protected void listaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        listaUsuarios.EditIndex = -1;
        Debug.WriteLine("RowCancelingEdit chamado");
        tb_pass.Text = "";
        tb_login.Text = "";
        id.Text = "";
        tb_nome.Text = "";
        tb_status.Text = "";
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
        List<BeanADM> list = new List<BeanADM>();


        //1ª FORMA DE PREENCHER O GRID
        list = serializer.Deserialize<List<BeanADM>>(ws.admAll());

        listaUsuarios.DataSource = null;
        listaUsuarios.DataSource = list;
        listaUsuarios.DataBind();
    }

    protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        String idadm = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        Debug.WriteLine("RowDeleting chamado Indice da Linha: " + i + "ID:" + idadm);
        BeanADM u = new BeanADM();
        u.Idadm = int.Parse(idadm);
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String result = ws.admDel(serializer.Serialize(u));
        if (result == "0")
        {
            Session["msg"] = "Admin não foi excluido!";
            Response.Redirect("cadastroadm.aspx");
        }
        else
        {
            Session["msg"] = "  Admin excluído com sucesso!";
            Response.Redirect("cadastroadm.aspx");
        }
    }
}