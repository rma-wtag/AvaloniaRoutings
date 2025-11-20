using System;
using ReactiveUI;
using RoutingPOC.ViewModels;
using RoutingPOC.Views;

namespace RoutingPOC;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null)
    {
        var vmType = viewModel.GetType();
        var viewTypeName = vmType.FullName!.Replace("ViewModel", "View");

        var viewType = Type.GetType(viewTypeName);
        if (viewType == null)
            throw new Exception($"View not found for {vmType.FullName}");

        return (IViewFor)Activator.CreateInstance(viewType)!;
    }
}