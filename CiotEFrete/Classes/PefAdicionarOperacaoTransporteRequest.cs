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
    #region Enums

    public enum TipoViagem
    {
        Padrao = 0,
        TAC_Agregado = 1
    }

    public enum TipoEmbalagem
    {
        Bigbag = 0,
        Pallet = 1,
        Granel = 2,
        Container = 3,
        Saco = 4,
        Caixa = 5,
        Unitario = 6,
        Fardo = 7
    }

    public enum EntregaDocumentacao
    {
        RedeCredenciada = 0,
        Cliente = 1
    }

    #endregion

    [DFeRoot("AdicionarOperacaoTransporteRequest", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects")]
    public sealed class PefAdicionarOperacaoTransporteRequest : DFeDocument<PefAdicionarOperacaoTransporteRequest>, INotifyPropertyChanged    
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Construtores
        public PefAdicionarOperacaoTransporteRequest()
        {
            Versao = 7;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public PefAdicionarOperacaoTransporteRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion

        #region Propriedades

        [DFeIgnore]
        public TipoViagem TipoViagem { get; set; }

        [DFeElement(TipoCampo.Str, "TipoViagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string TipoViagemProxy
        {
            get => this.TipoViagem == TipoViagem.Padrao ? "Padrao" : "TAC_Agregado";
            set => this.TipoViagem = value == "TAC_Agregado" ? TipoViagem.TAC_Agregado : TipoViagem.Padrao;
        }

        [DFeIgnore]
        public TipoPagamento TipoPagamento { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPagamento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string TipoPagamentoProxy
        {
            get
            {
                switch (TipoPagamento)
                {
                    case TipoPagamento.eFRETE: return "eFRETE";
                    case TipoPagamento.TransferenciaBancaria: return "TransferenciaBancaria";
                    case TipoPagamento.Outros: return "Outros";
                    default: throw new NotImplementedException("Tipo de pagamento não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "efrete": TipoPagamento = TipoPagamento.eFRETE; break;
                    case "transferenciabancaria": TipoPagamento = TipoPagamento.TransferenciaBancaria; break;
                    case "outros": TipoPagamento = TipoPagamento.Outros; break;
                    default: throw new NotImplementedException("Tipo de pagamento não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public int Versao { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Token { get; set; }

        [DFeIgnore]
        public bool EmissaoGratuita { get; set; }

        [DFeElement(TipoCampo.Str, "EmissaoGratuita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public string EmissaoGratuitaProxy
        {
            get => EmissaoGratuita ? "true" : "false";
            set => EmissaoGratuita = value == "true";
        }

        [DFeIgnore]
        public bool BloquearNaoEquiparado { get; set; }

        [DFeElement(TipoCampo.Str, "BloquearNaoEquiparado", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public string BloquearNaoEquiparadoProxy
        {
            get => BloquearNaoEquiparado ? "true" : "false";
            set => BloquearNaoEquiparado = value == "true";
        }

        [DFeElement(TipoCampo.Str, "MatrizCNPJ", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public string MatrizCnpj { get; set; }

        [DFeElement(TipoCampo.Str, "FilialCNPJ", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string FilialCnpj { get; set; }

        [DFeElement(TipoCampo.Str, "IdOperacaoCliente", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public string IdOperacaoCliente { get; set; }

        [DFeIgnore]
        public DateTime? DataInicioViagem { get; set; }

        [DFeElement(TipoCampo.Str, "DataInicioViagem", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 10)]
        public string DataInicioViagemProxy
        {
            get => DataInicioViagem?.ToString("yyyy-MM-dd");
            set => DataInicioViagem = DateTime.Parse(value);
        }

        [DFeIgnore]
        public DateTime DataFimViagem { get; set; }

        [DFeElement(TipoCampo.Str, "DataFimViagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 11)]
        public string DataFimViagemProxy
        {
            get => DataFimViagem.ToString("yyyy-MM-dd");
            set => DataFimViagem = DateTime.Parse(value);
        }

        [DFeElement(TipoCampo.Str, "CodigoNCMNaturezaCarga", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 12)]
        public string CodigoNcmNaturezaCarga { get; set; }

        [DFeElement(TipoCampo.De6, "PesoCarga", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 13)]
        public decimal PesoCarga { get; set; }

        [DFeIgnore]
        public TipoEmbalagem? TipoEmbalagem { get; set; }

        [DFeElement(TipoCampo.Str, "TipoEmbalagem", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 14)]
        public string TipoEmbalagemProxy
        {
            get
            {
                if (!TipoEmbalagem.HasValue)
                    return null;

                switch (TipoEmbalagem.Value)
                {
                    case Classes.TipoEmbalagem.Bigbag: return "Bigbag";
                    case Classes.TipoEmbalagem.Pallet: return "Pallet";
                    case Classes.TipoEmbalagem.Granel: return "Granel";
                    case Classes.TipoEmbalagem.Container: return "Container";
                    case Classes.TipoEmbalagem.Saco: return "Saco";
                    case Classes.TipoEmbalagem.Caixa: return "Caixa";
                    case Classes.TipoEmbalagem.Unitario: return "Unitario";
                    case Classes.TipoEmbalagem.Fardo: return "Fardo";
                    default: throw new NotImplementedException("Tipo de embalagem não implementado");
                }
            }

            set
            {
                if (value.IsNull())
                    TipoEmbalagem = null;

                switch (value.ToLower())
                {
                    case "bigbag": TipoEmbalagem = Classes.TipoEmbalagem.Bigbag; break;
                    case "pallet": TipoEmbalagem = Classes.TipoEmbalagem.Pallet; break;
                    case "granel": TipoEmbalagem = Classes.TipoEmbalagem.Granel; break;
                    case "container": TipoEmbalagem = Classes.TipoEmbalagem.Container; break;
                    case "saco": TipoEmbalagem = Classes.TipoEmbalagem.Saco; break;
                    case "caixa": TipoEmbalagem = Classes.TipoEmbalagem.Caixa; break;
                    case "unitario": TipoEmbalagem = Classes.TipoEmbalagem.Unitario; break;
                    case "fardo": TipoEmbalagem = Classes.TipoEmbalagem.Fardo; break;
                    default: throw new NotImplementedException("Tipo de embalagem não implementado");
                }
            }
        }
                
        [DFeElement("Viagens", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 15)]
        public PefAdicionarOperacaoTransporteViagens Viagens { get; set; }

        [DFeElement("Impostos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 16)]
        public PefAdicionarOperacaoTransporteImpostos Impostos { get; set; }

        [DFeCollection("Pagamentos", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 17)]
        public List<PefAdicionarOperacaoTransportePagamentos> Pagamentos { get; set; }

        [DFeElement("Contratado", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 18)]
        public PefAdicionarOperacaoTransporteContratado Contratado { get; set; }

        [DFeElement("Motorista", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 19)]
        public PefAdicionarOperacaoTransporteMotorista Motorista { get; set; }

        [DFeElement("Destinatario", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 20)]
        public PefAdicionarOperacaoTransporteDestinatario Destinatario { get; set; }

        [DFeElement("Contratante", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 21)]
        public PefAdicionarOperacaoTransporteContratante Contratante { get; set; }

        [DFeElement("Subcontratante", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 22)]
        public PefAdicionarOperacaoTransporteDestinatario SubContratante { get; set; }

        [DFeElement("Consignatario", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 23)]
        public PefAdicionarOperacaoTransporteDestinatario Consignatario { get; set; }

        [DFeElement("TomadorServico", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 24)]
        public PefAdicionarOperacaoTransporteDestinatario TomadorServico { get; set; }

        [DFeElement("Veiculos", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 25)]
        public PefAdicionarOperacaoTransporteVeiculos Veiculos { get; set; }

        [DFeElement(TipoCampo.Str, "CodigoIdentificacaoOperacaoPrincipal", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 26)]
        public string CodigoIdentificacaoOperacaoPrincipal { get; set; }
               
        [DFeElement("ObservacoesAoTransportador", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 27)]
        public PefAdicionarOperacaoTransporteObservacoes ObservacoesTransportador { get; set; }

        [DFeElement("ObservacoesAoCredenciado", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 28)]
        public PefAdicionarOperacaoTransporteObservacoes ObservacoesCredenciado { get; set; }

        [DFeIgnore]
        public EntregaDocumentacao EntregaDocumentacao { get; set; }

        [DFeElement(TipoCampo.Str, "EntregaDocumentacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 29)]
        public string EntregaDocumentacaoProxy
        {
            get => this.EntregaDocumentacao == EntregaDocumentacao.RedeCredenciada ? "RedeCredenciada" : "Cliente";
            set => this.EntregaDocumentacao = value == "Cliente" ? EntregaDocumentacao.Cliente : EntregaDocumentacao.RedeCredenciada;
        }

        [DFeElement(TipoCampo.Int, "QuantidadeSaques", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 30)]
        public int QuantidadeSaques { get; set; }

        [DFeElement(TipoCampo.Int, "QuantidadeTransferencias", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 31)]
        public int QuantidadeTransferencias { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoTipoCarga", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 32)]
        public int CodigoTipoCarga { get; set; }

        [DFeIgnore]
        public bool AltoDesempenho { get; set; }

        [DFeElement(TipoCampo.Str, "AltoDesempenho", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 33)]
        public string AltoDesempenhoProxy
        {
            get => AltoDesempenho ? "true" : "false";
            set => AltoDesempenho = value == "true";
        }

        [DFeIgnore]
        public bool DestinacaoComercial { get; set; }

        [DFeElement(TipoCampo.Str, "DestinacaoComercial", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 34)]
        public string DestinacaoComercialProxy
        {
            get => DestinacaoComercial ? "true" : "false";
            set => DestinacaoComercial = value == "true";
        }

        [DFeIgnore]
        public bool FreteRetorno { get; set; }

        [DFeElement(TipoCampo.Str, "FreteRetorno", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 35)]
        public string FreteRetornoProxy
        {
            get => FreteRetorno ? "true" : "false";
            set => FreteRetorno = value == "true";
        }

        [DFeElement(TipoCampo.Str, "CepRetorno", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 36)]
        public string CepRetorno { get; set; }

        [DFeElement(TipoCampo.Int, "DistanciaRetorno", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 37)]
        public int DistanciaRetorno { get; set; }

        #endregion
    }
}
