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

namespace CommonControl.View
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
            if ( sender is Controls.CustomComboBox combobox )
            {
                System.Diagnostics.Debug.WriteLine(combobox.IsDefaultIndex);
                if (combobox.DefalutIndex == 0) combobox.DefalutIndex = 1;
                if (combobox.DefalutIndex == 1) combobox.DefalutIndex = 0;
            }
        }
    }
}
