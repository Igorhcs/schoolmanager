using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["msg"] != null)
        {
            lb_msg.Text = Session["msg"].ToString();

        }
    }

    protected void bt_logar_Click(object sender, EventArgs e)
    {
        String email = tb_email.Text;
        String pass = tb_pass.Text;
        Utils utils = new Utils();

        if (email == "")
        {
            lb_msg.Text = "Campo email é requerido!";
            tb_email.Focus();
        }
        else if (!utils.eValido(email))
        {
            lb_msg.Text = "Email inválido!!";
            tb_email.Focus();
        }
        else if (pass.Length < 5)
        {
            lb_msg.Text = "Campo pass deve conte seis dígitos!";
            tb_pass.Focus();
        }
        else
        {
            BeanUsuario u = new BeanUsuario();
            u.Login = tb_email.Text;
            u.Senha = tb_pass.Text;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            String json;
            json = serializer.Serialize(u);
            Debug.WriteLine("Resp:" + json);
            webService.WSControlSoapClient ws = new webService.WSControlSoapClient();
            String rel = ws.loginADM(json);
            if (rel == "true")
            {
                Session["email"] = email;
                Session["logado"] = "OK";
                Response.Redirect("paineladm.aspx");
            }
            else
            {
                lb_msg.Text = "Email ou senha inválidos!";
                tb_email.Focus();
            }




        }
    }
}
