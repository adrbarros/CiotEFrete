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
    public sealed class VeiculoGravarResult : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades
        
        [DFeElement("Excecao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public Excecao Excecao { get; set; }

        [DFeIgnore]
        public bool Sucesso { get; set; }

        [DFeElement(TipoCampo.Str, "Sucesso", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string SucessoProxy
        {
            get => Sucesso ? "true" : "false";
            set => Sucesso = value == "true";
        }

        [DFeElement("Veiculo", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public VeiculoGravar Veiculo { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public long Versao { get; set; }

        #endregion
    }
}
