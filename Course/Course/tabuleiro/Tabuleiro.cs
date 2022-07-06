namespace tabuleiro
{
    class Tabuleiro
    {
        public int colunas { get; set; }
        public int linhas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int colunas, int linhas)
        {
            this.colunas = colunas;
            this.linhas = linhas;
            pecas = new Peca[colunas,linhas];
        }

        public Peca peca(int coluna, int linha)
        {
            return pecas[coluna, linha];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.coluna, pos.linha];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça sua nessa posição!");
            }
            pecas[pos.coluna, pos.linha] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null; // retira a peça do tabuleiro
            pecas[pos.coluna, pos.linha] = null; // atualiza dizendo que a posição agora é nula
            return aux; // retorna a peça
        }
        public bool posicaoValida(Posicao pos)  // verificar se as posições passadas estão na área limite do tabuleiro
        {
            if(pos.coluna<0 || pos.linha<0 || pos.coluna>=colunas || pos.linha >= linhas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição é inválida!");
            }
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
    }
}
