using chillhub.Models.Dtos.Responses.Shared;

public sealed class ResponseDto
{
    public int Status { get; }
    public string Message { get; }
    public object? Data { get; }

    private ResponseDto(int status, string message, object? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public static IResult Create(
        ResponseCatalog catalog,
        string? overrideMessage = null,
        object? overrideData = null
    ){
        var status = catalog.Status;
        var message = overrideMessage ?? catalog.DefaultMessage;
        var data = overrideData;

        return Results.Json(
            new ResponseDto(status, message, data),
            statusCode: status
        );
    }

}