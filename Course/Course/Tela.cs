using System.Collections.Generic;
using xadrez;
using tabuleiro;

namespace Course
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Tela.imprimirTabuleiro(partida.tab); // Inicia com o tabuleiro padrão.
            imprimirPecasCapturadas(partida);
            Console.WriteLine("\nTurno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("\nPeças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab) // Imprimir o tabuleiro inicial.
        {
            for (int i = 0; i < tab.linhas; i++)
            {

                ConsoleColor aux2 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " "); // Número da coluna.
                Console.ForegroundColor = aux2;

                for (int j = 0; j < tab.colunas; j++)
                {
                    Tela.imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux3 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h"); // Letras das linhas.
            Console.ForegroundColor = aux3;

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) // Imprimir o tabulei mostrando os possiveis movimentos.
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor; // Cor original de fundo.
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; // Cor de fundo quando pode-se mover a peça ao local.
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux2 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " "); // Número da coluna.
                Console.ForegroundColor = aux2;

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j]) // Caso seja uma posição que a peça pode se mover.
                    {
                        Console.BackgroundColor = fundoAlterado; // Mudar a cor de fundo para mostrar que o local é disponivel.
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            ConsoleColor aux3 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h"); // Letras das linhas.
            Console.ForegroundColor = aux3;
            Console.BackgroundColor = fundoOriginal;

        }

        public static PosicaoXadrez lerPosicaoXadrez() // Tem que ser PosicaoXadrez e não apenas Posicao,
                                                       // caso contrario, apresenta erro ao utiliza toPosicao no Program.cs.
        {
            string s = Console.ReadLine(); // Ler a entrada do usuário, ex.: "a1".
            char coluna = s[0]; // pega a linha 'a'.
            int linha = int.Parse(s[1] + ""); // pega a coluna '1'.

            return new PosicaoXadrez(coluna, linha); // Retorna a posição como linha e coluna.
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null) // Caso não exista peça no local.
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow; // Cor amarela para representar as peças pretas.
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
