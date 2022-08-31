using WebApiCore.Models.BaseModel;

namespace WebApiCore.Models
{
    public class Usuario : GenericModel
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
