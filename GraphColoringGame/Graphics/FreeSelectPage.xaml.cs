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
using GraphColoringGame.FreePlay;
using GraphColoringGame.Graphs;
using GraphColoringGame.Levels;

namespace GraphColoringGame.Graphics
{
    /// <summary>
    /// Interaction logic for FreeSelectPage.xaml
    /// </summary>
    public partial class FreeSelectPage : Page
    {
        private IFreePlay[] TwoColors =
        {
            new FreePlay2Graph1()
        };

        private IFreePlay[] ThreeColors =
        {
            new FreePlay3Graph1(),
            new FreePlay3Graph2(),
            new FreePlay3Graph3(),
        };

        private IFreePlay[] FourColors =
        {
            new FreePlay4Graph1(),
            new FreePlay4Graph2(),
        };

        public FreeSelectPage()
        {
            InitializeComponent();
        }

        private void Free2Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(TwoColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(TwoColors[i]);
        }

        private void Free3Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(ThreeColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(ThreeColors[i]);
        }

        private void Free4Btn_Click(object sender, RoutedEventArgs e)
        {
            var i = new Random().Next(FourColors.Length);
            (Application.Current.MainWindow as MainWindow)?.openFreePlay(FourColors[i]);
        }
    }
}