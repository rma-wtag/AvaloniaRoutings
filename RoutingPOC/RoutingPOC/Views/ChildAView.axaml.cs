using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RoutingPOC.ViewModels;

namespace RoutingPOC.Views;

public partial class ChildAView : ReactiveUserControl<ChildAViewModel>
{
    public ChildAView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
    
}