using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HealthIdentifiers.Tool.Enums;
using HealthIdentifiers.Tool.Model;

namespace HealthIdentifiers.Tool.View.UserControls;

public partial class IdentifierSelector : UserControl
{
  public IdentifierSelector()
  {
    InitializeComponent();
  }

  private void Selector_OnSelectionChanged(object sender,
    SelectionChangedEventArgs e)
  {
    // string sourcePath = @"/Images/hpi-i.png";
    // if (ComboBoxSelect.SelectedItem is Identifier identifier)
    // {
    //   switch (identifier.Type)
    //   {
    //     case IdentifierType.MedicareNumber:
    //       sourcePath = @"/Images/medicare-card.png";
    //       break;
    //     case IdentifierType.MedicareProviderNumber:
    //       sourcePath = @"/Images/hpi-i.png";
    //       break;
    //     case IdentifierType.Dva:
    //       sourcePath = @"/Images/doctor-female..png";
    //       break;
    //     case IdentifierType.Ihi:
    //       sourcePath = @"/Images/ihi.png";
    //       break;
    //     case IdentifierType.Hpii:
    //       sourcePath = @"/Images/hpi-i.png";
    //       break;
    //     case IdentifierType.Hpio:
    //       sourcePath = @"/Images/hpi-o.png";
    //       break;
    //     default:
    //       throw new ArgumentOutOfRangeException();
    //   }
    // }
    // ImageIcon.Source = new BitmapImage(new Uri(sourcePath, UriKind.Relative));
  }
}

