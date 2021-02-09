using System.Collections;
using System.Collections.Generic;
using CleanCodeTp.Application.Entities;

namespace CleanCodeTp.Infrastructure
{
    public interface IUserReadRepository
    {
        IList<UserEntity> GetAll();
        UserEntity? GetById(string id);
        
        string? GetConnectedUserId( );
    }
}
