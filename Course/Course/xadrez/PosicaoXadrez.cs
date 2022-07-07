using tabuleiro;

namespace xadrez
{
    public class PosicaoXadrez
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
            return new Posicao(8 - linha, coluna - 'a'); 
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

            então, ex.: "a8" →  'a' - 'a' = 0 | 8 - 8 = 0, ou seja, Matriz[0,0]
            */
        }

        public override string ToString()
        {
            return "" +coluna+linha;
        }
    }
}
