using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.WebService
{
    public sealed class ProprietariosServiceClient : RequestServiceClient
    {
        #region Construtores

        public ProprietariosServiceClient(TimeSpan? TimeOut = null) : base("https://dev.efrete.com.br/Services/ProprietariosService.asmx", TimeOut)
        {
        }

        #endregion Constructors

        #region Metodos

        public string ProprietarioGravar(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Gravar xmlns=\"http://schemas.ipc.adm.br/efrete/proprietarios\">");
            request.Append(innerXml);
            request.Append("</Gravar>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/proprietarios/Gravar", request.ToString());
        }

        public string ProprietarioObter(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Obter xmlns=\"http://schemas.ipc.adm.br/efrete/proprietarios\">");
            request.Append(innerXml);
            request.Append("</Obter>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/proprietarios/Obter", request.ToString());
        }

        #endregion Methods
    }
}