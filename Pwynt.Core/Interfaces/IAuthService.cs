using Pwynt.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pwynt.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthDto> LoginAsync(LoginDto loginDto);
        Task<string> AddRoleAsync(AddRoleDto addRoleDto);
    }
}
