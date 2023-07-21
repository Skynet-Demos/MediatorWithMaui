using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatorWithMaui.Mediators;
using MediatorWithMaui.Models;
using MediatR;

namespace MediatorWithMaui.ViewModels;

public partial class CreateTodoViewModel : ObservableObject
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    DateTime duedate;

    IMediator mediator;

    public CreateTodoViewModel(IMediator mediator)
    {
        this.mediator = mediator;
        Duedate = DateTime.Now;
    }

    [RelayCommand]
    public async Task Save()
    {
        var todoItem = new Todo
        {
            Title = Title,
            Description = Description,
            Duedate = Duedate,
            Status = TodoStatus.Inprogress.ToString()
        };

        await App.TodoRepository.AddTodoAsync(todoItem);
        await mediator.Publish(new RefreshTodoItemsMediator());

        await Toast.Make("Todo item has been saved!").Show();
    }
}
