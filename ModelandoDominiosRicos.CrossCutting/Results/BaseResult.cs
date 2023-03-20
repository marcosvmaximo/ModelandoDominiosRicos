using System;
namespace ModelandoDominiosRicos.CrossCutting.Results;

public class BaseResult
{
    public BaseResult(int httpCode, bool sucess, string message, object data)
    {
        HttpCode = httpCode;
        Sucess = sucess;
        Message = message;
        Data = data;
    }

    public BaseResult() { }

    public int HttpCode { get; set; }
    public bool Sucess { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public BaseResult Ok(object data)
    {
        return new BaseResult(
            200,
            true,
            "Requesição enviada com sucesso.",
            data
            );
    }
}

