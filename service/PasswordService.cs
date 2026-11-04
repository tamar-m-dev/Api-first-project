using System;
using System.Collections.Generic;
using System.Text;
using api_1.repository;

namespace api_1.service
{
    public class PasswordService : IPasswordService
    {
        private IPasswordData PD;
        public PasswordService(IPasswordData PD)
        {
            this.PD = PD;
        }
        public int CheckPassword(string password)
        {
            return PD.PDCheckPassword(password);
        }
    }
}
