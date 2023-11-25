using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommonControl.Controls
{
    public class CustomComboBox : ComboBox
    {
        public static readonly DependencyProperty DefalutIndexProperty;
        public static readonly DependencyProperty IsDefaultIndexProperty;

        static CustomComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomComboBox), new FrameworkPropertyMetadata(typeof(CustomComboBox)));
            DefalutIndexProperty = DependencyProperty.Register("DefalutIndex", typeof(int), typeof(CustomComboBox), new FrameworkPropertyMetadata(-1 ));
            IsDefaultIndexProperty = DependencyProperty.Register("IsDefaultIndex", typeof(bool), typeof(CustomComboBox), new FrameworkPropertyMetadata(false));
            
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public int DefalutIndex
        {
            get { return (int)GetValue(DefalutIndexProperty); }
            set { SetValue(DefalutIndexProperty, value); }
        }

        [Bindable(false)]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public bool IsDefaultIndex
        {
            get { return (bool)GetValue(IsDefaultIndexProperty); }
            set { SetValue(IsDefaultIndexProperty, value); }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            IsDefaultIndex = SelectedIndex == DefalutIndex;
        }
    }
}
