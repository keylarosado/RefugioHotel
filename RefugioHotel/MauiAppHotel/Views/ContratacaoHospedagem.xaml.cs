using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private readonly ReservaViewModel _viewModel = new();

    public ContratacaoHospedagem()
    {
        InitializeComponent();
        BindingContext = _viewModel;

        pckQuarto.SelectedIndexChanged += (_, _) =>
        {
            _viewModel.AcomodacaoSelecionada = pckQuarto.SelectedItem as Acomodacao;
        };

        dtpCheckin.DateSelected += (_, _) =>
        {
            DateTime checkin = dtpCheckin.Date ?? _viewModel.Checkin;
            DateTime checkout = dtpCheckout.Date ?? _viewModel.Checkout;

            if (checkout <= checkin)
            {
                checkout = checkin.AddDays(1);
                dtpCheckout.Date = checkout;
            }

            _viewModel.AtualizarDatas(checkin, checkout);
        };

        dtpCheckout.DateSelected += (_, _) =>
        {
            DateTime checkin = dtpCheckin.Date ?? _viewModel.Checkin;
            DateTime checkout = dtpCheckout.Date ?? _viewModel.Checkout;

            _viewModel.AtualizarDatas(checkin, checkout);
        };
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        DateTime checkin = dtpCheckin.Date ?? _viewModel.Checkin;
        DateTime checkout = dtpCheckout.Date ?? _viewModel.Checkout;

        if (checkout <= checkin)
        {
            await DisplayAlert("Atenção", "A data de check-out deve ser posterior ao check-in.", "OK");
            return;
        }

        var reserva = new Reserva
        {
            Adultos = (int)stpAdultos.Value,
            Criancas = (int)stpCriancas.Value,
            Acomodacao = _viewModel.AcomodacaoSelecionada?.Nome ?? "Suíte Conforto",
            Checkin = checkin,
            Checkout = checkout,
            ValorDiaria = _viewModel.ValorEstimado
        };

        await Shell.Current.GoToAsync(nameof(HospedagemContratada), new Dictionary<string, object>
        {
            ["Reserva"] = reserva
        });
    }
}
