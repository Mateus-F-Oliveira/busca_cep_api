using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiBuscaCepV2.Models;
[Table("Enderecos")]
public class Endereco
{
    [Key]
    public int EnderecoId { get; set; }
    [Required]
    [StringLength(10)]
    public string? Cep { get; set; }
    [Required]
    [StringLength(100)]
    public string? Rua { get; set; }
    [Required]
    [StringLength(100)]
    public string? Bairro { get; set; }
    [Required]
    [StringLength(100)]
    public string? Cidade { get; set; }
    [Required]
    [StringLength(2)]
    public string? UF { get; set; }
    [Required]
    public int UsuarioId { get; set; }
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
}