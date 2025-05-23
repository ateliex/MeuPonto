﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPonto.Models;

public class Contrato : GlobalTableEntity
{
    [Required]
    [MinLength(3, ErrorMessage = "'Nome' deve ser maior ou igual a 3 caracteres.")]
    [MaxLength(35, ErrorMessage = "'Nome' deve ser menor ou igual a 35 caracteres.")]
    [DisplayName("Nome")]
    public string? Nome { get; set; }

    [Required]
    [DisplayName("Ativo?")]
    public bool Ativo { get; set; }

    [DisplayName("Empregador")]
    public Guid? EmpregadorId { get; set; }

    [DisplayName("Empregador")]
    public Empregador? Empregador { get; set; }

    [DisplayName("Jornada Trabalho Semanal Prevista")]
    public virtual JornadaTrabalhoSemanal JornadaTrabalhoSemanalPrevista { get; set; } = default!;

    public Contrato(string nome)
    {
        Nome = nome;
        Ativo = true;

        JornadaTrabalhoSemanalPrevista = new JornadaTrabalhoSemanal
        {
            Semana = new List<JornadaTrabalhoDiaria>(new[]{
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Monday,
                            Tempo = new TimeSpan(8,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Tuesday,
                            Tempo = new TimeSpan(8,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Wednesday,
                            Tempo = new TimeSpan(8,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Thursday,
                            Tempo = new TimeSpan(8,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Friday,
                            Tempo = new TimeSpan(8,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Saturday,
                            Tempo = new TimeSpan(0,0,0)
                        },
                        new JornadaTrabalhoDiaria
                        {
                            DiaSemana = DayOfWeek.Sunday,
                            Tempo = new TimeSpan(0,0,0)
                        }
                    })
        };
    }

    public void AlteraNome(string nome)
    {
        Nome = nome;
    }

    public void Ativar()
    {
        Ativo = true;
    }

    public void QualificaPonto(Ponto ponto)
    {
        ponto.Contrato = this;

        ponto.ContratoId = this.Id;
    }

    public void FeitoCom(Empregador empregador)
    {
        Empregador = empregador;

        EmpregadorId = empregador?.Id;
    }

    public Contrato()
    {
        JornadaTrabalhoSemanalPrevista = new JornadaTrabalhoSemanal();
    }

    public override string ToString()
    {
        return Nome;
    }
}

//[Owned]
public class JornadaTrabalhoSemanal
{
    [DisplayName("Semana")]
    public virtual IList<JornadaTrabalhoDiaria> Semana { get; set; } = default!;

    [DisplayName("Tempo Total")]
    [DisplayFormat(DataFormatString = "{0:d\\d\\ hh\\:mm}")]
    public TimeSpan TempoTotal
    {
        get
        {
            TimeSpan tempoTotal = TimeSpan.Zero;

            foreach (var jornadaTrabalhoDiaria in Semana)
            {
                tempoTotal += jornadaTrabalhoDiaria.Tempo ?? TimeSpan.Zero;
            }

            return tempoTotal;
        }
    }

    public JornadaTrabalhoSemanal()
    {
        Semana = new List<JornadaTrabalhoDiaria>();
    }
}

//[Owned]
public class JornadaTrabalhoDiaria
{
    [Required]
    [DisplayName("Dia Semana")]
    public DayOfWeek? DiaSemana { get; set; }

    [Required]
    [DisplayName("Tempo")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan? Tempo { get; set; }
}

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
