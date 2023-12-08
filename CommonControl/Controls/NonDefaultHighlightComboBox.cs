using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CommonControl.Controls
{
    public class NonDefaultHighlightComboBox : ComboBox
    {
        public static readonly DependencyProperty DefalutIndexProperty = DependencyProperty.Register("DefalutIndex", typeof(int), typeof(NonDefaultHighlightComboBox), new FrameworkPropertyMetadata(-1));
        public static readonly DependencyProperty IsDefaultIndexProperty = DependencyProperty.Register("IsDefaultIndex", typeof(bool), typeof(NonDefaultHighlightComboBox), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(Brush), typeof(NonDefaultHighlightComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));

        private BorderAdorner _borderAdorner;

        static NonDefaultHighlightComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NonDefaultHighlightComboBox), new FrameworkPropertyMetadata(typeof(NonDefaultHighlightComboBox)));
        }

        public NonDefaultHighlightComboBox()
        {
            Loaded += ComboBox_Loaded;
            SelectionChanged += (s, e) => UpdateIsDefaultIndex();
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
            set
            {
                SetValue(IsDefaultIndexProperty, value);
                if (_borderAdorner != null)
                {
                    _borderAdorner.Visibility = IsDefaultIndex ? Visibility.Hidden : Visibility.Visible;
                }
            }
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

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as NonDefaultHighlightComboBox;
            if (comboBox != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(comboBox);
                if (adornerLayer != null)
                {
                    _borderAdorner = new BorderAdorner(comboBox);
                    _borderAdorner.Visibility = IsDefaultIndex ? Visibility.Hidden : Visibility.Visible;
                    _borderAdorner.Thickness = BorderThickness.Left;
                    _borderAdorner.BoderBrush = HighlightColor;
                    adornerLayer.Add(_borderAdorner);
                }
            }
        }
    }

    internal class BorderAdorner : Adorner
    {
        public double Thickness { get; set; } = 1.0;
        public Brush BoderBrush { get; set; } = Brushes.Red;

        public BorderAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        public BorderAdorner(UIElement adornedElement, double thickness, Brush brush)
            : base(adornedElement)
        {
            Thickness = thickness;
            BoderBrush = brush;
        }

        protected override void OnRender(DrawingContext dc)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);

            var pen = new Pen();
            pen.Thickness = Thickness;
            pen.Brush = BoderBrush;
            double offset = Thickness / 2;
            dc.DrawRectangle(null, pen, new Rect(offset, offset, ActualWidth - Thickness, ActualHeight - Thickness));
        }
    }
}
