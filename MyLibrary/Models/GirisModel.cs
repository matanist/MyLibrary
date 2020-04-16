
using System.ComponentModel.DataAnnotations;

public class GirisModel
    {
    [Required(ErrorMessage = "UserName is required")]
    public string KADI{ get; set; }
    [Required(ErrorMessage = "UserName is required")]
    public string PASS{ get; set; }
    }
