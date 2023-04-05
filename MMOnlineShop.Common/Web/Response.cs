using Microsoft.AspNetCore.Http;

public class Response
{

    public Response()
    {
        Messages = new List<string>();
    }

    public Response(string message)
    {
        Messages = new List<string>();
        Messages.Add(message);
    }

    public Response(List<string> messages)
    {
        Messages = new List<string>();
        Messages.AddRange(messages);
    }

    public Response(List<string> messages, int code)
    {
        Messages = new List<string>();
        Messages.AddRange(messages);
        Code = code;
    }

    public Response(string message, int code)
    {
        Messages = new List<string>();
        Messages.Add(message);
        Code = code;
    }

    public Response(List<string> messages, int code, object data)
    {
        Messages = new List<string>();
        Messages.AddRange(messages);
        Code = code;
        Data = data;
    }

    public Response(string message, int code, object data)
    {
        Messages = new List<string>();
        Messages.Add(message);
        Code = code;
        Data = data;
    }

    public int Code { get; set; }
    public List<string> Messages { get; set; }
    public object Data { get; set; }

    public Response Ok(List<string> messages = null, object data = null)
    {
        Response response = new Response
        {
            Code = StatusCodes.Status200OK,
            Data = data
        };

        if (messages != null)
        {
            response.Messages.AddRange(messages);
        }

        return response;
    }

    public Response NotFound(List<string> messages)
    {
        Response response = new Response
        {
            Code = StatusCodes.Status404NotFound,
            Data = null
        };

        if (messages != null)
        {
            response.Messages.AddRange(messages);
        }

        return response;
    }

    public Response NotAcceptable(List<string> messages = null, object data = null)
    {
        Response response = new Response
        {
            Code = StatusCodes.Status406NotAcceptable,
            Data = data
        };

        if (messages != null)
        {
            response.Messages.AddRange(messages);
        }

        return response;
    }
    public Response Exeption(Exception e)
    {
        Response response = new Response
        {
            Code = StatusCodes.Status500InternalServerError,
            Data = null
        };

        response.Messages.Add("عملیات با خطا مواجه شد");

        return response;
    }
}
