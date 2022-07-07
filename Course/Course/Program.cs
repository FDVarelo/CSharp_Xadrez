// -----------------------------------------------------------------------------------------//
// * O funcionamento do código se da por:                                                   //
//                                                                                          //
// * Criar o tabuleiro padrão em \xadrez\PartidaDeXadrez.cs                                 //
//                                                                                          //
// * Criando as peças deste tabuleiro com seus movimentos em \xadrez                        //
//                                                                                          //
// * O funcionamento do tabuleiro se da por coluna x linha:                                 //
//      - ex.: "a8" → matriz[0,0], como mostrado em \xadrez\PosicaoXadrez.cs                //
//                                                                                          //
// * Em \tabuleiro tem tudo referente ao tabuleiro:                                         //
//      - Cores possíveis das peças em \tabuleiro\Cor.cs                                    //
//      - Informações das peças, como cor, e tabela que ela está ligada \tabuleiro\Peca.cs  //
//      - Por fim o tabuleiro em si (\tabuleiro\Tabuleiro.cs):                              //
//          + Movimentação das peças                                                        //
//          + Retirada das peças                                                            //
//          + Verificação de posições das peças                                             //
// -----------------------------------------------------------------------------------------//




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
                        Tela.imprimirPartida(partida);

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