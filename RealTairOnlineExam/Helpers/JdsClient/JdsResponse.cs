using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyTwoJuetengApp.Helpers.JdsClientTool
{
    public class JdsResponse
    {
        public string RequestContent { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsFailed => (int)StatusCode == 400 || (int)StatusCode == 403
            || (int)StatusCode == 500 || (int)StatusCode == 502 || (int)StatusCode == 404 || (int)StatusCode == 404;
    }
}
