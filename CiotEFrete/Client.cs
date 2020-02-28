using CiotEFrete.Classes;
using CiotEFrete.WebService;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

#if NETFRAMEWORK

using ACBr.Net.Core.Extensions;

#endif

namespace CiotEFrete
{
    public class Client
    {
        #region Enums

        private enum MetodoWebService
        {
            Login,
            Logout,
            MotoristaGravar,
            MotoristaObter,
            ProprietarioGravar,
            ProprietarioObter,
            VeiculoGravar,
            VeiculoObter,
            PefAdicionarOperacaoTransporte,
            PefAdicionarPagamento,
            PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente,
            PefObterOperacaoTransportePdf,
            PefRetificarOperacaoTransporte,
            PefCancelarOperacaoTransporte,
            PefEncerrarOperacaoTransporte,
            PefAdicionarViagem
        }

        public enum TipoCertificado
        {
            Nenhum,
            A1Repositorio,
            A1Arquivo,
            A1ByteArray,
            A3
        }

        #endregion Enums

        #region Atributos

        /// <summary>
        /// Hash único do Integrador, deve ser obtido junto à e-Frete
        /// </summary>
        public string Integrador { get; set; }

        /// <summary>
        /// Após efetuado o login é gerado um Token de sessão. Este token é armazenado nesta variável
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Retorna se o login foi efetuado levando em consideração se a variável token tem um valor
        /// </summary>
        public bool IsLogado => !Token.IsNull();

        public string CertificadoSerial { get; set; }
        public string CertificadoSenha { get; set; }
        public string CertificadoPath { get; set; }
        public byte[] CertificadoArrayBytes { get; set; }
        public TipoCertificado CertificadoTipo { get; set; }

        public int Timeout { get; set; }
        public bool SalvarXmls { get; set; }
        public string PathXmls { get; set; }

        public string XmlEnvio { get; private set; }
        public string XmlResposta { get; private set; }
        #endregion Atributos

        #region Construtor

        public Client()
        {
            SalvarXmls = true;
            Timeout = 30000;
        }

        #endregion Construtor

        #region Requisições

        #region LogonService

        /// <summary>
        /// Efetua login no webservice
        /// </summary>
        /// <param name="usuario">O usuário</param>
        /// <param name="senha">A senha</param>
        public LoginResult Login(string usuario, string senha)
        {
            var request = new LoginRequest()
            {
                Usuario = usuario,
                Senha = senha,
                Integrador = this.Integrador,
                Versao = 1
            };

            return Login(request);
        }

        /// <summary>
        /// Efetua login no webservice
        /// </summary>
        /// <param name="request">Objeto request</param>
        public LoginResult Login(LoginRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.Login, xmlEnvio);

            var response = LoginResponse.Load(xmlresposta);
            if (response.Result.Sucesso)
                Token = response.Result.Token;

            return response.Result;
        }

        /// <summary>
        /// Efetua logout no webservice liberando o token atual
        /// </summary>
        public LogoutResult Logout()
        {
            if (!IsLogado)
                return null;

            var request = new LogoutRequest()
            {
                Integrador = this.Integrador,
                Token = this.Token,
                Versao = 1,
            };

            return Logout(request);
        }

        /// <summary>
        /// Efetua logout no webservice liberando o token
        /// </summary>
        /// <param name="request">O objeto request</param>
        public LogoutResult Logout(LogoutRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.Logout, xmlEnvio);

            var response = LogoutResponse.Load(xmlresposta);
            if (response.Result.Sucesso)
                Token = null;

