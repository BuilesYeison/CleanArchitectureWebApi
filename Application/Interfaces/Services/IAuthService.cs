using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(string userId, string email);
        Task<bool> ValidateTokenAsync(string token);
    }
}
