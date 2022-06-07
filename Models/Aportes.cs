using System.ComponentModel.DataAnnotations;

namespace AportesBlazor.Models
{
    public class Aportes
    {
        [Key]
        public int AporteID { get; set; }
        
        [Required(ErrorMessage = "Debe escribir el nombre de la persona responsable!")]
        public string? Persona { get; set; }

        [Range(1, double.PositiveInfinity, ErrorMessage = "Debe escribir el monto!")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Debe escribir el nombre de la persona responsable!")]
        public DateTime Fecha { get; set; }
    }
}
