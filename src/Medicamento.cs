
using System;
using System.Collections.Generic;

public class Medicamento
{
    private int id;
    private string nome;
    private string laboratorio;
    private Queue<Lote> lotes;

    public Medicamento()
    {
        lotes = new Queue<Lote>();
        nome = "";
        laboratorio = "";
    }

    public Medicamento(int id, string nome, string laboratorio)
    {
        this.id = id;
        this.nome = nome;
        this.laboratorio = laboratorio;
        lotes = new Queue<Lote>();
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Laboratorio
    {
        get { return laboratorio; }
        set { laboratorio = value; }
    }

    public int qtdeDisponivel()
    {
        int total = 0;

        foreach (Lote lote in lotes)
        {
            total += lote.Qtde;
        }

        return total;
    }

    public void comprar(Lote lote)
    {
        if (lote != null && lote.Qtde > 0)
        {
            lotes.Enqueue(lote);
        }
    }

    public bool vender(int qtde)
    {
        if (qtde <= 0 || qtde > qtdeDisponivel())
        {
            return false;
        }

        int restante = qtde;

        while (restante > 0)
        {
            Lote lote = lotes.Peek();

            if (lote.Qtde <= restante)
            {
                restante -= lote.Qtde;
                lotes.Dequeue();
            }
            else
            {
                lote.Qtde -= restante;
                restante = 0;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return id + "-" + nome + "-" +
               laboratorio + "-" + qtdeDisponivel();
    }

    public override bool Equals(object obj)
    {
        if (obj is Medicamento outro)
        {
            return id == outro.id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
