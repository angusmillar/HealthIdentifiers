using System.Collections.ObjectModel;
using HealthIdentifiers.Tool.Enums;
using HealthIdentifiers.Tool.Mvvm;

namespace HealthIdentifiers.Tool.Model;

public abstract class Identifier : ViewModelBase
{
    private string _value;
    private bool _isValid;
    protected Identifier(IdentifierType type, string displayName)
    {
        Type = type;
        DisplayName = displayName;
        ComponentList = new ObservableCollection<IdentifierComponent>();
        _value = string.Empty;
    }
    public IdentifierType Type { get; set; }
    public string DisplayName { get; set; }
    public ObservableCollection<IdentifierComponent> ComponentList { get; set; }
    public string Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value == _value)
                return;
            _value = value;
            OnPropertyChanged();
        }
    }
    public bool IsValid
    {
        get
        {
            return _isValid;
        }
        set
        {
            if (value == _isValid)
                return;
            _isValid = value;
            OnPropertyChanged();
        }
    }
    protected void SetValidIdentifier()
    {
        SetIdentifierComponents();
        IsValid = true;
        if (!Value.Equals(FormattedIdentifierValue()))
        {
            Value = FormattedIdentifierValue();
        }
    }
    protected void SetInValidIdentifier(string value)
    {
        SetIdentifierComponents();
        this.IsValid = false;
        Value = value;
    }
    public abstract bool Validate(string value);
    public abstract void GenerateRandomIdentifier();
    public abstract string FormattedIdentifierValue();
    public abstract void SetIdentifierComponents();

}