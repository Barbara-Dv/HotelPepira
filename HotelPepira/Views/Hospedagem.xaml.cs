using HotelPepira.Data;
using HotelPepira.Models;
using Microsoft.Maui.ApplicationModel;

namespace HotelPepira.Views;

public partial class Hospedagem : ContentPage
{
    private List<Quarto> quartos = new();

    private double valorOriginal = 0;
    private double valorFinal = 0;


    // =========================================================
    // CONSTRUTOR
    // =========================================================

    public Hospedagem()
    {
        InitializeComponent();

        CarregarQuartos();

        pck_quarto.ItemsSource = quartos;

        AtualizarTotal();
    }


    // =========================================================
    // LISTA DE ACOMODAÇÕES - BANCO DE DADOS
    // =========================================================

    private void CarregarQuartos()
    {
        using (var db = new HotelDbContext())
        {
            quartos = db.Quartos.ToList();
        }
    }


    // =========================================================
    // QUANDO TROCA ACOMODAÇÃO
    // =========================================================

    private void pck_quarto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is not Quarto quarto)
            return;

        valorOriginal = quarto.Valor;
        valorFinal = valorOriginal;

        // Limpa o cupom ao trocar de acomodação
        if (txtCupom != null)
        {
            txtCupom.Text = string.Empty;
        }

        AtualizarTotal();
    }


    // =========================================================
    // AVANÇAR PARA OS DETALHES
    // =========================================================

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is not Quarto quarto)
        {
            await DisplayAlert(
                "Atenção",
                "Selecione uma acomodação para continuar.",
                "OK");

            return;
        }

        await Navigation.PushAsync(
            new DetalhesSuite(
                quarto.Titulo,
                quarto.Detalhes,
                quarto.Imagem,
                valorFinal));
    }


    // =========================================================
    // APLICAR CUPOM
    // =========================================================

    private async void OnAplicarCupomClicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is not Quarto quarto)
        {
            await DisplayAlert(
                "Atenção",
                "Selecione uma acomodação primeiro.",
                "OK");

            return;
        }

        string cupom = txtCupom.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(cupom))
        {
            await DisplayAlert(
                "Atenção",
                "Digite um cupom de desconto.",
                "OK");

            return;
        }

        valorOriginal = quarto.Valor;

        if (cupom.Equals(
                "BROTAS10",
                StringComparison.OrdinalIgnoreCase))
        {
            valorFinal = valorOriginal * 0.90;

            await DisplayAlert(
                "Cupom aplicado",
                "10% de desconto aplicado com sucesso!",
                "OK");
        }
        else
        {
            valorFinal = valorOriginal;

            await DisplayAlert(
                "Cupom inválido",
                "O cupom informado não está disponível.",
                "OK");
        }

        AtualizarTotal();
    }


    // =========================================================
    // ATUALIZAR TOTAL
    // =========================================================

    private void AtualizarTotal()
    {
        if (lblTotal == null)
            return;

        if (valorFinal <= 0)
        {
            lblTotal.Text = "R$ 0,00";
            return;
        }

        lblTotal.Text = $"R$ {valorFinal:N2}";
    }


    // =========================================================
    // VOLTAR
    // =========================================================

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            await Navigation.PopAsync();
        }
    }


    // =========================================================
    // TEMA
    // =========================================================

    private void switchTema_Toggled(object sender, ToggledEventArgs e)
    {
        if (App.Current == null)
            return;

        if (e.Value)
        {
            App.Current.UserAppTheme = AppTheme.Dark;

            BackgroundColor = Colors.Black;
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Light;

            // Cor creme da paleta da Pousada
            BackgroundColor = Color.FromArgb("#F4EBD0");
        }
    }


    // =========================================================
    // WHATSAPP
    // =========================================================

    private async void ContatoWhatsApp_Clicked(object sender, EventArgs e)
    {
        await AbrirWhatsApp();
    }


    // =========================================================
    // ABRIR WHATSAPP
    // =========================================================

    private async Task AbrirWhatsApp()
    {
        const string numero = "5514991624478";

        const string mensagem =
            "Olá! Gostaria de informações sobre disponibilidade, " +
            "valores e reserva na Pousada Jacaré Pepira.";

        string url =
            $"https://wa.me/{numero}?text={Uri.EscapeDataString(mensagem)}";

        try
        {
            await Launcher.Default.OpenAsync(url);
        }
        catch
        {
            await DisplayAlert(
                "WhatsApp",
                "Não foi possível abrir o WhatsApp neste dispositivo.",
                "OK");
        }
    }
}