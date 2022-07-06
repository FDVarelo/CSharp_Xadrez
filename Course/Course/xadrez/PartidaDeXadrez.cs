using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem); // tira peça da origem
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino); // caso tenha uma peca no destino, ela é capturada
            tab.colocarPeca(p, destino); // coloca a peça no destino final
        }

        private void colocarPecas()
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

            for (char i = 'a'; i <= 'h'; i++)
            {
                tab.colocarPeca(new Peao(Cor.Preta, tab), new PosicaoXadrez(i, 7).toPosicao());
                tab.colocarPeca(new Peao(Cor.Branca, tab), new PosicaoXadrez(i, 2).toPosicao());
            }
        }
    }
}
