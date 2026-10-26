
using System;

class Program
{
    static void Main(string[] args)
    {
        Medicamentos medicamentos = new Medicamentos();

        Medicamento m1 = new Medicamento(
            1, "Paracetamol", "Medley"
        );

        m1.comprar(new Lote(
            101, 10, new DateTime(2027, 5, 10)
        ));

        m1.comprar(new Lote(
            102, 20, new DateTime(2027, 8, 15)
        ));

        medicamentos.adicionar(m1);

        Console.WriteLine("Medicamentos cadastrados:");
        medicamentos.listar();

        Console.WriteLine("\nEstoque inicial: " +
                          m1.qtdeDisponivel());

        bool sucesso = m1.vender(15);

        Console.WriteLine("Venda realizada: " + sucesso);
        Console.WriteLine("Estoque após venda: " +
                          m1.qtdeDisponivel());

        Console.WriteLine("\nTentando excluir medicamento:");

        bool excluido = medicamentos.deletar(m1);

        Console.WriteLine("Excluído: " + excluido);

        m1.vender(15);

        excluido = medicamentos.deletar(m1);

        Console.WriteLine("Excluído após zerar estoque: " +
                          excluido);
    }
}
