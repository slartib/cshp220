﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace HelloWorld
{
  /// <summary>
  /// Interaction logic for SecondWindow.xaml
  /// </summary>
  public partial class SecondWindow : Window
  {

    private GridViewColumnHeader listViewSortCol = null;
    private SortAdorner listViewSortAdorner = null;

    public SecondWindow()
    {
      InitializeComponent();
      var users = new List<Models.User>();

      users.Add(new Models.User { Name = "Dave", Password = "DavePwd" });
      users.Add(new Models.User { Name = "Steve", Password = "StevePwd" });
      users.Add(new Models.User { Name = "Lisa", Password = "LisaPwd" });

      uxList.ItemsSource = users;

    }

    private void lvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
    {
      GridViewColumnHeader column = (sender as GridViewColumnHeader);
      string sortBy = column.Tag.ToString();
      if (listViewSortCol != null)
      {
        AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
        uxList.Items.SortDescriptions.Clear();
      }

      ListSortDirection newDir = ListSortDirection.Ascending;
      if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
      {
        newDir = ListSortDirection.Descending;
      }

      listViewSortCol = column;
      listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
      AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
      uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
    }

  }
}
