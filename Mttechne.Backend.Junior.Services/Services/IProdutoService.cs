using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosOrdenadaPorValor();
    List<Produto> GetListaProdutosPorFaixaDePreco(int valorInicial, int valorFinal);
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosPorValorMaximo();
    List<Produto> GetListaProdutosPorValorMinimo();
}