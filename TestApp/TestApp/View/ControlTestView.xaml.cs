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
using CommonControl;

namespace TestApp.View
{
    /// <summary>
    /// ControlTestView.xaml の相互作用ロジック
    /// </summary>
    public partial class ControlTestView : UserControl
    {
        public ControlTestView()
        {
            InitializeComponent();
        }

        private void CustomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combobox)
            {
                System.Diagnostics.Debug.WriteLine(combobox.SelectedIndex);
            }
            if ( sender is CommonControl.Controls.CustomComboBox customCombobox)
            {
                System.Diagnostics.Debug.WriteLine(customCombobox.IsDefaultIndex);
                /*
                if (combobox.IsDefaultIndex == false)
                {
                    combobox.IsDefaultIndex = true;
                    return;
                }
                if (combobox.IsDefaultIndex == true) combobox.IsDefaultIndex = false;
                */
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combobox)
            {
                System.Diagnostics.Debug.WriteLine("ComboBox " + combobox.SelectedIndex);
            }
        }
    }
}
