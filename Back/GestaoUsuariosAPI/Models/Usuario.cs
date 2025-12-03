using System.ComponentModel.DataAnnotations;

namespace GestaoUsuariosAPI;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string NomeCompleto { get; set; } = string.Empty;
    [Required(ErrorMessage = "O email é obrigatório")]
    public string Email { get; set; } = string.Empty;
    [Required]
    public int Celular { get; set; }
    [Required]
    [MaxLength(8, ErrorMessage = "A senha deve ter no máximo 8 caracteres")]
    public string Senha { get; set; } = string.Empty;
    [Required]
    public string ConfirmarSenha { get; set; } = string.Empty;

}
