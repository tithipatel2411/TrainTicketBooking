using Microsoft.AspNetCore.Http;
using Prompt.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class User : IUser
    {
        public ApiResponse Add(User model)
        {
            try
            {
                return new ApiResponse()
                {
                    Data = model,
                    Message = "Record added successfully!!",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Data = model,
                    Message = "Error occured!!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public ApiResponse Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse GetAll()
        {
            throw new NotImplementedException();
        }

        public ApiResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
