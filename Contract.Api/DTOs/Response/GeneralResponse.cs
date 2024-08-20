namespace Contract.DTOs.Response;

public class GeneralResponse
{
    public string ResponseMessage { set; get; }
    public int ResponseCode { set; get; }
     
}

public class GeneralResponse<T>:GeneralResponse
{
    public T ResponseBody { set; get; }
}