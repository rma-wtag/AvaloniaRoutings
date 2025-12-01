using ReactiveUI;
using System;

namespace RoutingPOC.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();

    public MainWindowViewModel()
    {
        NavigateTo("Home");
    }

    public void NavigateTo(string pageName)
    {
        var vm = CreateViewModel(pageName, this);
        Router.Navigate.Execute(vm);
    }
}