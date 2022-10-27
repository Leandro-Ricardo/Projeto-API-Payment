namespace tech_test_payment_api.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public double CpfDoVendedor { get; set; }
        public int TelefoneDoVendedor { get; set; }
        public string NomeDoVendedor { get; set; }
        public string EmailDoVendedor { get; set; }
        public string ProdutoVendido { get; set; }
        public DateTime DataDaVenda { get; set; }
        public EnumStatusVenda StatusDaVenda { get; set; }
    }
}