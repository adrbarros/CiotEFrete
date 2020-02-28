using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.WebService
{
    public sealed class PefServiceClient : RequestServiceClient
    {
        #region Construtores

        public PefServiceClient(TimeSpan? TimeOut = null) : base("https://dev.efrete.com.br/Services/PefService.asmx", TimeOut)
        {
        }

        #endregion Constructors
        
        #region Metodos

        public string AdicionarOperacaoTransportePef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<AdicionarOperacaoTransporte xmlns=\"http://schemas.ipc.adm.br/efrete/pef\">");
            request.Append(innerXml);
            request.Append("</AdicionarOperacaoTransporte>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/AdicionarOperacaoTransporte", request.ToString());
        }

        public string AdicionarPagamentoPef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<AdicionarPagamento xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</AdicionarPagamento>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/AdicionarPagamento", request.ToString());
        }

        public string ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente", request.ToString());
        }

        public string ObterOperacaoTransportePdfPef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<ObterOperacaoTransportePdf xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</ObterOperacaoTransportePdf>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/ObterOperacaoTransportePdf", request.ToString());
        }

        public string RetificarOperacaoTransportePef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<RetificarOperacaoTransporte xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</RetificarOperacaoTransporte>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/RetificarOperacaoTransporte", request.ToString());
        }

        public string CancelarOperacaoTransportePef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<CancelarOperacaoTransporte xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</CancelarOperacaoTransporte>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/CancelarOperacaoTransporte", request.ToString());
        }

        public string EncerrarOperacaoTransportePef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<EncerrarOperacaoTransporte xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</EncerrarOperacaoTransporte>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/EncerrarOperacaoTransporte", request.ToString());
        }

        public string AdicionarViagemPef(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<AdicionarViagem xmlns=\"http://schemas.ipc.adm.br/efrete/pef\" > ");
            request.Append(innerXml);
            request.Append("</AdicionarViagem>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/pef/AdicionarViagem", request.ToString());
        }

        #endregion
    }
}
