using System.ComponentModel.DataAnnotations;

namespace NerdStore.Enterprise.Core.Application.Dtos
{
    public class ChagePasswordDTO
    {
        [Required]
        public int Id { get; set; } 

        [Required]
        public string Password { get; set; }
    }
}
