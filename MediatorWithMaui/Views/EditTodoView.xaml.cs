using MediatorWithMaui.ViewModels;

namespace MediatorWithMaui.Views;

public partial class EditTodoView : ContentPage
{
	public EditTodoView(EditTodoViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}