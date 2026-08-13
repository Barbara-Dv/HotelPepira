using HotelPepira.Service;

namespace HotelPepira.Views;

public partial class MainPage : ContentPage
{
    private readonly ClimaService _climaService;

    public MainPage()
    {
        InitializeComponent();

        _climaService = new ClimaService();
    }

    // ==============================
    // FAZER HOSPEDAGEM / CHECK-IN
    // ==============================
    private async void OnHospedagemClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Hospedagem());
    }

    // ==============================
    // AVALIAÇÕES
    // ==============================
    private async void OnAvaliacoesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Avaliacoes());
    }

    // ==============================
    // CONTATO
    // ==============================
    private async void OnContatoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Contato());
    }

    // ==============================
    // LOCALIZAÇÃO
    // ==============================
    private async void OnLocalizacaoClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "📍 Localização",
            "Pousada Jacaré Pepira\n\n" +
            "Rua Joaquim Dias Ramos, 75\n" +
            "Bairro do Patrimônio\n" +
            "Brotas – SP\n" +
            "CEP 17390-000",
            "OK");
    }

    // ==============================
    // CONSULTAR CLIMA
    // ==============================
    private async void OnConsultarClimaClicked(object sender, EventArgs e)
    {
        try
        {
            lblClima.Text = "⏳ Consultando clima...";

            string clima = await _climaService.ObterClimaAsync();

            lblClima.Text = clima;
        }
        catch (Exception ex)
        {
            lblClima.Text = $"❌ Erro ao consultar clima:\n{ex.Message}";
        }
    }

    // ==============================
    // CONTRATAR HOTEL
    // ==============================
    private async void OnContratarHotelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Hospedagem());
    }
}