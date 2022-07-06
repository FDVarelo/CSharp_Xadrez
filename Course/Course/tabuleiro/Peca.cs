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

        public abstract bool[,] movimentosPossiveis();

    }
}
