using System.Collections.ObjectModel;
using System.Linq;
using HealthIdentifiers.Tool.Enums;
using HealthIdentifiers.Tool.Model;
using HealthIdentifiers.Tool.Mvvm;

namespace HealthIdentifiers.Tool.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        IdentifierList = new ObservableCollection<Identifier>
        {
            new MedicareNumberIdentifier(),
            new MedicareProviderNumberIdentifier(),
            new DvaIdentifier(),
            new IhiIdentifier(),
            new HpiiIdentifier(),
            new HpioIdentifier()
        };
        _selectedIdentifier = IdentifierList.Single(x => x.Type == IdentifierType.MedicareNumber);
        _isValid = false;
    }
    
    public ObservableCollection<Identifier> IdentifierList { get; private set; }
    
    private Identifier _selectedIdentifier;
    private bool _isValid;
    public Identifier SelectedIdentifier
    {
        get => _selectedIdentifier;
        set
        {
            _selectedIdentifier = value;
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
}