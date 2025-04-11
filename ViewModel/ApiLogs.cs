namespace ViewModel
{
    public class ApiLogs
    {
        public string? CreatedOn { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestUrl { get; set; }
        public string? RequestHeaders { get; set; }
        public int UserId { get; set; }
        public string? ClientIpAddress { get; set; }
        public string? PageUrl { get; set; }
        public string? RequestSource { get; set; }
        public int OrgId { get; set; }
        public string? RequestBody { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? ExceptionStackTrace { get; set; }
        public int ResponseStatusCode { get; set; }
        public string? ResponseHeaders { get; set; }
        public string? ResponseBody { get; set; }
    }
}

