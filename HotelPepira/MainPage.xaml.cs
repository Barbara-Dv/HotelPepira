namespace HotelPepira.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnHospedagemClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Hospedagem());
    }

    private async void OnAvaliacoesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Avaliacoes());
    }

    private async void OnContatoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Contato());
    }

    private async void OnLocalizacaoClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Localização",
            "📍 Avenida Paulista, São Paulo - SP",
            "OK");
    }
}