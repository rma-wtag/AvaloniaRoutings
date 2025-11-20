using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RoutingPOC.ViewModels;

namespace RoutingPOC.Views;

public partial class ChildBView : ReactiveUserControl<ChildBViewModel>
{
    public ChildBView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}