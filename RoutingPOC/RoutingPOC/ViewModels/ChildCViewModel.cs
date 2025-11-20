using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class ChildCViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "child-c";
    public IScreen HostScreen { get; }

    public ChildCViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}