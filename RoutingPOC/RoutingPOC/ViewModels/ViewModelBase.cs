using ReactiveUI;
using System;

namespace RoutingPOC.ViewModels;

public class ViewModelBase : ReactiveObject
{

    protected IRoutableViewModel CreateViewModel(string pageName, IScreen hostScreen)
    {
        return pageName switch
        {
            "Home" => new HomeViewModel(hostScreen),
            "Dashboard" => new DashboardViewModel(hostScreen),
            "Hierarchical" => new HierarchicalViewModel(hostScreen),
            "ChildA" => new ChildAViewModel(hostScreen),
            "ChildB" => new ChildBViewModel(hostScreen),
            "ChildC" => new ChildCViewModel(hostScreen),
            _ => throw new ArgumentException($"Unsupported page name string: {pageName}")
        };
    }
}