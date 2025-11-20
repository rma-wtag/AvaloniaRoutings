using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class HomeViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "home";
    public IScreen HostScreen { get; }

    public ReactiveCommand<string, Unit> OpenPageCommand { get; }

    public HomeViewModel(IScreen screen)
    {
        HostScreen = screen;

        OpenPageCommand = ReactiveCommand.Create<string>(viewName =>
        {
            ((MainWindowViewModel)HostScreen).OpenPage(viewName);
        });
    }
}