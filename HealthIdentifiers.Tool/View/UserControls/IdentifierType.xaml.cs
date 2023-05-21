using System.Windows;
using System.Windows.Controls;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class IdentifierType : UserControl
{
    public IdentifierType()
    {
        InitializeComponent();
        LayoutRoot.DataContext = this;
    }

    public string FullDisplayName
    {
        get => (string)GetValue(FullDisplayNameProperty);
        set => SetValue(FullDisplayNameProperty, value);
    }

    public string IconFilePath
    {
        get => (string)GetValue(IconFilePathProperty);
        set => SetValue(IconFilePathProperty, value);
    }

    public readonly static DependencyProperty FullDisplayNameProperty =
        DependencyProperty.Register(nameof(FullDisplayName), typeof(string), typeof(IdentifierType), new PropertyMetadata());

    public readonly static DependencyProperty IconFilePathProperty =
        DependencyProperty.Register(nameof(IconFilePath), typeof(string), typeof(IdentifierType), new PropertyMetadata());
}