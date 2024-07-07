using DotNet8Mvc.NLayerArchitecture.Models.Enums;

namespace DotNet8Mvc.NLayerArchitecture.Models.Features;

public class Result<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsError
    {
        get { return !IsSuccess; }
    }
    public string Message { get; set; }
    public EnumStatusCode StatusCode { get; set; }

    public static Result<T> SuccessResult(
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    )
    {
        return new Result<T>
        {
            IsSuccess = true,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static Result<T> SuccessResult(
        T data,
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    )
    {
        return new Result<T>
        {
            Data = data,
            IsSuccess = true,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static Result<T> FailureResult(
        string message = "Fail.",
        EnumStatusCode statusCode = EnumStatusCode.BadRequest
    )
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static Result<T> FailureResult(Exception ex)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = ex.ToString(),
            StatusCode = EnumStatusCode.InternalServerError
        };
    }

    public static Result<T> ExecuteResult(
        int result,
        EnumStatusCode statusStatusCode = EnumStatusCode.Success,
        EnumStatusCode failureStatusCode = EnumStatusCode.BadRequest
    )
    {
        return result > 0
            ? Result<T>.SuccessResult(statusCode: statusStatusCode)
            : Result<T>.FailureResult(statusCode: failureStatusCode);
    }
}
