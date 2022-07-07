namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.posicao = posicao;
            this.cor = cor;
            this.qtdMovimentos = 0; // Como acabou de criar a peça, ela inicia com 0.
            this.tab = tab;

        }

        public void incrementarQtdeMovimentos()
        {
            qtdMovimentos++;
        }
        public void decrementarQtdeMovimentos()
        {
            qtdMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis(); // Verificar se há pelo menos um movimento possível.
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        public abstract bool[,] movimentosPossiveis(); // Criação de movimento possíveis para todas as peças.

    }
}
