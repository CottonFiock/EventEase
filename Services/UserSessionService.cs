using System.Collections.Generic;

namespace EventEase.Services
{
    public class UserSessionService
    {
        private readonly List<(string Name, string Email, string Password)> _users = new();

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsLoggedIn => !string.IsNullOrEmpty(Email);

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public bool Register(string name, string email, string password)
        {
            if (_users.Exists(u => u.Email == email))
                return false; // Email already registered

            _users.Add((name, email, password));
            Name = name;
            Email = email;
            NotifyStateChanged();
            return true;
        }

        public bool Login(string email, string password)
        {
            var user = _users.Find(u => u.Email == email && u.Password == password);
            if (user != default)
            {
                Name = user.Name;
                Email = user.Email;
                NotifyStateChanged();
                return true;
            }
            return false;
        }

        public void Logout()
        {
            Name = null;
            Email = null;
            NotifyStateChanged();
        }
    }
}