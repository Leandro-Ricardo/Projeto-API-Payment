using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Context;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaController : ControllerBase
    {
        private readonly MemoryContext _context;
        ListaDeProdutos ListagemDosProdutos = new ListaDeProdutos();

        public LojaController(MemoryContext context)
        {
            _context = context;
        }

        [HttpPost("RegistrarVenda")]
        public IActionResult RegistroVenda(Vendedor vendedor)
        {
            if (!string.IsNullOrEmpty(vendedor.ProdutoVendido) &&
             !string.IsNullOrWhiteSpace(vendedor.ProdutoVendido) &&
             ListagemDosProdutos.Produtos.Contains(vendedor.ProdutoVendido))
            {
                _context.Add(vendedor);
                _context.SaveChanges();
                return Ok(vendedor);
            }            
            else return NotFound(ListagemDosProdutos.Produtos);
        }

        [HttpGet("BuscarTodosOsProdutos")]
        public IActionResult BuscarTodosOsPrdutos()
        {
            return Ok(ListagemDosProdutos.Produtos);
        }

        [HttpGet("BuscarVenda/{id}")]
        public IActionResult BuscarVendaPorId(int id)
        {
            var BuscarVendaPorId = _context.Vendedores.Find(id);

            if (BuscarVendaPorId == null)
                return NotFound();

            return Ok(BuscarVendaPorId);
        }

        [HttpPut("AtualizarVenda/{id}")]
        public IActionResult Atualizar(int id, Vendedor vendedor)
        {
            var vendedorLoja = _context.Vendedores.Find(id);
            var StatusAnterior = vendedorLoja.StatusDaVenda;

            if (StatusAnterior == EnumStatusVenda.AguardandoPagamento)
            {
                if (vendedor.StatusDaVenda == EnumStatusVenda.PagamentoAprovado)
                    vendedorLoja.StatusDaVenda = EnumStatusVenda.PagamentoAprovado;
                if (vendedor.StatusDaVenda == EnumStatusVenda.Cancelado)
                    vendedorLoja.StatusDaVenda = EnumStatusVenda.Cancelado;
            }

            if (StatusAnterior == EnumStatusVenda.PagamentoAprovado)
                if (vendedor.StatusDaVenda == EnumStatusVenda.EnviadoParaTransportadora)
                    vendedorLoja.StatusDaVenda = EnumStatusVenda.EnviadoParaTransportadora;

            if (StatusAnterior == EnumStatusVenda.EnviadoParaTransportadora)
                if (vendedor.StatusDaVenda == EnumStatusVenda.Entregue)
                    vendedorLoja.StatusDaVenda = EnumStatusVenda.Entregue;

            _context.Vendedores.Update(vendedorLoja);
            _context.SaveChanges();
            return Ok(vendedorLoja);
        }
    }
}
