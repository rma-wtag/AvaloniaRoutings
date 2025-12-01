using ReactiveUI;
using System.Reactive;

namespace RoutingPOC.ViewModels;

public class HomeViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "Home";
    public IScreen HostScreen { get; }

    public ReactiveCommand<string, Unit> NavigateTo { get; }

    public HomeViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
        NavigateTo = ReactiveCommand.Create<string>(pageName =>
            HostScreen.Router.Navigate.Execute(CreateViewModel(pageName, HostScreen)));
    }
}