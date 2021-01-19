using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Zoo.Application.UseCase.User
{
    public class UserUseCase: IUser
    {

        private readonly IdentityUser _identityUser;
        
        public UserUseCase(IdentityUser identityUser)
        {
            _identityUser = identityUser;
            
        }
      
    }
}
