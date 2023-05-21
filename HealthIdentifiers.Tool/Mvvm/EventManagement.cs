using System.Windows;
using HealthIdentifiers.Tool.View.UserControls;

namespace HealthIdentifiers.Tool.Mvvm;

public static class EventManagement
{
    public static readonly RoutedEvent OnChangeViewEventIdentifierValue = EventManager.RegisterRoutedEvent(nameof(OnChangeViewEventIdentifierValue), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IdentifierValue));
    public static readonly RoutedEvent OnClickGenerateIdentifierValue = EventManager.RegisterRoutedEvent(nameof(OnClickGenerateIdentifierValue), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IdentifierValue));
}