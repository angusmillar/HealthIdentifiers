using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using HealthIdentifiers.Tool.Model;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class IdentifierComponents : UserControl
{
  public IdentifierComponents()
  {
    InitializeComponent();
    LayoutRoot.DataContext = this;
  }
  
  public ObservableCollection<IdentifierComponent> ComponentList
  {
    get => (ObservableCollection<IdentifierComponent>)GetValue(IdentifierComponents.ComponentListProperty);
    set => SetValue(IdentifierComponents.ComponentListProperty, value);
  }


  public readonly static DependencyProperty ComponentListProperty = 
    DependencyProperty.Register(nameof(ComponentList), typeof(ObservableCollection<IdentifierComponent>), typeof(IdentifierComponents), new PropertyMetadata());
  
  

}

