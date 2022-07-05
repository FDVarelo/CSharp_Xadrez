namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas,colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça sua nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
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
            pecas[pos.linha, pos.coluna] = null; // atualiza dizendo que a posição agora é nula
            return aux; // retorna a peça
        }
        public bool posisaoValida(Posicao pos)  // verificar se as posições passadas estão na área limite do tabuleiro
        {
            if(pos.linha<0 || pos.coluna<0 || pos.linha>=linhas || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posisaoValida(pos))
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
