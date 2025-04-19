using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Models;

public enum MomentoEnum
{
    [Display(Name = "Entrada")]
    Entrada = 1,

    [Display(Name = "Saída")]
    Saida = 2,

    [Display(Name = "Errado")]
    Errado = 3
}

public class Momento
{
    public MomentoEnum Id { get; set; }

    [MaxLength(255)]
    public string Nome { get; set; } = default!;
}

public enum PausaEnum
{
    [Display(Name = "Almoço")]
    Almoco = 1,

    [Display(Name = "Café/Lanche")]
    CafeLanche = 2,

    [Display(Name = "Banheiro")]
    Banheiro = 3,

    [Display(Name = "Conversa/Reunião")]
    ConversaReuniao = 4,

    [Display(Name = "Telefonema")]
    Telefonema = 5,

    [Display(Name = "Genérica")]
    Generica = 6
}

public class Pausa
{
    public PausaEnum Id { get; set; }

    [MaxLength(255)]
    public string Nome { get; set; } = default!;
}

public enum TipoImagemEnum
{
    Original = 1,

    Tratada = 2
}

public class TipoImagem
{
    public TipoImagemEnum Id { get; set; }

    [MaxLength(255)]
    public string Nome { get; set; } = default!;
}

public class Ponto : GlobalTableEntity
{
    [Required(ErrorMessage = "'Contrato' deve ser informado.")]
    [DisplayName("Contrato")]
    public Guid? ContratoId { get; set; }

    [DisplayName("Contrato")]
    public Contrato? Contrato { get; set; }

    [Required]
    [DisplayName("Data/Hora")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? DataHora { get; set; }

    [Required]
    [DisplayName("Momento")]
    public MomentoEnum? MomentoId { get; set; }

    [DisplayName("Pausa")]
    public PausaEnum? PausaId { get; set; }

    [Required]
    [DisplayName("Estimado?")]
    public bool Estimado { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }

    [DisplayName("Comprovantes")]
    public virtual IList<Comprovante> Comprovantes { get; set; } = default!;

    public Ponto()
    {
        Comprovantes = new List<Comprovante>();
    }

    public void DesqualificaPonto()
    {
        Contrato = null;

        ContratoId = null;
    }

    public bool EstaQualificado()
    {
        return ContratoId.HasValue;
    }

    public bool EstaSemQualificacao()
    {
        return ContratoId == null;
    }
}

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
