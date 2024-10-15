namespace L2.Manoel.Core.Entities
{
    public class Produto
    {
        public string produto_id { get; set; }
        public Dimensao dimensoes { get; set; }
    }

    public class Dimensao
    {
        public int altura { get; set; }
        public int largura { get; set; }
        public int comprimento { get; set; }

        public int Volume()
        {
            return altura * largura * comprimento;
        }
    }
}
