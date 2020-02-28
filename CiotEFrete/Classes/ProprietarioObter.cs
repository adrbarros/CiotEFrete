using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    #region Enums

    public enum TipoProprietario
    {
        TAC = 0,
        ETC = 1,
        CTC = 2
    }

    #endregion

    public class ProprietarioObter : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CNPJ", Ocorrencia = Ocorrencia.Obrigatoria)]
        public string Cnpj { get; set; }

        [DFeIgnore]
        public TipoPessoa TipoPessoa { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPessoa", Ocorrencia = Ocorrencia.Obrigatoria)]
        public string TipoPessoaProxy
        {
            get => this.TipoPessoa == TipoPessoa.Fisica ? "Fisica" : "Juridica";
            set => this.TipoPessoa = value == "Juridica" ? TipoPessoa.Juridica : TipoPessoa.Fisica;
        }

        [DFeElement(TipoCampo.Str, "RazaoSocial", Ocorrencia = Ocorrencia.Obrigatoria)]
        public string RazaoSocial { get; set; }

        [DFeElement(TipoCampo.Int, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria)]
        public long Rntrc { get; set; }

        [DFeIgnore]
        public TipoProprietario? Tipo { get; set; }
                
        [DFeElement(TipoCampo.Str, "Tipo", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string TipoProxy
        {
            get
            {
                if (!Tipo.HasValue)
                    return null;

                switch (Tipo.Value)
                {
                    case TipoProprietario.CTC: return "CTC";
                    case TipoProprietario.ETC: return "ETC";
                    case TipoProprietario.TAC: return "TAC";
                    default: throw new NotImplementedException("Tipo de proprietário não implementado");
                }
            }

            set
            {
                if (value.IsNull())
                    Tipo = null;

                switch (value.ToLower())
                {
                    case "ctc": Tipo = TipoProprietario.CTC; break;
                    case "etc": Tipo = TipoProprietario.ETC; break;
                    case "tac": Tipo = TipoProprietario.TAC; break;
                    default: throw new NotImplementedException("Tipo de proprietário não implementado");
                }
            }
        }

        [DFeIgnore]
        public bool TacOuEquiparado {get; set; }

        [DFeElement(TipoCampo.Str, "TACouEquiparado", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string TacOuEquiparadoProxy
        {
            get => TacOuEquiparado ? "TAC" : "Equiparado";
            set => TacOuEquiparado = value == "true";
        }

        [DFeElement("Endereco", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public Endereco Endereco { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public Telefones Telefones { get; set; }

        [DFeIgnore]
        public DateTimeOffset DataValidadeRntrc { get; set; }

        [DFeElement(TipoCampo.Str, "DataValidadeRNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public string DataValidadeRntrcProxy
        {
            get => DataValidadeRntrc.ToString();
            set => DataValidadeRntrc = DateTimeOffset.Parse(value);
        }

        [DFeIgnore]
        public bool RntrcAtivo { get; set; }

        [DFeElement(TipoCampo.Str, "RNTRCAtivo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 10)]
        public string RntrcAtivoProxy
        {
            get => RntrcAtivo ? "true" : "false";
            set => RntrcAtivo = value == "true";
        }
        
        #endregion
    }
}
