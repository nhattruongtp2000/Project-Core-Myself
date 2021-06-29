﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace DI.DI.Interace
{
    public interface IContactRepository
    {
        Task<ContactVm> GetContact();

        Task<int> Feedback(string UserName, string PhoneNumber, string Email, string Content);
    }
}
