using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
