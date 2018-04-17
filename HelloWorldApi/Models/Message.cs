using System.ComponentModel.DataAnnotations;


namespace HelloWorldApi.Models
{
    public class Message
    {
        [Key]
        public int id { get; set; }
        public string message { get; set; }
    }
}
