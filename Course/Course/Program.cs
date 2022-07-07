using System;
using tabuleiro;
using xadrez;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) // Enquanto a partida não estiver encerrada . . .    
                {
                    try // Verificar se a origem que está sendo escolhida está OK.
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab); // Inicia com o tabuleiro padrão.
                        Console.WriteLine("\nTurno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                        Console.Write("\nDigite a posição de origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem); // Verificar se a origem escolhida é possível.

                        // Mostrar os possíveis movimentos que a peça de origem pode fazer como destino.
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis); // Imprimir tabuleiro com possíveis movimentos de destino.

                        Console.Write("\nDigite a posição de destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino); // Verificar se o destino escolhido é possível.

                        partida.realizaJogada(origem, destino); // Realiza o movimento.
                    }
                    catch(TabuleiroException e) // Ocorreu um erro na escolha da origem ou destino.
                    {
                        Console.WriteLine(e.Message); // Erro que aconteceu.
                        Console.WriteLine("Aperte Enter para tentar novamente."); // Tentar novamente.
                        Console.ReadLine();
                    }
                }

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}