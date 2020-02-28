using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CiotEFrete.WebService
{
    public sealed class MotoristasServiceClient : RequestServiceClient
    {
        #region Construtores

        public MotoristasServiceClient(TimeSpan? TimeOut = null) : base("https://dev.efrete.com.br/Services/MotoristasService.asmx", TimeOut)
        {
        }

        #endregion 

        #region Metodos

        public string MotoristaGravar(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Gravar xmlns=\"http://schemas.ipc.adm.br/efrete/motoristas\">");
            request.Append(innerXml);
            request.Append("</Gravar>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/motoristas/Gravar", request.ToString());
        }

        public string MotoristaObter(string innerXml)
        {
            var request = new StringBuilder();
            request.Append("<Obter xmlns=\"http://schemas.ipc.adm.br/efrete/motoristas\">");
            request.Append(innerXml);
            request.Append("</Obter>");

            return Execute(@"http://schemas.ipc.adm.br/efrete/motoristas/Obter", request.ToString());
        }

        #endregion 
    }
}