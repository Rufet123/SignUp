using System;
namespace User
{
	public class SignUp
	{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
		
		public SignUp()
		{
		}
		public SignUp(string username,string password, string email,string phone)
		{
			this.Username = username;
			this.Password = password;
            this.Email = email;
			this.Phone = phone;
        }
		public string FullInfo()
		{
			return $"your username:{Username}\nyour email:{Email}\nyour phone number:{Phone}";
		}
		public void Info()
		{
			Console.WriteLine($"{Username}");
		}
		
	}
}

