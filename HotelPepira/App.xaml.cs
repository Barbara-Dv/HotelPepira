using HotelPepira.Data;
using HotelPepira.Models;

namespace HotelPepira;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        using (var db = new HotelDbContext())
        {
            db.Database.EnsureCreated();

            if (!db.Quartos.Any())
            {
                db.Quartos.AddRange(
                    new Quarto
                    {
                        Descricao = "Suíte Econômica",
                        Titulo = "Suíte Econômica",
                        Imagem = "simples.jpg",
                        Valor = 399.00,
                        Detalhes =
                            "Acomodação aconchegante da Pousada Jacaré Pepira, " +
                            "ideal para uma estadia tranquila em Brotas. " +
                            "Conta com ar-condicionado, TV digital, frigobar, " +
                            "roupa de cama e toalhas. " +
                            "Café da manhã incluso na diária."
                    },

                    new Quarto
                    {
                        Descricao = "Suíte Casal",
                        Titulo = "Suíte Casal",
                        Imagem = "casal.jpg",
                        Valor = 489.00,
                        Detalhes =
                            "Acomodação confortável para casal, com ambiente acolhedor " +
                            "e tranquilo. Conta com ar-condicionado, TV digital, " +
                            "frigobar, roupa de cama e toalhas. " +
                            "Café da manhã incluso na diária."
                    },

                    new Quarto
                    {
                        Descricao = "Suíte Conforto",
                        Titulo = "Suíte Conforto",
                        Imagem = "conforto.jpg",
                        Valor = 549.00,
                        Detalhes =
                            "Acomodação espaçosa e confortável para aproveitar sua " +
                            "estadia em Brotas. Possui ar-condicionado, TV digital, " +
                            "frigobar, roupa de cama e toalhas. " +
                            "Café da manhã incluso na diária."
                    },

                    new Quarto
                    {
                        Descricao = "Suíte Família",
                        Titulo = "Suíte Família",
                        Imagem = "familia.jpg",
                        Valor = 649.00,
                        Detalhes =
                            "Acomodação ideal para famílias e grupos que procuram " +
                            "mais espaço e conforto. Conta com ar-condicionado, " +
                            "TV digital, frigobar, roupa de cama e toalhas. " +
                            "Café da manhã incluso na diária."
                    }
                );

                db.SaveChanges();
            }
        }

        MainPage = new NavigationPage(new AppShell());
    }
}