using HWMS.Application.ViewModels;

namespace HWMS.Application.Interfaces
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(LoginRequestDto request, out string token);
    }
}