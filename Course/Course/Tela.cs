using System;
using xadrez;
using tabuleiro;

namespace Course
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {

                ConsoleColor aux2 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " "); // linha número
                Console.ForegroundColor = aux2;
                
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            ConsoleColor aux3 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h"); // colunas letras
            Console.ForegroundColor = aux3;
            
        }

        public static PosicaoXadrez lerPosicaoXadrez() // Tem que ser PosicaoXadrez e não so Posicao, pois se não da erro quando for usando toPosicao.
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow; // cor amarela para peças pretas
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }

    }
}
