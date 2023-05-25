using Business_Logic_Layer.ViewModel;
using Data_Access_Layer;
using Data_Access_Layer.Context;

namespace Business_Logic_Layer
{
    public class UserBLL
    {
        private readonly UserDAL _UserDAL;
        public UserBLL()
        {
            _UserDAL = new UserDAL();
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            UserEntityModel UserFormaat = new UserEntityModel()
            {
                PublicIdentifier = Guid.NewGuid(),
                name = user.name!,
                lastName = user.lastName!,
                password = user.password!,
                email = user.email!
            };
            await _UserDAL.AddUser(UserFormaat);
            return user;
        }

        public async Task<LogIn> Authenticate(string email, string password)
        {
            UserEntityModel userEntity = await _UserDAL.GetUserByEmail(email);


            if (userEntity != null && userEntity.password == password)
            {
                LogIn user = new LogIn()
                {
                    password = userEntity.password,
                    email = userEntity.email
                };

                return user;
            }

            return null;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _UserDAL.GetUsers();
            return users.Select(u => new UserModel
            {
               
                name = u.name,
                lastName = u.lastName,
                password = u.password,
                email = u.email
            }).ToList();
        }

    }
}

