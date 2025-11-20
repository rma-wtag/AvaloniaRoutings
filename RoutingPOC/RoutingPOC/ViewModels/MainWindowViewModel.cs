using System;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();

    public MainWindowViewModel()
    {
        OpenPage("HomeView");
    }
    
    public void OpenPage(string viewName)
    {
        // Convert "HomeView" -> "HomeViewModel"
        string vmName = viewName.Replace("View", "ViewModel");

        var asm = typeof(MainWindowViewModel).Assembly;

        var vmType = asm.GetType($"RoutingPOC.ViewModels.{vmName}");
        if (vmType == null)
            throw new Exception($"ViewModel not found for: {vmName}");

        var vm = (IRoutableViewModel)Activator.CreateInstance(vmType, this)!;

        Router.Navigate.Execute(vm).Subscribe();
    }

    public void ClosePage()
    {
        Router.NavigateBack.Execute().Subscribe();
    }
}