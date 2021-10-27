using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Курсовая_2.Models
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public DateTime Time { get; set; }
        public int CountOfStrings { get; set; }
        public int Size { get; set; } 
        public double OpenTimeGem { get; set; }
        public double OpenTimeStream { get; set; }
        [NotMapped]
        public HttpPostedFileBase UsersFile { get; set; }
    }
}