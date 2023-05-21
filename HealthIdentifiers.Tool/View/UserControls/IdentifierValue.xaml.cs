using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HealthIdentifiers.Tool.Mvvm;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class IdentifierValue : UserControl
{
    public IdentifierValue()
    {
        InitializeComponent();
        LayoutRoot.DataContext = this;
    }

    public string ValueText
    {
        get => (string)GetValue(ValueTextProperty);
        set => SetValue(ValueTextProperty, value);
    }
    
    public bool IsValueValid
    {
        get => (bool)GetValue(IsValueValidProperty);
        set => SetValue(IsValueValidProperty, value);
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        TextBoxValue.Clear();
        TextBoxValue.Focus();
        BorderValue.BorderBrush = Brushes.LightGray;
        BorderValue.BorderThickness = new Thickness(2);
        
    }

    public readonly static DependencyProperty IsValueValidProperty = 
        DependencyProperty.Register(nameof(IsValueValid), typeof(bool), typeof(IdentifierValue), new PropertyMetadata());
    
    public readonly static DependencyProperty ValueTextProperty = 
        DependencyProperty.Register(nameof(ValueText), typeof(string), typeof(IdentifierValue), new PropertyMetadata());

    private void TextBoxValue_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBlockPlaceHolder.Visibility = string.IsNullOrEmpty(TextBoxValue.Text) ? Visibility.Visible : Visibility.Hidden;
        RaiseEvent(new RoutedEventArgs(EventManagement.OnChangeViewEventIdentifierValue, sender));
        if (IsValueValid)
        {
            BorderValue.BorderBrush = Brushes.GreenYellow;
            BorderValue.BorderThickness = new Thickness(3);
        }
        else
        {
            BorderValue.BorderBrush = Brushes.Maroon;
            BorderValue.BorderThickness = new Thickness(3);
        }

        if (string.IsNullOrEmpty(TextBoxValue.Text))
        {
            BorderValue.BorderBrush = Brushes.LightGray;
            BorderValue.BorderThickness = new Thickness(2);
        }
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        RaiseEvent(new RoutedEventArgs(EventManagement.OnClickGenerateIdentifierValue, sender));
    }
}