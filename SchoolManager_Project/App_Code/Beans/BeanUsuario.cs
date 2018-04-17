using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanUsuario
/// </summary>
public class BeanUsuario
{
    private long idusuario;
    private String login;
    private String senha;

    public long Idusuario
    {
        get { return idusuario; }
        set { idusuario = value; }
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

	public BeanUsuario()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}