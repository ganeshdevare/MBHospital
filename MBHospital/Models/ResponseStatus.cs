namespace MBHospital.Models
{
    public class ResponseStatus<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Records { get; set; }
        public T Record { get; set; }

    }
}
