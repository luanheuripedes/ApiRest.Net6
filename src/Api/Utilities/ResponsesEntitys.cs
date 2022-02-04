using Api.ViewModels;
using Domain.Entities;
using Services.DTO;

namespace Api.Utilities
{
    public static class ResponsesEntitys
    {
        public static ResultViewModel Success(string message, Object obj)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = true,
                Data = obj
            };
        }

        public static ResultViewModel Success(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = true,
                Data = null
            };
        }

        public static ResultViewModel SuccessGet(string message, Object obj)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = true,
                Data = obj
            };
        }

    }
}
