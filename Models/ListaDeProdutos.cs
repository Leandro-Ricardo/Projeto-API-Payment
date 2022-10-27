namespace tech_test_payment_api.Models
{
    public class ListaDeProdutos
    {
        public List<string> Produtos { get; set; } = new List<string>() {
            "Televisao",
            "Computador",
            "Celular",            
            "Microondas",
            "Camera",
            "Mesa",
            "Cadeira",
            "Porta"
            };
    }
}