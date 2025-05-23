﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Models;

public enum StatusFolhaEnum
{
    Aberta = 0,

    Fechada = 1
}

public class StatusFolha
{
    public StatusFolhaEnum Id { get; set; }

    [MaxLength(255)]
    public string Nome { get; set; } = default!;
}

public class Folha : GlobalTableEntity
{
    [Required]
    [DisplayName("Contrato")]
    public Guid? ContratoId { get; set; }

    [DisplayName("Contrato")]
    public Contrato? Contrato { get; set; }

    [Required]
    [DisplayName("Competência")]
    [DisplayFormat(DataFormatString = "{0:y}")]
    public DateTime? Competencia { get; set; }

    [Required]
    [DisplayName("Status")]
    public StatusFolhaEnum? StatusId { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }

    [DisplayName("Apuração Mensal")]
    public ApuracaoMensal ApuracaoMensal { get; set; }

    public Folha()
    {
        ApuracaoMensal = new ApuracaoMensal();
    }

    public void AssociarAo(Contrato contrato)
    {
        Contrato = contrato;

        ContratoId = contrato.Id;
    }

    public void ConfirmarCompetencia(Contrato? contrato)
    {
        var competenciaAtual = Competencia.Value;

        var competenciaPosterior = competenciaAtual.AddMonths(1);

        var dias = (competenciaPosterior - competenciaAtual).Days;

        if (ApuracaoMensal.Dias.Count == 0)
        {
            for (int dia = 1; dia <= dias; dia++)
            {
                var data = competenciaAtual.AddDays(dia - 1);

                var apuracaoDiaria = new ApuracaoDiaria
                {
                    Dia = dia,
                    TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo,
                    TempoApurado = null,
                    DiferencaTempo = null,
                    Feriado = false,
                    Falta = false
                };

                ApuracaoMensal.Dias.Add(apuracaoDiaria);
            }

            ApuracaoMensal.TempoTotalPeriodoAnterior = TimeSpan.Zero;
        }
        else
        {
            for (int dia = 1; dia <= dias; dia++)
            {
                var data = competenciaAtual.AddDays(dia - 1);

                if (ApuracaoMensal.Dias.Any(x => x.Dia == dia))
                {
                    var apuracaoDiaria = ApuracaoMensal.Dias.First(x => x.Dia == dia);

                    apuracaoDiaria.TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo;
                    apuracaoDiaria.TempoApurado = null;
                    apuracaoDiaria.DiferencaTempo = null;
                    apuracaoDiaria.DiferencaTempo = null;
                    apuracaoDiaria.Feriado = false;
                }
                else
                {
                    var apuracaoDiaria = new ApuracaoDiaria
                    {
                        Dia = dia,
                        TempoPrevisto = contrato.JornadaTrabalhoSemanalPrevista.Semana.Single(x => x.DiaSemana == data.DayOfWeek).Tempo,
                        TempoApurado = null,
                        DiferencaTempo = null,
                        Feriado = false,
                        Falta = false,
                        Observacao = null
                    };

                    ApuracaoMensal.Dias.Add(apuracaoDiaria);
                }
            }

            ApuracaoMensal.TempoTotalPeriodoAnterior = TimeSpan.Zero;
        }
    }
}

//[Owned]
public class ApuracaoMensal
{
    [DisplayName("Dias")]
    public IList<ApuracaoDiaria> Dias { get; set; }

    [DisplayName("Total Dias")]
    public int TotalDias { get => Dias.Count; }

    [DisplayName("Tempo Total Previsto")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalPrevisto
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.TempoPrevisto.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.TempoPrevisto;
                }
            }

            return total;
        }
    }

    [DisplayName("Tempo Total Apurado")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalApurado
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.TempoApurado.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.TempoApurado + (apuracaoDiaria.TempoAbonado ?? TimeSpan.Zero);
                }
            }

            return total;
        }
    }

    [DisplayName("Diferença Tempo Total")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? DiferencaTempoTotal
    {
        get
        {
            TimeSpan? total = null;

            foreach (var apuracaoDiaria in Dias)
            {
                if (apuracaoDiaria.DiferencaTempo.HasValue)
                {
                    total = (total ?? TimeSpan.Zero) + apuracaoDiaria.DiferencaTempo;
                }
            }

            return total;
        }
    }

    [DisplayName("Tempo Total Período Anterior")]
    //[DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan? TempoTotalPeriodoAnterior { get; set; }

    public ApuracaoMensal()
    {
        Dias = new List<ApuracaoDiaria>();
    }
}

//[Owned]
public class ApuracaoDiaria
{
    [Required]
    [DisplayName("Dia")]
    public int? Dia { get; set; }

    [Required]
    [DisplayName("Tempo Previsto")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoPrevisto { get; set; }

    [DisplayName("Tempo Apurado")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoApurado { get; set; }

    [DisplayName("Diferença Tempo")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? DiferencaTempo { get; set; }

    [DisplayName("Tempo Abonado")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? TempoAbonado { get; set; }

    [Required]
    [DisplayName("Feriado?")]
    public bool Feriado { get; set; }

    [Required]
    [DisplayName("Falta?")]
    public bool Falta { get; set; }

    [MinLength(3)]
    [MaxLength(255)]
    [DisplayName("Observação")]
    public string? Observacao { get; set; }
}
