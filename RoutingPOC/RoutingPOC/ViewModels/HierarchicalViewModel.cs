using System;
using System.Reactive;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class HierarchicalViewModel : ViewModelBase, IRoutableViewModel , IScreen
{
    public string? UrlPathSegment { get; } = "Hierarchical";
    public IScreen HostScreen { get; }
    
    //child-view routing
    public RoutingState Router { get; } = new();
    public ReactiveCommand<string, Unit> OpenChildPageCommand { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
    
    public HierarchicalViewModel(IScreen screen)
    {
        HostScreen = screen;
        
        OpenChildPageCommand = ReactiveCommand.Create<string>(pageName =>
        {
            var vm = CreateViewModel(pageName, this);
            Router.Navigate.Execute(vm).Subscribe();
        });
        
        GoBack = ReactiveCommand.Create(() =>
        {
            ((MainWindowViewModel)HostScreen).ClosePage();
        });
        
    }
}