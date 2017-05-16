﻿namespace Fabric.Identity.API.Models
{
    public class Error
    {

        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public Error[] Details { get; set; }
        public InnerError Innererror { get; set; }
    }

    public class InnerError
    {
        public string Code { get; set; }
        public InnerError Innererror { get; set; }
    }
}
