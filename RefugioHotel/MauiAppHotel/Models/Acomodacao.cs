namespace MauiAppHotel.Models;

public class Acomodacao
{
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
    public decimal Diaria { get; set; }
    public override string ToString() => Nome;
}
