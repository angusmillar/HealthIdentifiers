using System.Collections.Generic;
using System.Linq;
using HealthIdentifiers.Tool.Enums;

namespace HealthIdentifiers.Tool.ViewModel;

public class ToolVm
{
    public ToolVm()
    {
        IdentifierList = new List<Identifier>
        {
            new Identifier(type: IdentifierType.Dva, displayName: "DVA"),
            new Identifier(type: IdentifierType.MedicareNumber, displayName: "Medicare Number"),
            new Identifier(type: IdentifierType.MedicareProviderNumber, displayName: "Medicare Provider Number"),
            new Identifier(type: IdentifierType.Hpii, displayName: "HPI-I"),
            new Identifier(type: IdentifierType.Hpio, displayName: "HPI-O"),
            new Identifier(type: IdentifierType.Ihi, displayName: "IHI"),
        };
        SelectedIdentifier = IdentifierList.Single(x => x.Type == IdentifierType.MedicareNumber);
    }

    public IEnumerable<Identifier> IdentifierList { get; private set; }
    public Identifier SelectedIdentifier { get; set; }
}