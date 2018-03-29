using System;
using System.CodeDom;
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

namespace TicTacToe
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      uxTurn.Text = currentPlayer + "'s turn";
    }

    private Dictionary<string, int> gameboard = new Dictionary<string, int>()
    {
      {"OC0", 0},
      {"OC1", 0},
      {"OC2", 0},
      {"OR0", 0},
      {"OR1", 0},
      {"OR2", 0},
      {"OLD", 0},
      {"ORD", 0},
      {"XC0", 0},
      {"XC1", 0},
      {"XC2", 0},
      {"XR0", 0},
      {"XR1", 0},
      {"XR2", 0},
      {"XLD", 0},
      {"XRD", 0}
    };

    private Dictionary<string, string> diagonals = new Dictionary<string, string>()
    {
      {"0,0", "LD"},
      {"2,2", "LD"},
      {"0,2", "RD"},
      {"2,0", "RD"}
    };

    private int numPlays = 0;
    private string currentPlayer = "X";
    private string centerSquare = "1,1";
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (sender.GetType() == typeof(Button))
      {
        Button button = (Button) sender;
        button.Content = currentPlayer;
        numPlays++;
        string tag = (string) button.Tag;
        var splitTag = tag.Split(',');
        int rowcount = ++gameboard[currentPlayer + "R" + splitTag[0]];
        int columncount = ++gameboard[currentPlayer + "C" + splitTag[1]];
        int ldiagcount = 0;
        int rdiagcount = 0;
        if (tag == centerSquare)
        {
          ldiagcount = ++gameboard[currentPlayer + "LD"];
          rdiagcount = ++gameboard[currentPlayer + "RD"];
        }
        if (diagonals.ContainsKey(tag))
        {
          if (diagonals[tag] == "LD")
          {
            ldiagcount = ++gameboard[currentPlayer + diagonals[tag]];
          }
          else
          {
            rdiagcount = ++gameboard[currentPlayer + diagonals[tag]];
          }
        }

        if (rowcount == 3 || columncount == 3 || ldiagcount == 3 || rdiagcount == 3)
        {
          uxTurn.Text = currentPlayer + " wins";
          setGridButtonsEnabled(false, false);
        }
        else if (numPlays == 9)
        {
          uxTurn.Text = "Game is a draw";
          setGridButtonsEnabled(false, false);
        }
        else
        {
          button.IsEnabled = false;
          if (numPlays % 2 == 0)
          {
            currentPlayer = "X";
          }
          else
          {
            currentPlayer = "O";
          }

          uxTurn.Text = currentPlayer + "'s turn";
        }

      }
      
    }

    private void uxNewGame_Click(object sender, RoutedEventArgs e)
    {
      List<string> keys = new List<string>(gameboard.Keys);
      foreach (string key in keys)
      {
        gameboard[key] = 0;
      }
      setGridButtonsEnabled(true, true);

      currentPlayer = "X";
      uxTurn.Text = currentPlayer + "'s turn";
      numPlays = 0;
    }

    private void setGridButtonsEnabled(Boolean enable, Boolean clearContent)
    {
      foreach (var child in uxGrid.Children)
      {
        if (child.GetType() == typeof(Button))
        {
          Button b = (Button)child;
          if (clearContent)
          {
            b.Content = "";
          }
          b.IsEnabled = enable;
        }
      }
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
