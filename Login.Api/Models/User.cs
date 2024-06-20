using Microsoft.AspNetCore.Identity;

namespace Login.Api.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User(RegisterDTO model)
        {
            Email = model.Email;
            UserName = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
        }
        public User() { }

    }

    public class UserDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token {  get; set; }
        public UserDTO(User user, string token)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Token = token;
        }
        public UserDTO(User user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
        public UserDTO() { }
    }
}
