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

namespace PhotoAdder.View.CustomControls
{
    /// <summary>
    /// Logika interakcji dla klasy ToggleButton.xaml
    /// </summary>
    /// 

    public partial class ToggleButton : UserControl
    {



        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(ToggleButton), new PropertyMetadata(false));


        public string LeftLabel
        {
            get { return (string)GetValue(LeftLabelProperty); }
            set { SetValue(LeftLabelProperty, value); }
        }
        public string RightLabel
        {
            get { return (string)GetValue(RightLabelProperty); }
            set { SetValue(RightLabelProperty, value); }
        }

        public static readonly DependencyProperty LeftLabelProperty =
            DependencyProperty.Register("LeftLabel", typeof(string), typeof(ToggleButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty RightLabelProperty =
            DependencyProperty.Register("RightLabel", typeof(string), typeof(ToggleButton), new PropertyMetadata(string.Empty));




        public ToggleButton()
        {
            InitializeComponent();
        }
    }
}
