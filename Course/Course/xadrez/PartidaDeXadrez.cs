using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8); // Tamanho da matriz do tabuleiro.
            turno = 1; // Primeiro turno.
            jogadorAtual = Cor.Branca; // Qual peça deve começar.
            terminada = false; // Jogo continua até ser true.
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // tira peça da origem
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso tenha uma peca no destino, ela é capturada
            tab.colocarPeca(p, destino); // coloca a peça no destino final
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void mudaJogador() // chamada quando acaba a rodada de um jogador, fazendo assim mudar a cor do jogador atual.
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual= Cor.Branca;
            }
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null) // Espaço sem peça.
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor) // Peça adversaria.
            {
                throw new TabuleiroException("A peça da origem escolhida não é a sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) // Peça está presa, ou seja, não tem movimentos possíveis.
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            // Peça não pode fazer o movimento de origem → destino,
            // ou por ter uma peça aliada no local,
            // ou por não fazer parte da lista de movimentos possíveis da peça
            {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }

        private void colocarPecas() // Criando o tabuleiro de xadrez inicial.
        {
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('a', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('h', 8).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('a', 1).toPosicao());
            tab.colocarPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('h', 1).toPosicao());

            tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('b', 8).toPosicao());
            tab.colocarPeca(new Cavalo(Cor.Preta, tab), new PosicaoXadrez('g', 8).toPosicao());
            tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('b', 1).toPosicao());
            tab.colocarPeca(new Cavalo(Cor.Branca, tab), new PosicaoXadrez('g', 1).toPosicao());

            tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Bispo(Cor.Preta, tab), new PosicaoXadrez('f', 8).toPosicao());
            tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Bispo(Cor.Branca, tab), new PosicaoXadrez('f', 1).toPosicao());

            tab.colocarPeca(new Dama(Cor.Preta, tab), new PosicaoXadrez('d', 8).toPosicao());
            tab.colocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Dama(Cor.Branca, tab), new PosicaoXadrez('d', 1).toPosicao());
            tab.colocarPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('e', 1).toPosicao());

            for (char i = 'a'; i <= 'h'; i++) // Colocando todos os peões.
            {
                tab.colocarPeca(new Peao(Cor.Preta, tab), new PosicaoXadrez(i, 7).toPosicao());
                tab.colocarPeca(new Peao(Cor.Branca, tab), new PosicaoXadrez(i, 2).toPosicao());
            }
        }
    }
}
