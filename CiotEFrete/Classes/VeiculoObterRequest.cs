using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterPorPlacaRequest", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos/objects")]
    public sealed class VeiculoObterRequest : DFeDocument<VeiculoObterRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Eventos

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Placa", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Placa { get; set; }

        [DFeElement(TipoCampo.Str, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Rntrc { get; set; }

        #endregion
    }
}
