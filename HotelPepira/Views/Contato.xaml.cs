namespace HotelPepira.Views;

public partial class Contato : ContentPage
{
    public Contato()
    {
        InitializeComponent();
    }

    private async void OnTelefoneClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Telefone",
            "(11) 99999-9999",
            "OK");
    }

    private async void OnWhatsAppClicked(object sender, EventArgs e)
    {
        await DisplayAlert("WhatsApp",
            "WhatsApp conectado com sucesso!",
            "OK");
    }

    private async void OnSiteClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.jacarepepira.com.br/");
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}