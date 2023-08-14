using Mttechne.Backend.Junior.Services.Model;
namespace Mttechne.Backend.Junior.Services.Services;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

public class ProdutoService : IProdutoService
{
    public List<Produto> GetListaProdutos()
    {
        Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
        Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
        Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
        Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
        Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
        Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };


        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        };

        return produtosCadastrados;
    }
    private string RemoverAcentosNome(string nome)
    {
        string removerAcentoNome = nome.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char nomeSemAcento in removerAcentoNome)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(nomeSemAcento);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(nomeSemAcento);
            }
        }

        return stringBuilder.ToString();
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();
        var nomeFormatado = RemoverAcentosNome(nome).ToLower();
        var regexP = Regex.Escape(nomeFormatado);
        var regex = new Regex(regexP, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        return listaProdutos
            .Where(produto => regex.IsMatch(RemoverAcentosNome(produto.Nome).ToLower()))
            .ToList();
    }

    public List<Produto> GetListaProdutosOrdenadaPorValor()
    {
        var listaProdutos = GetListaProdutos();
        return listaProdutos.OrderBy(produto => produto.Valor)
            .ToList();
    }


    public List<Produto> GetListaProdutosPorFaixaDePreco(int valorInicial, int valorFinal)
    {
        var listaProdutos = GetListaProdutos();
        return listaProdutos.Where(produto => produto.Valor >= valorInicial && produto.Valor <= valorFinal)
            .ToList();
    }

    public List<Produto> GetListaProdutosPorValorMaximo()
    {
        var listaProdutos = GetListaProdutos();
        var listaProdutosAgrupadoProNome = listaProdutos.GroupBy(produto => produto.Nome);
        return listaProdutosAgrupadoProNome
            .Select(grupo => grupo.OrderByDescending(prdotudo => prdotudo.Valor).FirstOrDefault())
            .ToList();
    }
    public List<Produto> GetListaProdutosPorValorMinimo()
    {
        var listaProdutos = GetListaProdutos();
        var listaProdutosAgrupadoProNome = listaProdutos.GroupBy(produto => produto.Nome);
        return listaProdutosAgrupadoProNome
            .Select(grupo => grupo.OrderByDescending(prdotudo => prdotudo.Valor).LastOrDefault())
            .ToList();
    }
}