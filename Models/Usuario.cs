using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiBuscaCepV2.Models;
[Table("Usuario")]
public class Usuario
{
    public Usuario()
    {
        Enderecos = new Collection<Endereco>();
    }
    [Key]
    public int UsuarioId { get; set; }
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(100)]
    public string? Email { get; set; }
    [Required]
    [StringLength(100)]
    public string? Senha { get; set; }
    [JsonIgnore]
    public ICollection<Endereco>? Enderecos { get; set; }
}