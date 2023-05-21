using HealthIdentifiers.Tool.Mvvm;
namespace HealthIdentifiers.Tool.Model;

public class IdentifierComponent : ViewModelBase
{
    private string _name;
    private string _value;
    public IdentifierComponent(string name,
                               string value)
    {
        _name = name;
        _value = value;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == _name)
                return;
            _name = value;
            OnPropertyChanged();
        }
    }
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
}