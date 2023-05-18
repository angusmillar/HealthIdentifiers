using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using HealthIdentifiers.Tool.Mvvm;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class IdentifierValue : UserControl
{
    public IdentifierValue()
    {
        InitializeComponent();
    }

    public string ValueText
    {
        get => (string)GetValue(ValueTextProperty);
        set => SetValue(ValueTextProperty, value);
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        TextBoxValue.Clear();
        TextBoxValue.Focus();
    }

    public static readonly DependencyProperty ValueTextProperty = 
        DependencyProperty.Register(nameof(ValueText), typeof(string), typeof(IdentifierValue), new PropertyMetadata());

    private void TextBoxValue_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBlockPlaceHolder.Visibility = string.IsNullOrEmpty(TextBoxValue.Text) ? Visibility.Visible : Visibility.Hidden;
        RaiseEvent(new RoutedEventArgs(EventManagement.OnChangeViewEventIdentifierValue, sender));
        
    }
}