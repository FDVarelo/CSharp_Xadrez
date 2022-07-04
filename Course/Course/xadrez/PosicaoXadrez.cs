using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(coluna - 'a', 8 - linha); 
            // Considerando que: ↓
            /* Onde - é os possiveis locais onde as peças pode ser colocadas.
             
                8 - - - - - - - -
                7 - - - - - - - -
                6 - - - - - - - -
                5 - - - - - - - -
                4 - - - - - - - -
                3 - - - - - - - -
                2 - - - - - - - -
                1 - - - - - - - -
                  a b c d e f g h
            */
        }

        public override string ToString()
        {
            return "" +coluna+linha;
        }
    }
}
