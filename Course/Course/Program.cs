using System;
using tabuleiro;
using xadrez;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Posicao P; // Testando a criação de uma posição
            P = new Posicao(3, 4);

            Console.WriteLine("Posição: " + P);
            Console.WriteLine();*/

            Tabuleiro tab = new Tabuleiro(8, 8); // Criando um tabuleiro 8x8

            // Modelo Xadrez Padrão
            for (int i = 0; i < 8; i++)
            {
                tab.ColocarPeca(new Peao(Cor.Preta, tab), new Posicao(1, i));
                tab.ColocarPeca(new Peao(Cor.Branca, tab), new Posicao(6, i));
                if (i == 0 || i == 7)
                {
                    tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, i));
                    tab.ColocarPeca(new Torre(Cor.Branca, tab), new Posicao(7, i));
                }
                else if(i == 1 || i == 6)
                {
                    tab.ColocarPeca(new Cavalo(Cor.Preta, tab), new Posicao(0, i));
                    tab.ColocarPeca(new Cavalo(Cor.Branca, tab), new Posicao(7, i));
                }
                else if(i == 2 || i == 5)
                {
                    tab.ColocarPeca(new Bispo(Cor.Preta, tab), new Posicao(0, i));
                    tab.ColocarPeca(new Bispo(Cor.Branca, tab), new Posicao(7, i));
                }
                else if(i == 3)
                {
                    tab.ColocarPeca(new Dama(Cor.Preta, tab), new Posicao(0, i));
                    tab.ColocarPeca(new Dama(Cor.Branca, tab), new Posicao(7, i));
                }
                else
                {
                    tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, i));
                    tab.ColocarPeca(new Rei(Cor.Branca, tab), new Posicao(7, i));
                }
            }


            Tela.imprimirTabuleiro(tab);
        }
    }
}