using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatorWithMaui.Models;
using MediatorWithMaui.Views;
using System.Collections.ObjectModel;

namespace MediatorWithMaui.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Todo> todoItems;

    public HomeViewModel()
    {
        TodoItems = new ObservableCollection<Todo>();
        GetTodoItems();
    }

    [RelayCommand]
    public async Task Tap(Todo todo)
    {
        await Shell.Current.GoToAsync($"{nameof(EditTodoView)}",
            new Dictionary<string, object>
            {
                { nameof(Todo), todo }
            });
    }

    [RelayCommand]
    public async Task GetTodoItems()
    {
        var rawData = await App.TodoRepository.GetAllTodosAsync();
        MapToObservableCollection(rawData);
    }

    private void MapToObservableCollection(List<Todo> todos)
    {
        TodoItems.Clear();
        foreach (var item in todos)
        {
            TodoItems.Add(item);
        }
    }
}
