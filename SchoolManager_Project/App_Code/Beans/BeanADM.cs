using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanADM
/// </summary>
public class BeanADM
{

    private int idadm;
    private String nome;
    private String login;
    private String senha;
    private Boolean status;

    public int Idadm
    {
        get { return idadm; }
        set { idadm = value; }
    }
    
    public String Nome
    {
        get { return nome; }
        set { nome = value; }
    }
   

    public String Login
    {
        get { return login; }
        set { login = value; }
    }
   
    public String Senha
    {
        get { return senha; }
        set { senha = value; }
    }
    

    public Boolean Status
    {
        get { return status; }
        set { status = value; }
    }


	public BeanADM()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}