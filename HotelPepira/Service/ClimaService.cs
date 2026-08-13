using System.Text.Json;

namespace HotelPepira.Service
{
    internal class ClimaService
    {
        private readonly HttpClient _httpClient;

        public ClimaService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ObterClimaAsync()
        {
            // Brotas - SP
            string url =
                "https://api.open-meteo.com/v1/forecast" +
                "?latitude=-22.2842" +
                "&longitude=-48.1260" +
                "&current=temperature_2m,windspeed_10m" +
                "&timezone=America%2FSao_Paulo";

            try
            {
                var resposta = await _httpClient.GetAsync(url);

                resposta.EnsureSuccessStatusCode();

                string json = await resposta.Content.ReadAsStringAsync();

                using JsonDocument documento = JsonDocument.Parse(json);

                JsonElement current =
                    documento.RootElement.GetProperty("current");

                double temperatura =
                    current.GetProperty("temperature_2m").GetDouble();

                double vento =
                    current.GetProperty("windspeed_10m").GetDouble();

                return
                    $"📍 Brotas - SP\n\n" +
                    $"🌡️ Temperatura: {temperatura:F1} °C\n" +
                    $"💨 Vento: {vento:F1} km/h";
            }
            catch (HttpRequestException ex)
            {
                return $"❌ Erro de conexão com a API:\n{ex.Message}";
            }
            catch (JsonException)
            {
                return "❌ Erro ao interpretar os dados da API.";
            }
            catch (Exception ex)
            {
                return $"❌ Erro ao consultar clima:\n{ex.Message}";
            }
        }
    }
}