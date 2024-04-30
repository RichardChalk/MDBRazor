using MDBRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MDBRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public MoviesResponse Movies { get; set; }
        public async Task<IActionResult> OnGet()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://moviesdatabase.p.rapidapi.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "7306dc1932msh2d45ff9ccce401ap193e40jsn0c2d7d3d328b");

            HttpResponseMessage response = await client.GetAsync("/titles");
            if (response.IsSuccessStatusCode)
            {
                // Gör om responsen till en sträng
                var responseBody = await response.Content.ReadAsStringAsync();
                // Gör om strängen till vår egen skapade datatyp - MoviesResponse
                Movies = JsonConvert.DeserializeObject<MoviesResponse>(responseBody);
            }
            return Page();
        }
    }
}
