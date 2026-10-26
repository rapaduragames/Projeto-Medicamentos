
using System.Collections.Generic;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos;

    public Medicamentos()
    {
        listaMedicamentos = new List<Medicamento>();
    }

    public void adicionar(Medicamento medicamento)
    {
        if (medicamento != null)
        {
            listaMedicamentos.Add(medicamento);
        }
    }

    public bool deletar(Medicamento medicamento)
    {
        Medicamento encontrado = pesquisar(medicamento);

        if (encontrado.Id == 0 ||
            encontrado.qtdeDisponivel() != 0)
        {
            return false;
        }

        return listaMedicamentos.Remove(encontrado);
    }

    public Medicamento pesquisar(Medicamento medicamento)
    {
        foreach (Medicamento item in listaMedicamentos)
        {
            if (item.Equals(medicamento))
            {
                return item;
            }
        }

        return new Medicamento();
    }

    public void listar()
    {
        foreach (Medicamento medicamento in listaMedicamentos)
        {
            System.Console.WriteLine(medicamento);
        }
    }
}
