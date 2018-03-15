using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HelloWorld
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

    private void uxName_TextChanged(object sender, TextChangedEventArgs e)
    { 
      setSubmitStatus();
    }

    void setSubmitStatus()
    {
      if (uxName.Text.Length > 0 && uxPassword.Text.Length > 0)
      {
        uxSubmit.IsEnabled = true;
      }
      else
      {
        uxSubmit.IsEnabled = false;
      }
    }

    private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
    {
      setSubmitStatus();
    }

    private void uxSubmit_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("Submitting password:" + uxPassword.Text);

      var window = new SecondWindow();
      Application.Current.MainWindow = window;
      Close();
      window.Show();

    }
  }
}
