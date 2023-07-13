using EBusinessCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBusinessEntity.Entities
{
    public class About: EntityBase
    {

        public string ImgUrl { get; set; }
        [MaxLength(35)]
        public string Title { get; set; }
        [MaxLength (350)]
        public string Information { get; set; }
    }
}
