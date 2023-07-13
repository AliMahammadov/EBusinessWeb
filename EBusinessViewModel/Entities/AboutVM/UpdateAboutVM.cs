using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessViewModel.Entities.AboutVM
{
    public class UpdateAboutVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required, MaxLength(35)]
        public string Title { get; set; }
        [Required, MaxLength(350)]
        public string Information { get; set; }
    }
}
