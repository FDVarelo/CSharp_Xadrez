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
            this.qtdMovimentos = 0; // Como acabou de criar a peça, ela inicia com 0
            this.tab = tab;
            
        }

        public void incrementarQtdeMovimentos()
        {
            qtdMovimentos++;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis(); // verificar se ha pelomenos um movimento possivel
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
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
            return movimentosPossiveis()[pos.coluna, pos.linha];
        }
        public abstract bool[,] movimentosPossiveis();

    }
}
