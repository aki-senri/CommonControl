using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
