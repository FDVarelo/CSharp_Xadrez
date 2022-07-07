using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor,tab)
        {

        }
        public override string ToString()
        {
            return "R";
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
            pos.definirValores(posicao.coluna, posicao.linha-1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna,pos.linha] = true;
            }

            // Baixo
            pos.definirValores(posicao.coluna, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Esquerda
            pos.definirValores(posicao.coluna - 1,posicao.linha);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Direita
            pos.definirValores(posicao.coluna + 1,posicao.linha);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Nordeste
            pos.definirValores(posicao.coluna + 1, posicao.linha - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudeste
            pos.definirValores(posicao.coluna + 1, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Sudoeste
            pos.definirValores(posicao.coluna - 1, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // Noroeste
            pos.definirValores(posicao.coluna - 1, posicao.linha - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }
            return mat;
        }
    }
}
