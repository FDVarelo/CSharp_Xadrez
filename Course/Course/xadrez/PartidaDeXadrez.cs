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
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8); // Tamanho da matriz do tabuleiro.
            turno = 1; // Primeiro turno.
            xeque = false;
            jogadorAtual = Cor.Branca; // Qual peça deve começar.
            terminada = false; // Jogo continua até ser true.

            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }

        // Realização de movimentos

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // tira peça da origem
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso tenha uma peca no destino, ela é capturada
            tab.colocarPeca(p, destino); // coloca a peça no destino final
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Rei não pode ser colocado em xeque!");
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            turno++;
            mudaJogador();
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
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
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) // Estava como 'capturadas', agora esta como 'pecas,
                                      // por conta disso, antes não mostrava quando a peça estava em xeque,
                                      // e dava problema de toda hora não ter um Rei no tabuleiro.
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        // Colocando peças no tabuleiro.

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() // Criando o tabuleiro de xadrez inicial.
        {
            // Teste.
            colocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('c', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Torre(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));


            colocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Torre(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));

            /*colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
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
            }*/
        }
    }
}
