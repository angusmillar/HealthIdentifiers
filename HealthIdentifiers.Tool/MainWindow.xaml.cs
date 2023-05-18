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
        private readonly MainWindowViewModel _MainWindowViewModel;
        public MainWindow()
        {
            
            InitializeComponent();
            _MainWindowViewModel = new MainWindowViewModel();
            DataContext = _MainWindowViewModel;
            
            AddHandler(EventManagement.OnChangeViewEventIdentifierValue, new RoutedEventHandler(SomeControl_ChangeView));
        }
        
        private void SomeControl_ChangeView(object sender, RoutedEventArgs routedEventArgs)
        {
            if (routedEventArgs.Source is IdentifierValue identifierValue)
            {
                _MainWindowViewModel.SelectedIdentifier.Value = identifierValue.TextBoxValue.Text;
            }
            else
            {
                throw new EventSourceException(nameof(EventManagement.OnChangeViewEventIdentifierValue));
            }
            
            
        }
    }
}