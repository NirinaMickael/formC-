using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
namespace Cours.Models;
public class IUserViewModel
{
    [Required(AllowEmptyStrings = false)]
    [DataType(DataType.Text)]
    [StringLength(30)]
    public string Name { get; set; } = "";
    [Required(AllowEmptyStrings = false)]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string Email { get; set; } = "";
    [Required(AllowEmptyStrings = false)]
    [DataType(DataType.Text)]
    [StringLength(6)]
    public string Password { get; set; } = "";
}
public class UserViewModel
{
    public List<IUserViewModel> Users { get; set; } = new List<IUserViewModel>();
}