using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PortfolioResponse
    {
        public int PortfolioID { get; set; }
        public string PortfolioName { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string PortfolioLink { get; set; }
        public string PortfolioType { get; set; }

    }
}