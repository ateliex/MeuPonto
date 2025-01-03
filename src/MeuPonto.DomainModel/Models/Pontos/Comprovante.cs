﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MeuPonto.Models.Pontos;

public class Comprovante : GlobalTableEntity
{
    [Required]
    [DisplayName("Ponto")]
    public Guid? PontoId { get; set; }

    [DisplayName("Ponto")]
    public Ponto? Ponto { get; set; }

    [Required]
    [DisplayName("Imagem")]
    public byte[]? Imagem { get; set; }

    [Required]
    [DisplayName("Tipo Imagem")]
    public TipoImagemEnum? TipoImagemId { get; set; }

    public void ComprovaPonto(Ponto ponto)
    {
        Ponto = ponto;

        PontoId = ponto.Id;
    }
}
