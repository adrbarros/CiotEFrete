using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterRequest", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas/objects")]
    public sealed class MotoristaObterRequest : DFeDocument<MotoristaObterRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CPF", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string Cpf { get; set; }

        [DFeElement(TipoCampo.Str, "CNH", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string Cnh { get; set; }

        #endregion
    }
}
