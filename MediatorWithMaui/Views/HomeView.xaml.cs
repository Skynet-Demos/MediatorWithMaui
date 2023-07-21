using MediatorWithMaui.ViewModels;

namespace MediatorWithMaui.Views;

public partial class HomeView : ContentPage
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}