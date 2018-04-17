using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (Session["logado"] == null)
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
            else
            {
                bv.Text = "Bem vindo " + Session["email"].ToString();
                Session["msg"] = "";
            }
        } */

    }  
}