using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "P";
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

            //frente
             if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.coluna, posicao.linha - 1);
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.coluna, pos.linha] = true;
                }
            }
            else if(cor == Cor.Preta)
            {
                pos.definirValores(posicao.coluna, posicao.linha + 1 );
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.coluna, pos.linha] = true;
                }
            }

            /*if (cor == Cor.Preta)
            {
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
            }

            if (cor == Cor.Branca)
            {
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
            }*/


            return mat;
        }
    }
}
