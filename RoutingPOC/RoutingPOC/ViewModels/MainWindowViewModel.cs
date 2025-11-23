using System;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();

    public MainWindowViewModel()
    {
        OpenPage("HomeView");
    }
    
    public void OpenPage(string viewName)
    {
        var vm = CreateViewModel(viewName, this);
        Router.Navigate.Execute(vm).Subscribe();
    }

    public void ClosePage()
    {
        Router.NavigateBack.Execute().Subscribe();
    }
}