﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IEmailService
    {
        public void SendEmail(string toAddress, string subject, string body);
    }
}