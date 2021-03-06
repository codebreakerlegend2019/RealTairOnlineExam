﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealTairOnlineExam.Models
{
    public class CoinDescription
    {
        private string _en;
        public string En 
        {
            get => _en ?? ""; 
            set { _en = (value == string.Empty) ? "No Description Available" : value; }
        }
        public string De { get; set; }
        public string Es { get; set; }
        public string Fr { get; set; }
        public string It { get; set; }
        public string Pl { get; set; }
        public string Ro { get; set; }
        public string Hu { get; set; }
        public string Nl { get; set; }
        public string Pt { get; set; }
        public string Sv { get; set; }
        public string Vi { get; set; }
        public string Tr { get; set; }
        public string Ru { get; set; }
        public string Ja { get; set; }
        public string Zh { get; set; }
        public string Zh_Tw { get; set; }
        public string Ko { get; set; }
        public string Ar { get; set; }
        public string Th { get; set; }
        public string Id { get; set; }
    }
}
