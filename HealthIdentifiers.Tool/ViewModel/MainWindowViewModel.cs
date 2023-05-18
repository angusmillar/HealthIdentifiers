using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HealthIdentifiers.Tool.Enums;
using HealthIdentifiers.Tool.Model;
using HealthIdentifiers.Tool.Mvvm;
using HealthIdentifiers.Tool.View.UserControls;

namespace HealthIdentifiers.Tool.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        IdentifierList = new ObservableCollection<Identifier>
        {
            //new Identifier(type: IdentifierType.Dva, displayName: "DVA"),
            new MedicareNumberIdentifier(),
            //new Identifier(type: IdentifierType.MedicareProviderNumber, displayName: "Medicare Provider Number"),
            //new Identifier(type: IdentifierType.Hpii, displayName: "HPI-I"),
            //new Identifier(type: IdentifierType.Hpio, displayName: "HPI-O"),
            //new Identifier(type: IdentifierType.Ihi, displayName: "IHI"),
        };
        _SelectedIdentifier = IdentifierList.Single(x => x.Type == IdentifierType.MedicareNumber);
    }

    public ObservableCollection<Identifier> IdentifierList { get; private set; }
    
    private Identifier _SelectedIdentifier;
    public Identifier SelectedIdentifier
    {
        get => _SelectedIdentifier;
        set
        {
            _SelectedIdentifier = value;
            OnPropertyChanged();
        }
    }

    public void ValidateIdentifierValue()
    {
        
    }
    
}