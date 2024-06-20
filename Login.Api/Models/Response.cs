namespace Login.Api.Models
{
    public class Response
    {
        public bool Succeded { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }

        public Response() { }
        public Response(string message) {
            Succeded = false;
            Message = message;
        }
        public Response(object body)
        {
            Body = body;
            Succeded = true;
        }


    }
}
