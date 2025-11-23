using System;
using ReactiveUI;

namespace RoutingPOC.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected IRoutableViewModel CreateViewModel(string viewName, IScreen hostScreen)
    {
        string vmName = viewName.Replace("View", "ViewModel");

        var asm = typeof(ViewModelBase).Assembly;
        var vmType = asm.GetType($"RoutingPOC.ViewModels.{vmName}");

        if (vmType == null)
            throw new Exception($"ViewModel not found: {vmName}");

        return (IRoutableViewModel)Activator.CreateInstance(vmType, hostScreen)!;
    }
}
