using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace CommonControl.Controls
{
    public class CustomComboBox : ComboBox
    {
        public static readonly DependencyProperty DefalutIndexProperty = DependencyProperty.Register("DefalutIndex", typeof(int), typeof(CustomComboBox), new FrameworkPropertyMetadata(-1));
        public static readonly DependencyProperty IsDefaultIndexProperty = DependencyProperty.Register("IsDefaultIndex", typeof(bool), typeof(CustomComboBox), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(Brush), typeof(CustomComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        static CustomComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomComboBox), new FrameworkPropertyMetadata(typeof(CustomComboBox)));
        }

        public int DefalutIndex
        {
            get { return (int)GetValue(DefalutIndexProperty); }
            set
            {
                SetValue(DefalutIndexProperty, value);
                IsDefaultIndex = SelectedIndex == DefalutIndex;
            }
        }

        public bool IsDefaultIndex
        {
            get { return (bool)GetValue(IsDefaultIndexProperty); }
            set { SetValue(IsDefaultIndexProperty, value); }
        }

        public Brush HighlightColor
        {
            get { return (Brush)GetValue(HighlightColorProperty); }
            set { SetValue(HighlightColorProperty, value); }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            IsDefaultIndex = SelectedIndex == DefalutIndex;
        }

        private void UpdateIsDefaultIndex()
        {
            IsDefaultIndex = SelectedIndex == DefalutIndex;
        }
    }
}
