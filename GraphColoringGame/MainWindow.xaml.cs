﻿using GraphColoringGame.Graphs;
using GraphColoringGame.Levels;
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

namespace GraphColoringGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int l = 1;
        public MainWindow()
        {
            InitializeComponent();
            var graphPage = new GraphPage(new Level1Graph().createGraph());
            GraphFrame.Content = graphPage;
        }

        public void changeLevel()
        {
            GraphPage graphPage;
            switch (l)
            {
                case 1:
                    l = 2;
                    graphPage = new GraphPage(new Level2Graph().createGraph());
                    break;
                case 2:
                    l = 3;
                    graphPage = new GraphPage(new Level3Graph().createGraph());
                    break;
                default:
                    l = 1;
                    graphPage = new GraphPage(new Level1Graph().createGraph());
                    break;
            }
            GraphFrame.Content = graphPage;
        }
    }
}
