using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "C";
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
            pos.definirValores(posicao.coluna + 1, posicao.linha - 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            //sudeste
            pos.definirValores(posicao.coluna + 1, posicao.linha + 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            //sudoeste
            pos.definirValores(posicao.coluna - 1, posicao.linha + 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            //noroeste
            pos.definirValores(posicao.coluna - 1, posicao.linha - 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }
            return mat;
        }
    }
}
