﻿using FirstFloor.ModernUI.Windows.Controls;
using ModernHistory.ViewModels;
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

namespace ModernHistory.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PersonAddDialog.xaml
    /// </summary>
    public partial class PersonAddDialog : ModernDialog
    {
        public PersonAddDialog(PersonAddDialogViewModel personAddDialogViewModel)
        {
            InitializeComponent();
            personAddDialogViewModel.Dialog = this;
            this.DataContext = personAddDialogViewModel;
            CloseButton.Visibility = Visibility.Hidden;
        }
    }
}
