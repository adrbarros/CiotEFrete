using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.WebService
{
    public sealed class VeiculosServiceClient : RequestServiceClient
    {
        #region Construtores

        public VeiculosServiceClient(TimeSpan? TimeOut = null) : base("https://dev.efrete.com.br/Services/VeiculosService.asmx", TimeOut)
        {
        }

        #endregion

        #region Metodos

        public string VeiculoGravar(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Gravar xmlns=\"http://schemas.ipc.adm.br/efrete/veiculos\">");
            request.Append(innerXml);
            request.Append("</Gravar>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/veiculos/Gravar", request.ToString());
        }

        public string VeiculoObter(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<ObterPorPlaca xmlns=\"http://schemas.ipc.adm.br/efrete/veiculos\">");
            request.Append(innerXml);
            request.Append("</ObterPorPlaca>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/veiculos/ObterPorPlaca", request.ToString());
        }

        #endregion
    }
}
