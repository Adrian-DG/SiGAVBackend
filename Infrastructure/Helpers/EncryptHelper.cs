﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
	public class EncryptHelper
	{
		public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.ASCIIEncoding.UTF8.GetBytes(password));
			}
		}

		public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(ASCIIEncoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != passwordHash[i]) return false;
				}
			}

			return true;
		}
	}
}
