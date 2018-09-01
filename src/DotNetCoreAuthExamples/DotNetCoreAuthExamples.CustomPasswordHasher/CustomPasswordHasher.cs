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
            return GetHash(password);
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == GetHash(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private string GetHash(string value)
        {
            string result = "";
            SHA256 hasher = SHA256Managed.Create();

            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    sw.Write(value);
                    sw.Flush();

                    ms.Position = 0;

                    byte[] hashedValue = hasher.ComputeHash(ms);

                    result = Convert.ToBase64String(hashedValue);
                }
            }

            return result;
        }

    }
}
