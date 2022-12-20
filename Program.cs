using tabuleiro;
using xadrez;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos.toPosicao());
            
        }
    }
}