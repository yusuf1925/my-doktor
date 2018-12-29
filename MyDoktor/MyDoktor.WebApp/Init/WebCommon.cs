﻿using MyDoktor.Common;
using MyDoktor.Entities;
using MyDoktor.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDoktor.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            DoktorUser user = CurrentSession.User;

            if (user != null)
                return user.Username;
            else
                return "system";
        }
    }
}