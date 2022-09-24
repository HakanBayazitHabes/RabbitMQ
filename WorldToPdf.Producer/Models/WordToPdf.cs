using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldToPdf.Producer.Models
{
    public class WordToPdf
    {
        public string Email { get; set; }
        public IFormFile WordFile { get; set; }

    }
}
