namespace L2.Manoel.Core.Entities
{
    public class Caixa
    {
        public string caixa_id { get; set; }
        public int altura { get; set; }
        public int largura { get; set; }
        public int comprimento { get; set; }

        public int Volume()
        {
            return altura * largura * comprimento;
        }

        public bool ProdutoCabe(Produto produto)
        {
            return produto.dimensoes.altura <= this.altura &&
                   produto.dimensoes.largura <= this.largura &&
                   produto.dimensoes.comprimento <= this.comprimento;
        }
    }
}
