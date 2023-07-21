using MediatorWithMaui.ViewModels;
using MediatR;

namespace MediatorWithMaui.Mediators;

public class RefreshTodoItemsMediator : INotification
{

}

public class RefreshTodoItemsHandler : INotificationHandler<RefreshTodoItemsMediator>
{
    HomeViewModel viewModel;

    public RefreshTodoItemsHandler(HomeViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task Handle(RefreshTodoItemsMediator notification, CancellationToken cancellationToken)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await viewModel.GetTodoItemsCommand.ExecuteAsync(null);
        });

        return Task.CompletedTask;
    }
}
