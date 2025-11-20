using System.Reactive;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class DashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "dashboard";
    public IScreen HostScreen { get; }
    public ReactiveCommand<string, Unit> OpenPageCommand { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }

    public DashboardViewModel(IScreen screen)
    {
        HostScreen = screen;
        OpenPageCommand = ReactiveCommand.Create<string>(viewName =>
        {
            ((MainWindowViewModel)HostScreen).OpenPage(viewName);
        });
        GoBack = ReactiveCommand.Create(() =>
        {
            ((MainWindowViewModel)HostScreen).ClosePage();
        });
    }
}