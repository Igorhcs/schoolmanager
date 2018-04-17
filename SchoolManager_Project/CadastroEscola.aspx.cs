using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastroUsuario : System.Web.UI.Page
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
        if(Session["msg"] != null){
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

        if (!utils.eValido(tb_email.Text))
        {
            bv.Text = "Email inválido";
            tb_email.Text = "";
            tb_email.Focus();
        }else if(tb_pass.Text.Length < 5){
            bv.Text = "Campo senha deve conter 6 caracteres ou mais";
            tb_pass.Text = "";
            tb_pass.Focus();
        }
        else
        {
            if (cnpj.Text == "")
            {
                json = new JavaScriptSerializer().Serialize(new
                {                    
                    cnpj = tb_cnpj.Text,
                    nome_escola = tb_nome.Text,
                    email = tb_email.Text,
                    senha = tb_pass.Text
                });
                rel = ws.insertEscola(json);
                if(rel == "0"){
                    
                    Session["msg"] = "Problema ao inserir escola";
                    Response.Redirect("CadastroEscola.aspx");
                }else if(rel == "1"){
                    
                    Session["msg"] = "Escola inserida com sucesso!";
                    Response.Redirect("CadastroEscola.aspx");

                }else if(rel == "2"){
                    
                    Session["msg"] = "Escola já cadastrada no sistema!";
                    Response.Redirect("CadastroEscola.aspx");
                }
                
            }
            else
            {
                json = new JavaScriptSerializer().Serialize(new
                {
                    cnpj = tb_cnpj.Text,
                    nome_escola = tb_nome.Text,
                    email = tb_email.Text,
                    senha = tb_pass.Text
                });
                rel = ws.updateEscola(json);
                Debug.WriteLine("Valor do retorno: " + rel);
                if (rel == "0")
                {
                    Session["msg"] = "Problemas ao atualizar escolar";
                    Response.Redirect("CadastroEscola.aspx");
                }
                else if (rel == "1")
                {
                    Session["msg"] = "Escola atualizada com sucesso!";
                    Response.Redirect("CadastroEscola.aspx");                  
                }
                else if (rel == "2")
                {
                    Session["msg"] = "Escola já cadastrada no sistema!";
                    Response.Redirect("CadastroEscola.aspx");                  
                }
            }
            Response.Redirect("CadastroEscola.aspx");
            fillGrid();
        }
    }
    protected void listaUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
    {
         bv.Text = "";
        //listaUsuarios.EditIndex = e.NewEditIndex;
        Debug.WriteLine("RowEditing chamado");
        int i = e.NewEditIndex;
        Debug.WriteLine("Indice da Linha: " + i);
        String cnpj = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        String nome_escola = ((Label)listaUsuarios.Rows[i].FindControl("Lnome")).Text;
        String email = ((Label)listaUsuarios.Rows[i].FindControl("Lemail")).Text;
        String senha = ((Label)listaUsuarios.Rows[i].FindControl("Lpass")).Text;

        tb_cnpj.Text = cnpj;
        tb_nome.Text = nome_escola;
        tb_email.Text = email;
        tb_pass.Text = senha;

    }
    protected void listaUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        listaUsuarios.EditIndex = -1;
        Debug.WriteLine("RowCancelingEdit chamado");
        tb_pass.Text = "";
        tb_email.Text = "";
        tb_cnpj.Text = "";
        tb_nome.Text = "";
        tb_email.Focus();
        fillGrid();
    }
    protected void listaUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Debug.WriteLine("RowUpdating chamado"); 
      
    }
    protected void fillGrid()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        List<BeanEscola> list = new List<BeanEscola>();


        //1ª FORMA DE PREENCHER O GRID
        list = serializer.Deserialize<List<BeanEscola>>(ws.escolaAll());        
       
        listaUsuarios.DataSource = null;
        listaUsuarios.DataSource = list;
        listaUsuarios.DataBind();
    }

    protected void listaUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        String idc = ((Label)listaUsuarios.Rows[i].FindControl("Lid")).Text;
        Debug.WriteLine("RowDeleting chamado Indice da Linha: " + i + "CNPJ:" + idc);
        BeanEscola u = new BeanEscola();
        u.Cnpj = idc;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String result = ws.escolaDel(serializer.Serialize(u));
        if (result == "0")
        {
            Session["msg"] = "Escola não foi excluida!";
            Response.Redirect("CadastroEscola.aspx");
        }
        else
        {
            Session["msg"] = "Escola excluída com sucesso!";
            Response.Redirect("CadastroEscola.aspx");
        }
    }
}