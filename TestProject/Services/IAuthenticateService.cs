﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string UserName , string Password);
    }
}
