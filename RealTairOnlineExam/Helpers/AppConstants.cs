using System;
using System.Collections.Generic;
using System.Text;

namespace RealTairOnlineExam.Helpers
{
    public static class AppConstants
    {
        public static string GetAllCoinsEndpoint = "coins/list";
        public static string GetCoinsByIdEndpoint(string id)=>$"coins/{id}";
    }
}
