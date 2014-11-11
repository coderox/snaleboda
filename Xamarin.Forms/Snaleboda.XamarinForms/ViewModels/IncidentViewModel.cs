using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Media;

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

        private bool _showButtons = true;
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

        private ImageSource _photo;
        public ImageSource Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged();
            }
        }

        public ICommand TakePhoto
        {
            get
            {
                return new Command(() =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {

                        try
                        {
                            var mediaPicker = DependencyService.Get<IMediaPicker>();

                            var mediaFile = await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions
                            {
                                DefaultCamera = CameraDevice.Rear,
                                //MaxPixelDimension = 1024
                            });

                            Photo = ImageSource.FromStream(() => mediaFile.Source);
                            ShowButtons = false;
                            ShowPhoto = true;
                            //var bytes = new byte[mediaFile.Source.Length];

                            //mediaFile.Source.Read(bytes, 0, (int)mediaFile.Source.Length);

                            //PhotoBytes = bytes;
                        }
                        catch (TaskCanceledException ex)
                        {
                            
                        }
                    });
                });
            }
        }

        public ICommand SelectPhoto
        {
            get
            {
                return new Command(() =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {

                        try
                        {
                            var mediaPicker = DependencyService.Get<IMediaPicker>();

                            var mediaFile = await mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                            {
                                DefaultCamera = CameraDevice.Rear,
                                //MaxPixelDimension = 1024
                            });

                            Photo = ImageSource.FromStream(() => mediaFile.Source);
                            ShowButtons = false;
                            ShowPhoto = true;
                            //var bytes = new byte[mediaFile.Source.Length];

                            //mediaFile.Source.Read(bytes, 0, (int)mediaFile.Source.Length);

                            //PhotoBytes = bytes;
                        }
                        catch (TaskCanceledException ex)
                        {
                            
                        }
                    });
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
