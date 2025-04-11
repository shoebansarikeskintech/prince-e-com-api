using Newtonsoft.Json;

namespace ViewModel
{
    public class ResponseViewModel
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
