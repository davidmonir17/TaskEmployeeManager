using Domain.DataTransferObject;
using Domain.DataTransferObject.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAuthService
    {
        public Task<AuthModel> RegisterAsync(RegisterModel model, string nameRole);

        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
    }
}