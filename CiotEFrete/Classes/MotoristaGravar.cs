﻿using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    public class MotoristaGravar : INotifyPropertyChanged
    {
        #region Eventos 

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CNH", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Cnh { get; set; }

        [DFeElement(TipoCampo.Str, "CPF", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Cpf { get; set; }

        [DFeIgnore]
        public DateTime DataNascimento { get; set; }

        [DFeElement(TipoCampo.Str, "DataNascimento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string DataNascimentoProxy
        {
            get => DataNascimento.ToString("dd/mm/yyyy");
            set => DataNascimento = DateTime.Parse(value);
        }

        [DFeElement("Endereco", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public Endereco Endereco { get; set; }

        [DFeElement(TipoCampo.Str, "Nome", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string Nome { get; set; }

        [DFeElement(TipoCampo.Str, "NomeDeSolteiroDaMae", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public string NomeDeSolteiroDaMae { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public Telefones Telefones { get; set; }

        #endregion 
    }
}
