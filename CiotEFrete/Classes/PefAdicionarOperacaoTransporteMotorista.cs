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
    public sealed class PefAdicionarOperacaoTransporteMotorista : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CpfOuCnpj", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string CpfOuCnpj { get; set; }

        [DFeElement(TipoCampo.Str, "CNH", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Cnh { get; set; }

        [DFeElement("Celular", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public Telefone Celular { get; set; }

        #endregion
    }
}
