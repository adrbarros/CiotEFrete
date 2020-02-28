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
    public sealed class PefAdicionarOperacaoTransporteContratante : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Rntrc { get; set; }

        [DFeElement(TipoCampo.Str, "NomeOuRazaoSocial", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string NomeOuRazaoSocial { get; set; }

        [DFeElement(TipoCampo.Str, "CpfOuCnpj", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string CpfOuCnpj { get; set; }
                
        [DFeElement("Endereco", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public PefAdicionarOperacaoTransporteEndereco Endereco { get; set; }

        [DFeElement(TipoCampo.Str, "EMail", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public string Email { get; set; }

        [DFeElement("Telefones", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public Telefones Telefones { get; set; }

        [DFeIgnore]
        public bool ResponsavelPeloPagamento { get; set; }

        [DFeElement(TipoCampo.Str, "ResponsavelPeloPagamento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public string ResponsavelPeloPagamentoProxy
        {
            get => ResponsavelPeloPagamento ? "true" : "false";
            set => ResponsavelPeloPagamento = value == "true";
        }

        #endregion
    }
}
