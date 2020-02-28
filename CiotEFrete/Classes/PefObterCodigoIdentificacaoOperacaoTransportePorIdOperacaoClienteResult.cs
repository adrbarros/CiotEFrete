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

    public enum EstadoCiot
    {
        EmViagem = 0,
        Encerrado = 1,
        Cancelado = 2
    }

    #endregion

    public sealed class PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResult : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("Excecao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public Excecao Excecao { get; set; }

        [DFeIgnore]
        public bool Sucesso { get; set; }

        [DFeElement(TipoCampo.Str, "Sucesso", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string SucessoProxy
        {
            get => Sucesso ? "true" : "false";
            set => Sucesso = value == "true";
        }

        [DFeElement(TipoCampo.Str, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Versao { get; set; }

        [DFeElement(TipoCampo.Str, "CodigoIdentificacaoOperacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string CodigoIdentificacaoOperacao { get; set; }

        [DFeIgnore]
        public EstadoCiot EstadoCiot { get; set; }

        [DFeElement(TipoCampo.Str, "EstadoCiot", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string EstadoCiotProxy
        {
            get
            {
                switch (EstadoCiot)
                {
                    case EstadoCiot.EmViagem: return "Em Viagem";
                    case EstadoCiot.Encerrado: return "Encerrado";
                    case EstadoCiot.Cancelado: return "Cancelado";
                    default: throw new NotImplementedException("Estado do CIOT não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "em viagem": EstadoCiot = EstadoCiot.EmViagem; break;
                    case "encerrado": EstadoCiot = EstadoCiot.Encerrado; break;
                    case "cancelado": EstadoCiot = EstadoCiot.Cancelado; break;
                    default: throw new NotImplementedException("Estado do CIOT não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.Str, "Protocolo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string Protocolo { get; set; }

        #endregion

    }
}
