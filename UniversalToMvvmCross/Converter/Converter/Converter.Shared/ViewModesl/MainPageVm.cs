using System.ComponentModel;

namespace Converter.ViewModesl
{
    public class MainPageVm : INotifyPropertyChanged
    {
        public MainPageVm()
        {
            ButtonText = "TechDays Converter";
            ShowButton = true;
        }
        public string ButtonText { get; set; }
        public bool ShowButton { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
