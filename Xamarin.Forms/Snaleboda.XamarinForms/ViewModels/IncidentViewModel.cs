using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Snaleboda.XamarinForms.ViewModels
{
    public class IncidentViewModel : INotifyPropertyChanged
    {
        private bool _showPhoto;
        public bool ShowPhoto
        {
            get
            {
                return _showPhoto;
            }
            set
            {
                _showPhoto = value;
                OnPropertyChanged();
            }
        }

        private bool _showButtons;
        public bool ShowButtons
        {
            get
            {
                return _showButtons;
            }
            set
            {
                _showButtons = value;
                OnPropertyChanged();
            }
        }

        public ICommand TakePhoto
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }

        public ICommand SelectPhoto
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
