using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CiotEFrete.WebService
{
    public sealed class LogonServiceClient : RequestServiceClient
    {
        #region Construtores

        public LogonServiceClient(TimeSpan? TimeOut = null) : base("https://dev.efrete.com.br/Services/LogonService.asmx", TimeOut)
        {
        }

        #endregion 

        #region Metodos

        public string Login(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Login xmlns=\"http://schemas.ipc.adm.br/efrete/logon\">");
            request.Append(innerXml);
            request.Append("</Login>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/logon/Login", request.ToString());
        }

        public string Logout(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Logout xmlns=\"http://schemas.ipc.adm.br/efrete/logon\">");
            request.Append(innerXml);
            request.Append("</Logout>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/logon/Logout", request.ToString());
        }

        #endregion Methods
    }
}