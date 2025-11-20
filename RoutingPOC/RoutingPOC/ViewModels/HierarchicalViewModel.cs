using System;
using System.Reactive;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class HierarchicalViewModel : ViewModelBase, IRoutableViewModel , IScreen
{
    public string? UrlPathSegment { get; } = "Hierarchical";
    public IScreen HostScreen { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
    
    // Child router — dedicated region
    public RoutingState Router { get; } = new();
    public ReactiveCommand<string, Unit> OpenChildPageCommand { get; }
    
    public HierarchicalViewModel(IScreen screen)
    {
        HostScreen = screen;
        
        OpenChildPageCommand = ReactiveCommand.Create<string>(pageName =>
        {
            // Convert View name to ViewModel name
            string vmName = pageName.Replace("View", "ViewModel");

            var asm = typeof(HierarchicalViewModel).Assembly;
            var vmType = asm.GetType($"RoutingPOC.ViewModels.{vmName}");

            var vm = (IRoutableViewModel)Activator.CreateInstance(vmType, this)!;
            Router.Navigate.Execute(vm).Subscribe();
        });
        
        GoBack = ReactiveCommand.Create(() =>
        {
            ((MainWindowViewModel)HostScreen).ClosePage();
        });
        
    }
}