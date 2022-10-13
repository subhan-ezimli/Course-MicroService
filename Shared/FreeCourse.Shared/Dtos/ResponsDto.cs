using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponsDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccesful { get; set; }
        public List<string> Errors { get; set; }
        public static ResponsDto<T> Success(T data, int statusCode)
        {
            return new ResponsDto<T> { Data = data, StatusCode = statusCode, IsSuccesful = true };
        }
        public static ResponsDto<T> Success(int statusCode)
        {
            return new ResponsDto<T> { Data = default, StatusCode = statusCode, IsSuccesful = true };
        }
        public static ResponsDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponsDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccesful = false
            };
        }

        public static ResponsDto<T> Fail(string error, int statusCode)
        {
            return new ResponsDto<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccesful = false
            };

        }
    }
}
