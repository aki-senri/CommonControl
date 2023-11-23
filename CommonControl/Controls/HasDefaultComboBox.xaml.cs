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

namespace CommonControl.Controls
{
    /// <summary>
    /// HasDefaultComboBox.xaml の相互作用ロジック
    /// </summary>
    public partial class HasDefaultComboBox : UserControl
    {
        public HasDefaultComboBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DefalutIndexProperty =
            DependencyProperty.Register("DefalutIndex", typeof(int), typeof(HasDefaultComboBox));

        public int DefalutIndex
        {
            get { return (int)GetValue(DefalutIndexProperty); }
            set { SetValue(DefalutIndexProperty, value); }
        }

        public bool IsDefaultIndex
        {
            get { return SelectedIndex == DefalutIndex; }
        }
    }
}
