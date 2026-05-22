namespace HotelPepira.Views;

public partial class Avaliacoes : ContentPage
{
    public Avaliacoes()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}