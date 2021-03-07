using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace bknsystem.privateApi.Models
{
    public class file
    {
        public int id { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "image")]
        [DataType(DataType.ImageUrl)]
        public string file_url { get; set; }
        public string hotel_id { get;  set; }
    }
}