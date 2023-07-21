using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatorWithMaui.Mediators;
using MediatR;

namespace MediatorWithMaui.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    IMediator mediator;

    public DashboardViewModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [RelayCommand]
    public async Task GetInprogressItemsCount()
    {
        var count = await mediator.Send(new GetCountRequest { Status = Models.TodoStatus.Inprogress });
        await Shell.Current.DisplayAlert("Count", $"In-progress items: {count}", "OK");
    }

    [RelayCommand]
    public async Task GetCompletedItemsCount()
    {
        var count = await mediator.Send(new GetCountRequest { Status = Models.TodoStatus.Completed });
        await Shell.Current.DisplayAlert("Count", $"Completed items: {count}", "OK");
    }
}
