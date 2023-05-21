using System.Windows;
using System.Windows.Controls;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class ValuePair : UserControl
{
  public ValuePair()
  {
    InitializeComponent();
    LayoutRoot.DataContext = this;
  }
  
  public string ValueName
  {
    get => (string)GetValue(ValueNameProperty);
    set => SetValue(ValueNameProperty, value);
  }
  
  public string Value
  {
    get => (string)GetValue(ValueTestProperty);
    set => SetValue(ValueTestProperty, value);
  }
  
  public readonly static DependencyProperty ValueNameProperty = 
    DependencyProperty.Register(nameof(ValueName), typeof(string), typeof(ValuePair), new PropertyMetadata());
  
  public readonly static DependencyProperty ValueTestProperty = 
    DependencyProperty.Register(nameof(Value), typeof(string), typeof(ValuePair), new PropertyMetadata());
}

