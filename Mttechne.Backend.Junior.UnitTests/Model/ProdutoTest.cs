using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{

    ProdutoService _produtoService;

    public ProdutoTest()
    {
        _produtoService = new ProdutoService();
    }

    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }
    [Fact]
    public void ShouldFilterProductsByName()
    {
        var filteredProducts = _produtoService.GetListaProdutosPorNome("Mem�ria");

        Assert.Equal("Mem�ria", filteredProducts[0].Nome);
    }

    [Fact]
    public void ShouldSortProductsByValue()
    {
        var sortedProducts = _produtoService.GetListaProdutosOrdenadaPorValor();

        Assert.Equal(300, sortedProducts.First().Valor);
        Assert.Equal(2100, sortedProducts.Last().Valor);
    }

    [Fact]
    public void ShouldFilterProductsByPriceRange()
    {

        var filteredProducts = _produtoService.GetListaProdutosPorFaixaDePreco(900, 1400);

        Assert.Equal(3, filteredProducts.Count);
        Assert.Contains(filteredProducts, p => p.Nome == "Placa de V�deo");
        Assert.Contains(filteredProducts, p => p.Nome == "Placa de V�deo");
        Assert.Contains(filteredProducts, p => p.Nome == "Placa m�e");
    }

    [Fact]
    public void ShouldGetProductsWithMaximumValue()
    {
        var maxValuedProducts = _produtoService.GetListaProdutosPorValorMaximo();

        Assert.Equal("Placa de V�deo", maxValuedProducts[0].Nome);
        Assert.Equal(1500, maxValuedProducts[0].Valor);
        Assert.Equal("Processador", maxValuedProducts[1].Nome);
        Assert.Equal(2100, maxValuedProducts[1].Valor);
        Assert.Equal("Mem�ria", maxValuedProducts[2].Nome);
        Assert.Equal(350, maxValuedProducts[2].Valor);
        Assert.Equal("Placa m�e", maxValuedProducts[3].Nome);
        Assert.Equal(1100, maxValuedProducts[3].Valor);
    }

    [Fact]
    public void ShouldGetProductsWithMinimumValue()
    {
        var minValuedProducts = _produtoService.GetListaProdutosPorValorMinimo().ToList();

        Assert.Equal("Placa de V�deo", minValuedProducts[0].Nome);
        Assert.Equal(1000, minValuedProducts[0].Valor);
        Assert.Equal("Processador", minValuedProducts[1].Nome);
        Assert.Equal(2000, minValuedProducts[1].Valor);
        Assert.Equal("Mem�ria", minValuedProducts[2].Nome);
        Assert.Equal(300, minValuedProducts[2].Valor);
        Assert.Equal("Placa m�e", minValuedProducts[3].Nome);
        Assert.Equal(1100, minValuedProducts[3].Valor);

    }
}