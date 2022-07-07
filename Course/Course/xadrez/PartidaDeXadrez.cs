using System.Collections.Generic;
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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8); // Tamanho da matriz do tabuleiro.
            turno = 1; // Primeiro turno.
            jogadorAtual = Cor.Branca; // Qual peça deve começar.
            terminada = false; // Jogo continua até ser true.

            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }

        // Realização de movimentos

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // tira peça da origem
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso tenha uma peca no destino, ela é capturada
            tab.colocarPeca(p, destino); // coloca a peça no destino final
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void mudaJogador() // chamada quando acaba a rodada de um jogador, fazendo assim mudar a cor do jogador atual.
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        // Validação de posições.

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null) // Espaço sem peça.
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor) // Peça adversaria.
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

        public HashSet<Peca> pecasCapturadas(Cor cor) // Peças capturadas, dada uma certa cor.
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) // Peças capturadas, dada uma certa cor.
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        // Colocando peças no tabuleiro.

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() // Criando o tabuleiro de xadrez inicial.
        {
            colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('a', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));

            colocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tab));

            colocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('c', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('f', 1, new Bispo(Cor.Branca, tab));

            colocarNovaPeca('d', 8, new Dama(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.Preta, tab));
            colocarNovaPeca('d', 1, new Dama(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.Branca, tab));

            for (char i = 'a'; i <= 'h'; i++) // Colocando todos os peões.
            {
                colocarNovaPeca(i, 7, new Peao(Cor.Preta, tab));
                colocarNovaPeca(i, 2, new Peao(Cor.Branca, tab));
            }
        }
    }
}
