using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.ComponentModel;

namespace CiotEFrete.Classes
{
    public sealed class PefAdicionarPagamentoPagamentoDados : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeIgnore]
        public CategoriaPagamento Categoria { get; set; }

        [DFeElement(TipoCampo.Str, "Categoria", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string CategoriaProxy
        {
            get
            {
                switch (Categoria)
                {
                    case CategoriaPagamento.Adiantamento: return "Adiantamento";
                    case CategoriaPagamento.Estadia: return "Estadia";
                    case CategoriaPagamento.Quitacao: return "Quitacao";
                    case CategoriaPagamento.SemCategoria: return "SemCategoria (Livre)";
                    default: throw new NotImplementedException("Categoria não implementada");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "adiantamento": Categoria = CategoriaPagamento.Adiantamento; break;
                    case "estadia": Categoria = CategoriaPagamento.Estadia; break;
                    case "quitacao": Categoria = CategoriaPagamento.Quitacao; break;
                    case "semcategoria": Categoria = CategoriaPagamento.SemCategoria; break;
                    default: throw new NotImplementedException("Categoria não implementada");
                }
            }
        }

        [DFeIgnore]
        public DateTime DataLiberacao { get; set; }

        [DFeElement(TipoCampo.Str, "DataDeLiberacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string DataLiberacaoViagemProxy
        {
            get => DataLiberacao.ToString("yyyy-MM-dd");
            set => DataLiberacao = DateTime.Parse(value);
        }

        [DFeElement(TipoCampo.Str, "Documento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Documento { get; set; }

        [DFeElement(TipoCampo.Str, "IdPagamentoCliente", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string IdPagamentoCliente { get; set; }

        [DFeElement(TipoCampo.Str, "InformacaoAdicional", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public string InformacaoAdicional { get; set; }

        [DFeElement(TipoCampo.Str, "CnpjFilialAbastecimento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public string CnpjFilialAbastecimento { get; set; }

        [DFeElement("InformacoesBancarias", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public PefAdicionarPagamentoInformacoesBancarias InformacoesBancarias { get; set; }

        [DFeIgnore]
        public TipoPagamento Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPagamento", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string TipoProxy
        {
            get => this.Tipo == TipoPagamento.TransferenciaBancaria ? "TransferenciaBancaria" : "eFRETE";
            set => this.Tipo = value == "eFRETE" ? TipoPagamento.eFRETE : TipoPagamento.TransferenciaBancaria;
        }

        [DFeElement(TipoCampo.De2, "Valor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public decimal Valor { get; set; }

        #endregion
    }
}
