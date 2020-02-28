using ACBr.Net.DFe.Core.Attributes;
using System.ComponentModel;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    public sealed class Excecao : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Mensagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Mensagem { get; set; }

        [DFeElement(TipoCampo.Str, "Codigo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Codigo { get; set; }

        #endregion 
    }
}