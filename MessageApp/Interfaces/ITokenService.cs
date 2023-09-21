using MessageApp.DTOs;
using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    };
}
