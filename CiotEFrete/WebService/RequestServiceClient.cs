using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using ACBr.Net.Core;
using ACBr.Net.DFe.Core;
using ACBr.Net.DFe.Core.Service;

namespace CiotEFrete.WebService
{
    public abstract class RequestServiceClient : ClientBase<IRequestChannel>
    {
        #region Campos

        protected readonly object serviceLock;
        public string XmlEnvio { get; set; }

        #endregion 

        #region Construtores

        protected RequestServiceClient(string Url, TimeSpan? TimeOut = null) : base(new BasicHttpsBinding(), new EndpointAddress(Url))
        {
            serviceLock = new object();

            if (!TimeOut.HasValue) return;

            Endpoint.Binding.OpenTimeout = TimeOut.Value;
            Endpoint.Binding.ReceiveTimeout = TimeOut.Value;
            Endpoint.Binding.SendTimeout = TimeOut.Value;
        }

        #endregion Constructors

        #region Metodos

        /// <summary>
        /// Executa uma requisição ao webservice.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="msg"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        protected string Execute(string action, string msg, params MessageHeader[] headers)
        {
            lock (serviceLock)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(msg);

                var message = Message.CreateMessage(Endpoint.Binding.MessageVersion, action, xmlDoc.DocumentElement);

                if (headers.Any())
                {
                    foreach (var header in headers)
                        message.Headers.Add(header);
                }

                XmlEnvio = message.ToString();

                var ret = Channel.Request(message);
                Guard.Against<ACBrDFeException>(ret == null, "Nenhum retorno do webservice.");
                var reader = ret.GetReaderAtBodyContents();
                return reader.ReadOuterXml();
            }
        }

        /// <summary>
        /// Cria um Header para ser adicionado ao request.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameSpace"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        protected MessageHeader CreateHeader(string header, string name, string nameSpace = "")
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(header);

            return MessageHeader.CreateHeader(name, nameSpace, xmlDoc.DocumentElement);
        }

        #endregion Methods
    }
}