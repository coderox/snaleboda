using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Interfaces;
using Snaleboda.Core.Models;

namespace Snaleboda.Core.ViewModels
{
    public class ContactViewModel : ViewModelBase, IContactViewModel
    {
        private readonly Contact _model;

        public string Name
        {
            get { return _model.Name; }
        }

        public string Email { get { return _model.Email; } }

        public string Phone { get { return _model.Phone; } }

        public ContactViewModel(Contact model)
        {
            _model = model;
        }

        public void Call()
        {
            throw new NotImplementedException();
        }
    }
}
