using MediatorWithMaui.ViewModels;

namespace MediatorWithMaui.Views;

public partial class CreateTodoView : ContentPage
{
	public CreateTodoView(CreateTodoViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}