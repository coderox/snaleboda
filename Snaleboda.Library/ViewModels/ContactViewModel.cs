using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.ViewModels
{
    public class ContactViewModel : MvxViewModel
    {
        private readonly ContactModel _model;

        private ICommand _callCommand = null;
        public ICommand CallCommand
        {
            get
            {
                if (_callCommand == null)
                    _callCommand = new MvxCommand(CallAction);
                return _callCommand;
            }
        }

        public string Name { get { return _model.Name; } }

        public string Phone { get { return _model.Phone; } }

        public string Email { get { return _model.Email; } }

        public ContactViewModel(ContactModel model)
        {
            _model = model;
        }

        private void CallAction()
        {
            var provider = Mvx.Resolve<IPlatformSpecificsProvider>();
            provider.PhoneCall(_model.Phone, _model.Name);
        }
    }
}
