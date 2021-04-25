using Alura.ListaLeitura.Modelos;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Alura.WebAPI.Api.Modelos
{
    public static class LivroOrdemExtensions
    {
        public static IQueryable<Livro> AplicaOrdem(this IQueryable<Livro> query, LivroOrdem livroOrdem)
        {
            if (livroOrdem != null &&
                !string.IsNullOrEmpty(livroOrdem.OrdenarPor))
            {
                query = query.OrderBy(livroOrdem.OrdenarPor);
            }
            return query;
        }
    }
    public class LivroOrdem
    {
        public string OrdenarPor { get; set; }
    }
}
