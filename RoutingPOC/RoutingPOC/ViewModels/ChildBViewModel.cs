using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class ChildBViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "child-b";
    public IScreen HostScreen { get; }

    public ChildBViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}