namespace SPR311_DreamTeam_Rozetka.BLL.Services
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? PayLoad { get; set; }

        public static ServiceResponse Success(string message, object? payLoad = null)
        {
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = message,
                PayLoad = payLoad
            };
        }

        public static ServiceResponse Error(string message, object? payLoad = null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = message,
                PayLoad = payLoad
            };
        }
    }
}
