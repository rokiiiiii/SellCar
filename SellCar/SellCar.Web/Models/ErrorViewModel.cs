namespace SellCar.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Path { get; }
        public int StatusCode { get; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public ErrorViewModel(string path = null)
        {
            StatusCode = 500;
            Path = path;
        }
        public ErrorViewModel(int statusCode, string path = null)
        {
            StatusCode = statusCode;
            Path = path;
        }
    }
}