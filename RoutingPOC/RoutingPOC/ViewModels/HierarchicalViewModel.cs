using ReactiveUI;
using System;
using System.Reactive;

namespace RoutingPOC.ViewModels;

public class HierarchicalViewModel : ViewModelBase, IRoutableViewModel , IScreen
{
    public string? UrlPathSegment { get; } = "Hierarchical";
    public IScreen HostScreen { get; }
    
    //child-view routing
    public RoutingState Router { get; } = new();
    public ReactiveCommand<String, Unit> OpenChildPage { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }

    public HierarchicalViewModel(IScreen screen)
    {
        HostScreen = screen;

        OpenChildPage = ReactiveCommand.Create<string>(pageName =>
            Router.Navigate.Execute(CreateViewModel(pageName, this))
        );

        GoBack = ReactiveCommand.Create(() =>
        {
            HostScreen.Router.NavigateBack.Execute();
        });
    }
}