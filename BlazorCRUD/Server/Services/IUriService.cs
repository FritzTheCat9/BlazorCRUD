using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Services
{
    public interface IUriService
    {
        Uri GetPostUri(int postId);
    }
}
