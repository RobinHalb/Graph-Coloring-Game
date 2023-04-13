using GraphColoringGame.Explanations;
using GraphColoringGame.Graphics;
using GraphColoringGame.Graphs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
    /// Interaction logic for ExplanationPage.xaml
    /// The Buttons are manually placed inside the xaml file
    /// 
    /// </summary>
    /// 
    public partial class ExplanationTextPage : Page
    {
        private List<ExplanationStep> _steps;
        private List<ExplanationGraphPage> _explanationGraphs = new List<ExplanationGraphPage>();
        private int _currentStep = 0;
        private int _lastStep;
        private string currentStepString => (_currentStep+1).ToString();
        private string ofSteps;
        private bool _explanationVisible = false;

        public Frame graphFrame { get; private set; }

        public ExplanationTextPage(List<ExplanationStep> steps, Frame graphFrame, int level, Player winning)
        {
            InitializeComponent();
            DataContext = this;
            _steps = steps;
            this.graphFrame = graphFrame;

            foreach (ExplanationStep step in steps)
            {
                _explanationGraphs.Add(new ExplanationGraphPage(step));
            }

            _lastStep = steps.Count-1;
            ofSteps = $"/{steps.Count}";

            LevelLabel.Content = $"Level {level}";
            ColorsLabel.Content = $"{steps[0].colors.Count} colors";
            setWinning(winning.ToString());

            StepText.Text = _steps[0].text;
            changeStep();
            setBtnVisibility();
            ExplanationGrid.Visibility = Visibility.Hidden;

            graphFrame.Content = _explanationGraphs[_currentStep];
        }

        public void setWinning(string winning) => WinningName.Text = winning;

        /*
         * Show / Hide explanation
         */
        private void ExplanationBtnClick(object sender, RoutedEventArgs e)
        {
            _explanationVisible = !_explanationVisible;
            if (_explanationVisible)
            {
                ExplanationBtn.Content = "Close explanation";
                ExplanationGrid.Visibility = Visibility.Visible;
                graphFrame.Visibility = Visibility.Visible;
            }
            else
            {
                ExplanationBtn.Content = "Show explanation";
                ExplanationGrid.Visibility = Visibility.Hidden;
                graphFrame.Visibility = Visibility.Hidden;
            }
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            _currentStep++;
            setBtnVisibility();
            changeStep();
        }

        private void prevStep(object sender, RoutedEventArgs e)
        {
            _currentStep--;
            setBtnVisibility();
            changeStep();
        }

        /*
         * Set visibility of prev and next buttons
         */
        private void setBtnVisibility()
        {
            if (_currentStep == 0) PrevStepBtn.Visibility = Visibility.Hidden;
            else PrevStepBtn.Visibility = Visibility.Visible;
            if (_currentStep == _lastStep) NextStepBtn.Visibility = Visibility.Hidden;
            else NextStepBtn.Visibility = Visibility.Visible;
        }
        
        /*
         * Set step counter, text, and graph
         */
        private void changeStep()
        {
            stepsLabel.Content = currentStepString + ofSteps;
            graphFrame.Content = _explanationGraphs[_currentStep];
            StepText.Text = _steps[_currentStep].text;
        }
    }
}
