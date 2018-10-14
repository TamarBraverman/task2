
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace API.Models
{
  public class User
  {
    [Required]
    [Key]
    [MaxLength(10, ErrorMessage = "name must be less than  10 chars")]
    [MinLength(2, ErrorMessage = "name must be more than  chars")]
    public string UserName { get; set; }
    [Required]
    [Range(18, 120, ErrorMessage = "age must be between 18-120")]
    public int Age { get; set; }
    public string PartnerUserName { get; set; }
    [DefaultValue(0)]
    public int Score { get; set; }
  }
}
