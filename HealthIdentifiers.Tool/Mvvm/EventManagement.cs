using System.Windows;
using HealthIdentifiers.Tool.View.UserControls;

namespace HealthIdentifiers.Tool.Mvvm;

public static class EventManagement
{
    public static readonly RoutedEvent OnChangeViewEventIdentifierValue = EventManager.RegisterRoutedEvent(nameof(OnChangeViewEventIdentifierValue), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(IdentifierValue));
}