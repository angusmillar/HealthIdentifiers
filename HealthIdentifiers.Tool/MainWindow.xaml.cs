using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HealthIdentifiers.Tool.Enums;
using HealthIdentifiers.Tool.Mvvm;
using HealthIdentifiers.Tool.View.UserControls;
using HealthIdentifiers.Tool.ViewModel;

namespace HealthIdentifiers.Tool
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly MainWindowViewModel _mainWindowViewModel;
    public MainWindow()
    {

      InitializeComponent();
      _mainWindowViewModel = new MainWindowViewModel();
      DataContext = _mainWindowViewModel;

      AddHandler(EventManagement.OnChangeViewEventIdentifierValue, new RoutedEventHandler(OnChangeViewEventIdentifierValue));
      AddHandler(EventManagement.OnClickGenerateIdentifierValue, new RoutedEventHandler(OnClickGenerateIdentifierValue));
    }

    private void OnChangeViewEventIdentifierValue(object sender, RoutedEventArgs routedEventArgs)
    {
      
      if (routedEventArgs.Source is IdentifierValue identifierValue)
      {
        int oldIndex = identifierValue.TextBoxValue.CaretIndex;  
        //_mainWindowViewModel.SelectedIdentifier.Value = identifierValue.TextBoxValue.Text.Replace(" ", string.Empty);
        _mainWindowViewModel.SelectedIdentifier.Validate(identifierValue.TextBoxValue.Text);
        identifierValue.TextBoxValue.CaretIndex = oldIndex;
      }
      else
      {
        throw new EventSourceException(nameof(EventManagement.OnChangeViewEventIdentifierValue));
      }

    }
    private void OnClickGenerateIdentifierValue(object sender, RoutedEventArgs e)
    {
      _mainWindowViewModel.SelectedIdentifier.GenerateRandomIdentifier();
    }
  }
}
