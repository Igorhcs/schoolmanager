using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class painelescola : System.Web.UI.Page
{
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
       
    }
}