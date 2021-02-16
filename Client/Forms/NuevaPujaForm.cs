using System.ComponentModel.DataAnnotations;

public class NuevaPujaForm
{
    [Required]
    public string Usuario { get; set; }

    [Required]
    public decimal Monto { get; set; }
}