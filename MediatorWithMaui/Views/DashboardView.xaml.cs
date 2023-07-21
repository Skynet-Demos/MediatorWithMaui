using MediatorWithMaui.ViewModels;

namespace MediatorWithMaui.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView(DashboardViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}