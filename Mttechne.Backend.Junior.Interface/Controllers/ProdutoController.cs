using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome) => Ok(_service.GetListaProdutosPorNome(nome));

    [HttpGet("valor/ordenado")]
    public async Task<IActionResult> GetListaProdutosOrdenadaPorValor() => Ok(_service.GetListaProdutosOrdenadaPorValor());

    [HttpGet("valor/faixa/{valorInicial}/{valorFinal}")]
    public async Task<IActionResult> GetListaProdGetListaProdutosPorFaixaDePrecoutosOrdenadaPorValor([FromRoute] int valorInicial, [FromRoute] int valorFinal) => Ok(_service.GetListaProdutosPorFaixaDePreco(valorInicial, valorFinal));

    [HttpGet("valor/maximo")]
    public async Task<IActionResult> GetListaProdutosPorValorMaximo() => Ok(_service.GetListaProdutosPorValorMaximo());
    [HttpGet("valor/minimo")]
    public async Task<IActionResult> GetListaProdutosPorValorMinimo() => Ok(_service.GetListaProdutosPorValorMinimo());

}