            return response.Result;
        }

        #endregion LogonService

        #region MotoristasService

        /// <summary>
        /// Adiciona ou atualiza dados de um motorista na base.
        /// </summary>
        /// <param name="request">O objeto request</param>
        public MotoristaGravarResult GravarMotorista(MotoristaGravarRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.MotoristaGravar, xmlEnvio);

            var response = MotoristaGravarResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Obter dados do motorista pelo cpf/cnh
        /// </summary>
        /// <param name="request"></param>
        public MotoristaObterResult ObterMotorista(MotoristaObterRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.MotoristaObter, xmlEnvio);

            var response = MotoristaObterResponse.Load(xmlresposta);

            return response.Result;
        }

        #endregion MotoristasService

        #region ProprietariosService

        /// <summary>
        /// Adiciona ou atualiza um Proprietário
        /// </summary>
        /// <param name="request">O objeto request</param>
        public ProprietarioGravarResult GravarProprietario(ProprietarioGravarRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.ProprietarioGravar, xmlEnvio);

            var response = ProprietarioGravarResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Obter dados do proprietário
        /// </summary>
        /// <param name="request"></param>
        public ProprietarioObterResult ObterProprietario(ProprietarioObterRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.ProprietarioObter, xmlEnvio);

            var response = ProprietarioObterResponse.Load(xmlresposta);
            return response.Result;
        }

        #endregion ProprietariosService

        #region VeiculosService
        /// <summary>
        /// Adiciona ou atualiza um Veículo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public VeiculoGravarResult GravarVeiculo(VeiculoGravarRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.VeiculoGravar, xmlEnvio);

            var response = VeiculoGravarResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Obter dados do veículo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public VeiculoObterResult ObterVeiculo(VeiculoObterRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.VeiculoObter, xmlEnvio);

            var response = VeiculoObterResponse.Load(xmlresposta);
            return response.Result;
        }

        #endregion

        #region PefService

        /// <summary>
        /// Adiciona uma Operação de Transporte
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefAdicionarOperacaoTransporteResult AdicionarOperacaoTransportePef(PefAdicionarOperacaoTransporteRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefAdicionarOperacaoTransporte, xmlEnvio);

            var response = PefAdicionarOperacaoTransporteResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Adiciona um registro para Pagamentos em uma Operação de Transporte
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefAdicionarPagamentoResult AdicionarPagamentoPef(PefAdicionarPagamentoRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefAdicionarPagamento, xmlEnvio);

            var response = PefAdicionarPagamentoResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Busca e retorna o Código Identificação da Operação de Transporte pelo IdOperacaoCliente informado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResult ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente, xmlEnvio);

            var response = PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Busca e retorna uma Operação de Transporte em pdf
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefObterOperacaoTransportePdfResult ObterOperacaoTransportePdfPef(PefObterOperacaoTransportePdfRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefObterOperacaoTransportePdf, xmlEnvio);

            var response = PefObterOperacaoTransportePdfResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Permite retificar uma operação de transporte
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefRetificarOperacaoTransporteResult RetificarOperacaoTransportePef(PefRetificarOperacaoTransporteRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefRetificarOperacaoTransporte, xmlEnvio);

            var response = PefRetificarOperacaoTransporteResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Permite que seja realizado o cancelamento de uma operação de transporte
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefCancelarOperacaoTransporteResult CancelarOperacaoTransportePef(PefCancelarOperacaoTransporteRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefCancelarOperacaoTransporte, xmlEnvio);

            var response = PefCancelarOperacaoTransporteResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Permite encerrar uma operação de transporte existente que não esteja cancelada
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefEncerrarOperacaoTransporteResult EncerrarOperacaoTransportePef(PefEncerrarOperacaoTransporteRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefEncerrarOperacaoTransporte, xmlEnvio);

            var response = PefEncerrarOperacaoTransporteResponse.Load(xmlresposta);
            return response.Result;
        }

        /// <summary>
        /// Permite adicionar uma Viagem em uma Operação de Transporte existente, desde que a mesma
        /// não tenha ultrapassado o prazo do fim da viagem, esteja cancelada ou encerrada
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PefAdicionarViagemResult AdicionarViagemPef(PefAdicionarViagemRequest request)
        {
            var saveOptions = ACBr.Net.DFe.Core.Common.DFeSaveOptions.DisableFormatting | ACBr.Net.DFe.Core.Common.DFeSaveOptions.OmitDeclaration | ACBr.Net.DFe.Core.Common.DFeSaveOptions.RemoveSpaces;
            string xmlEnvio = request.GetXml(saveOptions).Trim();
            string xmlresposta = Request(MetodoWebService.PefAdicionarViagem, xmlEnvio);

            var response = PefAdicionarViagemResponse.Load(xmlresposta);
            return response.Result;
        }

        #endregion

        private string Request(MetodoWebService metodo, string xml)
        {
            if (SalvarXmls)
            {
                if (!Directory.Exists(PathXmls))
                    Directory.CreateDirectory(PathXmls);

                string path = Path.Combine(PathXmls, $"{metodo}Request_{DateTime.Now:yyyy-MM-dd_HHmmss}.xml");
                File.WriteAllText(path, xml);
            }

            XmlEnvio = string.Empty;
            XmlResposta = string.Empty;

            var _timeout = TimeSpan.FromMilliseconds(Timeout);

            X509Certificate2 _certificado = null;
            try
            {
                switch (CertificadoTipo)
                {
                    case TipoCertificado.A1Repositorio:
                        _certificado = CertificadoDigital.ObterDoRepositorio(CertificadoSerial, OpenFlags.MaxAllowed);
                        break;

                    case TipoCertificado.A1ByteArray:
                        _certificado = CertificadoDigital.ObterDoArrayBytes(CertificadoArrayBytes, CertificadoSenha);
                        break;

                    case TipoCertificado.A1Arquivo:
                        _certificado = CertificadoDigital.ObterDeArquivo(CertificadoPath, CertificadoSenha);
                        break;

                    case TipoCertificado.A3:
                        _certificado = CertificadoDigital.ObterDoRepositorioPassandoPin(CertificadoSerial, CertificadoSenha);
                        break;

                    case TipoCertificado.Nenhum:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Tipo de certificado não implementado");
                }

                switch (metodo)
                {
                    case MetodoWebService.Login:
                        using (var rqst = new LogonServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.Login(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.Logout:
                        using (var rqst = new LogonServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.Logout(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.MotoristaGravar:
                        using (var rqst = new MotoristasServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.MotoristaGravar(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.MotoristaObter:
                        using (var rqst = new MotoristasServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.MotoristaObter(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.ProprietarioGravar:
                        using (var rqst = new ProprietariosServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.ProprietarioGravar(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.ProprietarioObter:
                        using (var rqst = new ProprietariosServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.ProprietarioObter(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.VeiculoGravar:
                        using (var rqst = new VeiculosServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.VeiculoGravar(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.VeiculoObter:
                        using (var rqst = new VeiculosServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.VeiculoObter(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefAdicionarOperacaoTransporte:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.AdicionarOperacaoTransportePef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefAdicionarPagamento:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.AdicionarPagamentoPef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoCliente:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefObterOperacaoTransportePdf:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.ObterOperacaoTransportePdfPef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefRetificarOperacaoTransporte:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.RetificarOperacaoTransportePef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefCancelarOperacaoTransporte:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.CancelarOperacaoTransportePef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    case MetodoWebService.PefEncerrarOperacaoTransporte:
                        using (var rqst = new PefServiceClient(_timeout))
                        {
                            try
                            {
                                XmlResposta = rqst.EncerrarOperacaoTransportePef(xml);
                            }
                            finally
                            {
                                XmlEnvio = rqst.XmlEnvio;
                            }
                        }
                        break;

                    default:
                        throw new NotImplementedException();
                }

                if (SalvarXmls)
                {
                    string path = Path.Combine(PathXmls, $"{metodo}Response_{DateTime.Now:yyyy-MM-dd_HHmmss}.xml");
                    File.WriteAllText(path, XmlResposta);
                }
            }
            finally
            {
#if NETFRAMEWORK
                if (_certificado != null)
                    _certificado.ForceUnload();
#else
                _certificado?.Dispose();
#endif
            }

            return XmlResposta;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion Requisições
    }
}