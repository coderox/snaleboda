﻿using Snaleboda.XamarinForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.XamarinForms.Views
{
    public partial class ContactsView
    {
        public ContactsView(ContactsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
