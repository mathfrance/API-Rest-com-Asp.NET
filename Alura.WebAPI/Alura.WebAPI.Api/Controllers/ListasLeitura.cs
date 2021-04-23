using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ListasLeitura : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLeitura(IRepository<Livro> repo)
        {
            _repo = repo;
        }

        private Lista CriaLista(TipoListaLeitura tipo)
        {
            return new Lista
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All
                        .Where(l => l.Lista == tipo)
                        .Select(l => l.ToApi())
                        .ToList()
            };
        }

        [HttpGet]
        public IActionResult TodasListas()
        {
            Lista paraler = CriaLista(TipoListaLeitura.ParaLer);
            Lista lendo = CriaLista(TipoListaLeitura.Lendo);
            Lista lidos = CriaLista(TipoListaLeitura.Lidos);
            var collection = new List<Lista> { paraler, lendo, lidos };
            return Ok(collection);
        }

        [HttpGet("{tipo}")]
        public IActionResult Recuperar(TipoListaLeitura tipo)
        {
            Lista listaRecuperada = CriaLista(tipo);
            return Ok(listaRecuperada);
        }
    }
}
