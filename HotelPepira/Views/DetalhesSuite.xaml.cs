namespace HotelPepira.Views;

public partial class DetalhesSuite : ContentPage
{
    public DetalhesSuite(string titulo,
                         string descricao,
                         string imagem,
                         double valor)
    {
        InitializeComponent();

        // DADOS RECEBIDOS
        lblTitulo.Text = titulo;

        lblDescricao.Text = descricao;

        imgSuite.Source = imagem;

        lblValor.Text = $"R$ {valor:F2} / noite";
    }

    // RESERVAR
    private async void OnReservarClicked(object sender, EventArgs e)
    {
        bool resposta = await DisplayAlert(
            "Confirmar Reserva",
            "Deseja continuar para a reserva?",
            "Sim",
            "Cancelar");

        if (resposta)
        {
            await Navigation.PushAsync(new Contato());
        }
    }

    // VOLTAR
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // ANIMAÇÃO AO ABRIR
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        this.Opacity = 0;

        await this.FadeTo(1, 800);
    }
}