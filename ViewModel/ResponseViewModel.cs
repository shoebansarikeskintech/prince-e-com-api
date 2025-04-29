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

    public class ResponseViewModelProduct
    {
        public int statusCode { get; set; }
        public string? message { get; set; }

        public Guid productId { get; set; }  // <-- Must match the SP output
        public object? data { get; set; }
       
    }
}
