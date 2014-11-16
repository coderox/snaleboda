using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using Cirrious.MvvmCross.ViewModels;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snaleboda.Library.ViewModels
{
    public class IncidentViewModel : MvxViewModel
    {
        private string _image;

        public IAsyncServiceAgent _asyncServiceAgent;
        public IncidentViewModel(IAsyncServiceAgent asyncServiceAget)
        {
            _asyncServiceAgent = asyncServiceAget;
        }

        

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private byte[] _imageBytes;
        public byte[] ImageBytes
        {
            get
            {
                return _imageBytes;
            }
            set
            {
                _imageBytes = value;
                RaisePropertyChanged(() => ImageBytes);
            }
        }

        public ICommand SelectImage
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var task = Mvx.Resolve<IMvxPictureChooserTask>();
                    task.ChoosePictureFromLibrary(500, 90,
                           stream =>
                           {
                               var bytes = new byte[stream.Length];
                               stream.Read(bytes, 0, (int)stream.Length);

                               ImageBytes = bytes;
                           },
                           () =>
                           {
                               // perform any cancelled operation
                           });
                });
            }
        }

        public ICommand Send
        {
            get
            {
                return new MvxCommand(async() =>
                {
                    var incident = new IncidentModel()
                    {
                        Description = Description,
                        Name = Name,
                        Image = UTF8Encoding.UTF8.GetString(ImageBytes,0,(int)ImageBytes.Length)
                    };

                    await _asyncServiceAgent.PostIncidentAsync(incident);
                });
            }
        }
    }
}
