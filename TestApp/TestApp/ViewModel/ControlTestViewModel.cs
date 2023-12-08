using System;
using System.Collections.ObjectModel;

namespace TestApp.ViewModel
{
    internal class ControlTestViewModel : ViewModelBase
    {
        public ObservableCollection<string> TestItems { get; set; } = new ObservableCollection<string>();
        public string SelectedItem { get; set; }
        public Int32 DefaultIndex { get; set; } = 0;

        public ControlTestViewModel()
        {
            TestItems.Add("Item1");
            TestItems.Add("Item2");
            TestItems.Add("Item3");
            SelectedItem = TestItems[0];
        }
    }
}
