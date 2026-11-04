using System.Text.Json;
using api_1.entiti;
using Zxcvbn;

namespace api_1.repository
{
    public class UserData : IUserData
    {
        static string filePath = @"C:\Users\Tamar\source\repos\tamar-m-dev\repository\User.txt";
        public User UDGetUsersById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        return user;
                }
            }
            return null;
        }

        public List<User> UDGetUsers()
        {
            List<User> users = new List<User>();
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    users.Add(user);
                }
                return users;
            }
        }

        public User UDCreateUser(User user)
        {
            int score = Core.EvaluatePassword(user.password).Score;
            if (score < 3)
            {
                return null;
            }
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public User UDLoginUser(logUser logUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.email == logUser.email && user.password == logUser.password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public void UDChangeUser(int id, User user)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user2 = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user2.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
