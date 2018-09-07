using DotNetCoreExamples.CustomPasswordHasher.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DotNetCoreExamples.CustomPasswordHasher
{
    public class CustomPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            return ReversePassword(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == ReversePassword(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private string ReversePassword(string value)
        {
            // This is not a secure way to store a password!
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
