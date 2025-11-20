using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class ChildAViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment => "child-a";
    public IScreen HostScreen { get; }

    public ChildAViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}