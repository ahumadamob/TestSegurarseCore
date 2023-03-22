using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TestSegurarseCore.Models;
using TestSegurarseCore.Services.Interfaces;

namespace TestSegurarseCore.Services.Implementations
{
    public class TestEncryptService : ITestEncriptService
    {
        public async Task<string> Test(Persona persona)
        {
            try
            {
                var _httpClient = new HttpClient();
                var json = JsonSerializer.Serialize(persona);
                var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, "https://segurarse.com.ar/qa/pruebas/testencrypt");
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(persona.nombre + persona.apellido);
                string base64 = Convert.ToBase64String(bytes);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(base64);
                request.Content = stringContent;

                var response = await _httpClient.SendAsync(request);
                var readData = await response.Content.ReadAsStringAsync();
                return readData;
            }catch (Exception ex)
            {
                ApiResponse apiResponse = new ApiResponse
                {

                    result = ex.Message
                };
                return JsonSerializer.Serialize(apiResponse);                
            }
            

        }
    }
}
