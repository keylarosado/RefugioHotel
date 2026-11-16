namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    public MainPage() => InitializeComponent();

    private async void OnReserveClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//ContratacaoHospedagem");
}
