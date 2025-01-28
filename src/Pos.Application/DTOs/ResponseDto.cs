namespace Pos.Application.DTOs;

public class ResponseDto
{
    public bool IsSuccess { get; }
    public string Message { get; }
    public object? Entity { get; }

    private ResponseDto(bool isSuccess, string message, object? entity)
    {
        IsSuccess = isSuccess;
        Message = message;
        Entity = entity;
    }
    public static ResponseDto Success(string message, object? entity = null)
    {
        return new ResponseDto(true, message, entity);
    }
    public static ResponseDto Failure(string message, object? entity = null)
    {
        return new ResponseDto(false, message, entity);
    }
}
