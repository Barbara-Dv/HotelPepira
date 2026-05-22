using HotelPepira.Models;
using Microsoft.Maui.ApplicationModel;

namespace HotelPepira.Views;

public partial class Hospedagem : ContentPage
{
    private List<Quarto> quartos = new();

    private double valorOriginal = 0;
    private double valorFinal = 0;

    public Hospedagem()
    {
        InitializeComponent();

        CarregarQuartos();

        pck_quarto.ItemsSource = quartos;

        AtualizarTotal();
    }

    // LISTA DE QUARTOS
    private void CarregarQuartos()
    {
        quartos = new List<Quarto>()
        {
            new Quarto
            {
                Descricao = "Suíte Simples",
                Titulo = "Suíte Simples",
                Imagem = "simples.jpg",
                Valor = 299.90,
                Detalhes = "Quarto aconchegante com cama casal, ventilador e Wi-Fi grátis."
            },

            new Quarto
            {
                Descricao = "Suíte Casal",
                Titulo = "Suíte Casal",
                Imagem = "casal.jpg",
                Valor = 499.90,
                Detalhes = "Suíte romântica com cama queen-size e decoração especial."
            },

            new Quarto
            {
                Descricao = "Suíte Família",
                Titulo = "Suíte Família",
                Imagem = "familia.jpg",
                Valor = 799.90,
                Detalhes = "Quarto amplo ideal para famílias com até 5 pessoas."
            },

            new Quarto
            {
                Descricao = "Suíte Luxo",
                Titulo = "Suíte Luxo",
                Imagem = "luxo.jpg",
                Valor = 1199.90,
                Detalhes = "Suíte completa e vista panorâmica."
            }
        };
    }

    // QUANDO TROCA SUÍTE
    private void pck_quarto_SelectedIndexChanged(object sender, EventArgs e)
    {
        Quarto quarto = pck_quarto.SelectedItem as Quarto;

        if (quarto != null)
        {
            valorOriginal = quarto.Valor;
            valorFinal = valorOriginal;

            AtualizarTotal();
        }
    }

    // AVANÇAR
    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        Quarto quarto = pck_quarto.SelectedItem as Quarto;

        if (quarto == null)
        {
            await DisplayAlert("Atenção", "Selecione uma suíte.", "OK");
            return;
        }

        await Navigation.PushAsync(
            new DetalhesSuite(
                quarto.Titulo,
                quarto.Detalhes,
                quarto.Imagem,
                valorFinal));
    }

    // CUPOM
    private async void OnAplicarCupomClicked(object sender, EventArgs e)
    {
        Quarto quarto = pck_quarto.SelectedItem as Quarto;

        if (quarto == null)
        {
            await DisplayAlert("Atenção", "Selecione uma suíte primeiro.", "OK");
            return;
        }

        valorOriginal = quarto.Valor;
        valorFinal = valorOriginal;

        string cupom = txtCupom.Text;

        if (string.IsNullOrWhiteSpace(cupom))
        {
            await DisplayAlert("Atenção", "Digite um cupom.", "OK");
            return;
        }

        if (cupom.ToUpper() == "BROTAS10")
        {
            valorFinal = valorOriginal * 0.90;

            await DisplayAlert("Cupom aplicado", "10% de desconto aplicado!", "OK");
        }
        else
        {
            await DisplayAlert("Cupom inválido", "Cupom não encontrado.", "OK");
        }

        AtualizarTotal();
    }

    // TOTAL
    private void AtualizarTotal()
    {
        lblTotal.Text = $"R$ {valorFinal:N2}";
    }

    // VOLTAR
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // TEMA
    private void switchTema_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            App.Current.UserAppTheme = AppTheme.Dark;
            BackgroundColor = Colors.Black;
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Light;
            BackgroundColor = Color.FromArgb("#d8b952");
        }
    }

    // WHATSAPP
    private async void ContatoWhatsApp_Clicked(object sender, EventArgs e)
    {
        string numero = "5514999999999";

        string mensagem = "Olá! Gostaria de informações sobre a pousada.";

        string url =
            $"https://wa.me/{numero}?text={Uri.EscapeDataString(mensagem)}";

        await Launcher.Default.OpenAsync(url);
    }
}