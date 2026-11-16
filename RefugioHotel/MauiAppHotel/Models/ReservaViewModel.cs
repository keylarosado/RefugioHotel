using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppHotel.Models;

public class ReservaViewModel : INotifyPropertyChanged
{
    private DateTime _checkin = DateTime.Today.AddDays(7);
    private DateTime _checkout = DateTime.Today.AddDays(9);
    private Acomodacao? _acomodacaoSelecionada;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ReservaViewModel()
    {
        _acomodacaoSelecionada = Acomodacoes.First();
    }
    public DateTime Hoje => DateTime.Today;
    public DateTime Checkin
    {
        get => _checkin;
        set
        {
            if (_checkin == value) return;
            _checkin = value;
            if (_checkout <= _checkin) _checkout = _checkin.AddDays(1);
            OnPropertyChanged();
            OnPropertyChanged(nameof(DataMinimaCheckout));
            OnPropertyChanged(nameof(ResumoPeriodo));
        }
    }
    public DateTime Checkout
    {
        get => _checkout;
        set
        {
            if (_checkout == value) return;
            _checkout = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ResumoPeriodo));
        }
    }
    public DateTime DataMinimaCheckout => Checkin.AddDays(1);
    public string ResumoPeriodo => $"{Math.Max(1, (Checkout.Date - Checkin.Date).Days)} noite(s) selecionada(s)";
    public ObservableCollection<Acomodacao> Acomodacoes { get; } = new()
    {
        new() { Nome = "Suíte Conforto", Descricao = "Ambiente acolhedor para descansar.", Diaria = 280m },
        new() { Nome = "Suíte Jardim", Descricao = "Mais espaço e vista para o jardim.", Diaria = 350m },
        new() { Nome = "Suíte Família", Descricao = "Conforto para viajar em família.", Diaria = 420m }
    };
    public Acomodacao? AcomodacaoSelecionada
    {
        get => _acomodacaoSelecionada;
        set
        {
            _acomodacaoSelecionada = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ValorEstimado));
        }
    }
    public decimal ValorEstimado => AcomodacaoSelecionada?.Diaria ?? Acomodacoes.First().Diaria;

    public void AtualizarDatas(DateTime checkin, DateTime checkout)
    {
        Checkin = checkin;
        Checkout = checkout;
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
