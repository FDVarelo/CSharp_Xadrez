using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "D";
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

            // Cima
            pos.definirValores(posicao.coluna, posicao.linha - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha -= 1;
            }

            // Baixo
            pos.definirValores(posicao.coluna, posicao.linha + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha += 1;
            }

            // Esquerda
            pos.definirValores(posicao.coluna - 1, posicao.linha);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna -= 1;
            }

            // Direita
            pos.definirValores(posicao.coluna + 1, posicao.linha);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna += 1;
            }

            // Nordeste
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

            // Sudeste
            pos.definirValores(posicao.coluna + 1, posicao.linha + 1);
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

            // Sudoeste
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

            // Noroeste
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
