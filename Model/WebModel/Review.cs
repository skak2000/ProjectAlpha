using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WebModel
{
    public class Review
    { 
        public Guid ReviewID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid UserID { get; set; }

        public string ProductName { get; set; }
        public int TasteRating { get; set; }
        public int TextureRating { get; set; }
        public int VisualRating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }
      
        // ToDo AI to scan pictur for content 
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string Base64String { get; set; }
}
}
