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

            // teste
            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(posicao.coluna, posicao.linha-1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna,pos.linha] = true;
            }

            // baixo
            pos.definirValores(posicao.coluna, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // esquerda
            pos.definirValores(posicao.coluna - 1,posicao.linha);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // direita
            pos.definirValores(posicao.coluna + 1,posicao.linha);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // nordeste
            pos.definirValores(posicao.coluna + 1, posicao.linha - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // sudeste
            pos.definirValores(posicao.coluna + 1, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // sudoeste
            pos.definirValores(posicao.coluna - 1, posicao.linha + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }

            // noroeste
            pos.definirValores(posicao.coluna - 1, posicao.linha - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.coluna, pos.linha] = true;
            }
            return mat;
        }
    }
}
