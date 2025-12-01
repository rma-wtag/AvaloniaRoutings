using System.Reactive;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class DashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "Dashboard";
    public IScreen HostScreen { get; }
    public ReactiveCommand<string, Unit> NavigateTo { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }

    public DashboardViewModel(IScreen screen)
    {
        HostScreen = screen;
        NavigateTo = ReactiveCommand.Create<string>(pageName =>
            HostScreen.Router.Navigate.Execute(CreateViewModel(pageName, HostScreen)));

        GoBack = ReactiveCommand.Create(() =>
        {
            HostScreen.Router.NavigateBack.Execute();
        });
    }
}