namespace MauiAppHotel.Models;

public class Reserva
{
    public int Adultos { get; set; }
    public int Criancas { get; set; }
    public string Acomodacao { get; set; } = "";
    public DateTime Checkin { get; set; }
    public DateTime Checkout { get; set; }
    public decimal ValorDiaria { get; set; }
    public int Noites => Math.Max(1, (Checkout.Date - Checkin.Date).Days);
    public decimal Total => ValorDiaria * Noites;
}
