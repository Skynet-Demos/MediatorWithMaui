using MediatorWithMaui.Models;
using MediatorWithMaui.ViewModels;
using MediatR;

namespace MediatorWithMaui.Mediators;

public class GetCountRequest : IRequest<int>
{
    public TodoStatus Status { get; set; }
}

public class GetCountHandler : IRequestHandler<GetCountRequest, int>
{
    HomeViewModel viewModel;

    public GetCountHandler(HomeViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task<int> Handle(GetCountRequest request, CancellationToken cancellationToken)
    {
        var itemsCount = viewModel.TodoItems.Where(item => item.Status == request.Status.ToString()).Count();
        return Task.FromResult(itemsCount);
    }
}
