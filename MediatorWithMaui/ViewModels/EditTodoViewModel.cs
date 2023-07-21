using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatorWithMaui.Mediators;
using MediatorWithMaui.Models;
using MediatR;

namespace MediatorWithMaui.ViewModels;

[QueryProperty("Todo", nameof(Models.Todo))]
public partial class EditTodoViewModel : ObservableObject
{
    [ObservableProperty]
    Todo todo;

    IMediator mediator;

    public EditTodoViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [RelayCommand]
    async Task Update()
    {
        await App.TodoRepository.UpdateTodoAsync(Todo);
        await Toast.Make("Todo details are updated!").Show();
        await mediator.Publish(new RefreshTodoItemsMediator());
        await GoBack();
    }

    [RelayCommand]
    async Task Delete()
    {
        var confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure to delete this todo?", "OK", "NO");
        if (confirm)
        {
            await App.TodoRepository.DeleteTodoAsync(Todo);
            await mediator.Publish(new RefreshTodoItemsMediator());
            await GoBack();
        }
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
