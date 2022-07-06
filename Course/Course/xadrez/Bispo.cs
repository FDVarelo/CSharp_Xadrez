using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.colunas, tab.linhas];

            Posicao pos = new Posicao(0, 0);

            //nordeste
            pos.definirValores(posicao.coluna + 1, posicao.linha - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna += 1;
                pos.linha -= 1;
            }

            //sudeste
            pos.definirValores(posicao.coluna + 1, posicao.linha + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna += 1;
                pos.linha += 1;
            }

            //sudoeste
            pos.definirValores(posicao.coluna - 1, posicao.linha + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna -= 1;
                pos.linha += 1;
            }

            //noroeste
            pos.definirValores(posicao.coluna - 1, posicao.linha - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna -= 1;
                pos.linha -= 1;
            }


            return mat;
        }
    }
}
