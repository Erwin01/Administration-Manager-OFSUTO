using System;

namespace Syntax.Ofesauto.Security.Transversal.Common
{
    /// <summary>
    /// Method that contains information that the Web API resources have
    /// Data: Stored response of methos Insert,Update,Delete,get by Id y Get All.
    /// IsSuccess: the execution state, if called successful, returns true; otherwise if there was an error it will return false.
    /// Message: If a request was correct, it will be placed that it was accepted correctly, in case of error the error will be detected by the try catch, 
    /// depending on the type of error assigned to it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    #region [ RESPONSE ]
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public Exception LogError { get; set; }

        public static Response<T> Sucess(T data, string message, bool isSuccess)
        {
            return new Response<T>()
            {
                Message = message,
                IsSuccess = isSuccess,
                Data = data
            };
        }

        public static Response<T> Error(T data, Exception exception, string message, bool isSuccess)
        {
            return new Response<T>()
            {
                LogError = exception,
                Message = message,
                IsSuccess = isSuccess,
                Data = data
            };
        }
    }
    #endregion

}
