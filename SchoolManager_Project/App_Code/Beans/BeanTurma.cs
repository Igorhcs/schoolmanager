using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BeanTurma
/// </summary>
public class BeanTurma
{
	public BeanTurma()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private String nome_turma;
    private String tuA;

    public String TuA
    {
        get { return tuA; }
        set { tuA = value; }
    }
    public String Nome_turma
    {
        get { return nome_turma; }
        set { nome_turma = value; }
    }
}