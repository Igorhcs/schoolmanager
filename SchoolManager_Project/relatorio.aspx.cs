using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class relatorio : System.Web.UI.Page
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
        if (Session["msgBD"] != null)
        {
            msgBD.Text = Session["msgBD"].ToString();
        }
        
    }
    protected void enviar_Click(object sender, EventArgs e)
    {
        /*lb_msg.Text = "Relatório enviado com sucesso!";
        tb_nome.Text = "";
        msgtb.Text = "";*/
        //Response.Redirect("relatorio.aspx");
        Utils utils = new Utils();

        String rel = "";
        String json = "";
        BeanAluno ba = new BeanAluno();
        BeanHistorico bh = new BeanHistorico();

        if (id.Text == "")
        {
            ba.Idaluno = int.Parse(tb_nome.Text);
            bh.Aluno = ba;
            bh.Msg = msgtb.Text;


            json = new JavaScriptSerializer().Serialize(bh);
            rel = ws.historicoIn(json);

            if (rel.Equals("\"0\""))
            {
                Session["msgBD"] = "Problema ao enviar relatório";
                Response.Redirect("relatorio.aspx");
            }
            else if (rel.Equals("\"1\""))
            {
                Session["msgBD"] = "Relatório enviado com sucesso!";
                Response.Redirect("relatorio.aspx");
            }
            else if (rel.Equals("\"2\""))
            {

                Session["msgBD"] = "Erro";
                Response.Redirect("c.aspx");
            }
            else
            {
                Session["msgBD"] = "Eduardo falo que Isac mangou de mim!"+rel;
                Response.Redirect("relatorio.aspx");

            }
        }
        
    }
}