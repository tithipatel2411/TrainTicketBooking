using Prompt.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUser
    {
        ApiResponse GetById(int id);
        ApiResponse Add(User model);
        ApiResponse Update(User model);
        ApiResponse Delete(int id);
        ApiResponse GetAll();
    }
}
