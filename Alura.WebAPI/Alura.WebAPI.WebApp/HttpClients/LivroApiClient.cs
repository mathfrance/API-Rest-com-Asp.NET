using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;

        public LivroApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetCapaLivroAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"livros/{id}/capa");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
        public async Task<LivroApi> GetLivroAsync (int id)
        {            
            HttpResponseMessage response = await _httpClient.GetAsync($"livros/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<LivroApi>();
        }

        public async Task<Lista> GetListaLeituraAsync(TipoListaLeitura tipo)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"listasleitura/{tipo}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Lista>();
        }

        public async Task DeleteLivroAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"livros/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
