using System.ComponentModel.DataAnnotations.Schema;
using WebApiCore.Models.BaseModel;

namespace WebApiCore.Models
{
    public class RolUsuario : GenericModel
    {
        public long IdUsuario { get; set; }
        public long IdRol { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
        [ForeignKey("IdRol")]
        public Rol? Rol { get; set; }
    }
}
