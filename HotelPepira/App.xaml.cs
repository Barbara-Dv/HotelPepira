using HotelPepira.Data;

namespace HotelPepira;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        using (var db = new HotelDbContext())
        {
            db.Database.EnsureCreated();
        }

        MainPage = new NavigationPage(new AppShell());
    }
}