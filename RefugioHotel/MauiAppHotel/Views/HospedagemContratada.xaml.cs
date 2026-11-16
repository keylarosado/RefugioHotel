using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

[QueryProperty(nameof(Reserva), "Reserva")]
public partial class HospedagemContratada : ContentPage
{
    private Reserva? _reserva;
    public Reserva? Reserva
    {
        get => _reserva;
        set
        {
            _reserva = value;
            if (value is not null) BindingContext = new ResumoReservaViewModel(value);
        }
    }

    public HospedagemContratada() => InitializeComponent();

    private async void OnInicioClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("//MainPage");
}

public class ResumoReservaViewModel
{
    private readonly Reserva _reserva;
    public ResumoReservaViewModel(Reserva reserva) => _reserva = reserva;
    public string Acomodacao => _reserva.Acomodacao;
    public string Hospedes => $"{_reserva.Adultos} adulto(s), {_reserva.Criancas} criança(s)";
    public DateTime Checkin => _reserva.Checkin;
    public DateTime Checkout => _reserva.Checkout;
    public int Noites => _reserva.Noites;
    public decimal Total => _reserva.Total;
}
