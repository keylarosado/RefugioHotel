namespace MauiAppHotel;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.HospedagemContratada), typeof(Views.HospedagemContratada));
    }
}
