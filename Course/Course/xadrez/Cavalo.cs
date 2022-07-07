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

            // Nordeste (↑↑→)
            pos.definirValores(posicao.coluna + 1, posicao.linha - 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Nordeste direita (→→↑)
            pos.definirValores(posicao.coluna + 2, posicao.linha - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudeste direita (→→↓)
            pos.definirValores(posicao.coluna + 2, posicao.linha + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudeste (↓↓→)
            pos.definirValores(posicao.coluna + 1, posicao.linha + 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudoeste (↓↓←)
            pos.definirValores(posicao.coluna - 1, posicao.linha + 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudoeste esquerda (←←↓)
            pos.definirValores(posicao.coluna - 2, posicao.linha + 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Noroeste esquerda (←←↑)
            pos.definirValores(posicao.coluna - 2, posicao.linha - 1);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Noroeste (↑↑←)
            pos.definirValores(posicao.coluna - 1, posicao.linha - 2);

            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }


            return mat;
        }
    }
}
