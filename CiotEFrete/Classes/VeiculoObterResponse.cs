using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterPorPlacaResponse", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos")]
    public sealed class VeiculoObterResponse : DFeDocument<VeiculoObterResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("ObterPorPlacaResult", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public VeiculoObterResult Result { get; set; }

        #endregion
    }
}
