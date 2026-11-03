using System;
using System.Collections.Generic;
using System.Text;
using repository;

namespace service
{
    public class PasswordService
    {
        private PasswordData PD= new PasswordData();
        public int CheckPassword(string password)
        {
            return PD.PDCheckPassword(password);
        }
    }
}
