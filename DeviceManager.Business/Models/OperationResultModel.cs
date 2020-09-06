namespace DeviceManager.Business.Models
{
    public class OperationResultModel<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        
        public OperationResultModel<T> SetStatus(bool success)
        {
            Success = success;
            return this;
        }

        public OperationResultModel<T> SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public OperationResultModel<T> SetData(T data)
        {
            Data = data;
            return this;
        }
    }
}
