﻿using System;
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

namespace WpfApp1.Views
{
    /// <summary>
    /// PersonView.xaml の相互作用ロジック
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView()
        {
            InitializeComponent();
            //this.DataContext = new WpfApp1.ViewModels.PersonViewModel { Name = "ns taro", Mail = "taro@ns.com" };
        }
    }
}
