using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework4
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      Regex re = new Regex(@"^[0-9]{5,5}$|^[0-9]{5,5}-[0-9]{4,4}$|^([A-Z][0-9]){3,3}$");
      Match match = re.Match(uxText.Text);
      if (uxSubmitBtn != null)
      {
        if (match.Success)
        {
          uxSubmitBtn.IsEnabled = true;
        }
        else
        {
          uxSubmitBtn.IsEnabled = false;
        }
      }
    }
  }
}
