﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeuPonto.Models.Contratos;

public class Empregador : GlobalTableEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(35)]
    [DisplayName("Nome")]
    public string? Nome { get; set; }

    public override string ToString()
    {
        return Nome;
    }
}
