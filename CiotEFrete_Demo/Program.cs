using CiotEFrete;
using CiotEFrete.Classes;
using System;
using System.Collections.Generic;
using static CiotEFrete.Client;

namespace CiotEFrete_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = null;
            try
            {
                client = new Client()
                {
                    PathXmls = @"c:\temp\",
                    Integrador = "integrador_aqui",

                    CertificadoTipo = TipoCertificado.Nenhum,
                };

                if (client.CertificadoTipo == TipoCertificado.Nenhum)
                {
                    client.Login(usuario: "usuario", senha: "senha");

                    if (!client.IsLogado)
                        throw new ArgumentException("O login não foi efetuado");
                }

                GravarProprietario(client);

                GravarVeiculo(client);

                GravarMotorista(client);
                                
                AdicionarOperacaoTransportePef(client);

                //AdicionarPagamentoPef(client);

                //ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(client);

                //ObterOperacaoTransportePdfPef(client);

                //RetificarOperacaoTransportePef(client);

                //CancelarOperacaoTransportePef(client);

                //EncerrarOperacaoTransportePef(client);

                //AdicionarViagemPef(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Logout();
            }
        }

        #region GravarProprietario

        private static bool GravarProprietario(Client client)
        {
            var proprietario = new ProprietarioGravarRequest(client)
            {
                Cnpj = "90657289000109",
                TipoPessoa = TipoPessoa.Juridica,
                Endereco = new Endereco()
                {
                    Bairro = "XXX",
                    Cep = "98200000",
                    CodigoMunicipio = 4310009,
                    Numero = "2359",
                    Rua = "RUA MAUA",
                    Complemento = null
                },
                Rntrc = "06212921",
                RazaoSocial = "COOPERATIVA AGRICOLA MISTA GENERAL OSORIO LTDA",
                Telefones = new Telefones()
                {
                    Celular = new Telefone()
                    {
                        Ddd = "14",
                        Numero = "912345678"
                    }
                }
            };

            var resposta = client.GravarProprietario(proprietario);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region GravarVeiculo

        private static bool GravarVeiculo(Client client)
        {
            var veiculo = new VeiculoGravarRequest(client)
            {
                Veiculo = new VeiculoGravar()
                {
                    AnoFabricacao = 2020,
                    AnoModelo = 2020,
                    CapacidadeKg = 320,
                    CapacidadeM3 = 20,
                    Chassi = "9BWZZZ377VT004251",
                    CodigoMunicipio = 3510123,
                    Cor = "Prata",
                    Marca = "Volkswagen",
                    Modelo = "Gol",
                    NumeroDeEixos = 2,
                    Placa = "BWC1312",
                    Rntrc = "00169885",
                    Renavam = "12345678901",
                    Tara = 35,
                    TipoCarroceria = TipoCarroceria.Aberta,
                    TipoRodado = TipoRodado.Cavalo
                }
            };

            var resposta = client.GravarVeiculo(veiculo);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region GravarMotorista

        private static bool GravarMotorista(Client client)
        {
            var motorista = new MotoristaGravarRequest(client)
            {
                Cpf = "65139029081",
                Cnh = "12346589",
                DataNascimento = new DateTime(1992, 12, 22),
                Endereco = new Endereco()
                {
                    Bairro = "O Bairro aqui",
                    Cep = "17300000",
                    CodigoMunicipio = 3514106,
                    Numero = "126",
                    Rua = "Nome da Rua ou Avenida",
                    Complemento = null
                },
                Nome = "Matheus",
                NomeDeSolteiroDaMae = "Maria da Silva",
                Telefones = new Telefones()
                {
                    Celular = new Telefone()
                    {
                        Ddd = "14",
                        Numero = "997155215"
                    }
                }
            };

            var resposta = client.GravarMotorista(motorista);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion
               
        #region AdicionarOperacaoTransportePef

        private static bool AdicionarOperacaoTransportePef(Client client)
        {
            var pef = new PefAdicionarOperacaoTransporteRequest(client)
            {
                TipoViagem = TipoViagem.Padrao,
                TipoPagamento = TipoPagamento.TransferenciaBancaria,
                EmissaoGratuita = true,
                BloquearNaoEquiparado = false,
                MatrizCnpj = "90657289000109",
                FilialCnpj = "90657289000109",
                IdOperacaoCliente = "1",
                DataInicioViagem = DateTime.Now,
                DataFimViagem = DateTime.Now,
                CodigoNcmNaturezaCarga = "8471",
                PesoCarga = 2300,
                TipoEmbalagem = TipoEmbalagem.Bigbag,
                Viagens = new PefAdicionarOperacaoTransporteViagens()
                {
                    DocumentoViagem = "01234",
                    CodigoMunicipioOrigem = 4310009,
                    CodigoMunicipioDestino = 4310009,
                    CepOrigem = "98200000",
                    CepDestino = "98200000",
                    DistanciaPercorrida = 95,
                    Valores = new PefAdicionarOperacaoTransporteValores()
                    {
                        TotalOperacao = 350,
                        TotalViagem = 250,
                        TotalAdiantamento = 0,
                        TotalQuitacao = 0,
                        Combustivel = 0,
                        Pedagio = 0,
                        OutrosCreditos = 0,
                        JustificativaOutrosCreditos = "",
                        Seguro = 0,
                        OutroDebitos = 0,
                        JustificativaOutrosDebitos = ""
                    },
                    TipoPagamento = TipoPagamento.TransferenciaBancaria,
                    NotasFiscais = new PefAdicionarOperacaoTransporteNotasFiscais()
                    {
                        NotaFiscal = new PefAdicionarOperacaoTransporteNotaFiscal()
                        {
                            Numero = "1",
                            Serie = "1",
                            Data = DateTime.Now,
                            ValorTotal = 250,
                            ValorMercadoriaPorUnidade = 25,
                            CodigoNcmNaturezaCarga = "8471",
                            DescricaoMercadoria = "Caixa",
                            UnidadeMedidaMercadoria = UnidadeMedidaDaMercadoria.Kg,
                            TipoCalculo = TipoCalculoQuebraFrete.SemQuebra,
                            ValorFretePorUnidadeDeMercadoria = 250,
                            QuantidadeMercadoriaNoEmbarque = 175,
                            ToleranciaDePerdaDeMercadoria = new PefAdicionarOperacaoTransporteToleranciaDePerdaDeMercadoria()
                            {
                                Tipo = TipoToleranciaDePerda.Nenhum,
                                Valor = 350
                            },
                            DiferencaDeFrete = new PefAdicionarOperacaoTransporteDiferencaDeFrete()
                            {
                                Tipo = TipoDiferencaFrete.Integral,
                                Base = BaseDiferencaFrete.QuantidadeMenor,
                                Tolerancia = new PefAdicionarOperacaoTransporteToleranciaAceitaParaCalculo()
                                {
                                    Tipo = TipoToleranciaCalculo.Nenhum,
                                    Valor = 0
                                },
                                MargemGanho = new PefAdicionarOperacaoTransporteMargemGanho()
                                {
                                    Tipo = TipoMargem.Nenhum,
                                    Valor = 0
                                },
                                MargemPerda = new PefAdicionarOperacaoTransporteMargemPerda
                                {
                                    Tipo = TipoMargem.Nenhum,
                                    Valor = 0
                                }
                            }
                        }
                    }
                },
                Impostos = new PefAdicionarOperacaoTransporteImpostos()
                {
                    Irrf = 0,
                    SestSenai = 0,
                    Inss = 0,
                    Issqn = 0,
                    OutrosImpostos = 0,
                    DescricaoOutrosImpostos = "Nenhum"
                },
                Pagamentos = new List<PefAdicionarOperacaoTransportePagamentos>() {
                    new PefAdicionarOperacaoTransportePagamentos()
                    {
                        IdPagamentoCliente = "1",
                        DataLiberacao = DateTime.Now,
                        Valor = 250,
                        TipoPagamento = TipoPagamento.TransferenciaBancaria,
                        Categoria = CategoriaPagamento.Adiantamento,
                        Documento = "01234",
                        InformacoesBancarias = new PefAdicionarOperacaoTransporteInformacoesBancarias()
                        {
                            InstituicaoBancaria = "Sicoob",
                            Agencia = "237",
                            Conta = "21935"
                        },
                        InformacaoAdicional = "Alguma informação adicional aqui",
                        CnpjFilialAbastecimento = "90657289000109"
                    }
                }
                ,
                Contratado = new PefAdicionarOperacaoTransporteContratado()
                {
                    CpfOuCnpj = "90657289000109",
                    Rntrc = "06212921"
                },
                Motorista = new PefAdicionarOperacaoTransporteMotorista()
                {
                    CpfOuCnpj = "65139029081",
                    Cnh = "123456789",
                    Celular = new Telefone() { Ddd = "14", Numero = "997155215" }
                },
                Destinatario = new PefAdicionarOperacaoTransporteDestinatario()
                {
                    NomeOuRazaoSocial = "Maria José Ltda Me",
                    CpfOuCnpj = "90657289000109",
                    Endereco = new PefAdicionarOperacaoTransporteEndereco()
                    {
                        Bairro = "XXX",
                        Rua = "RUA MAUA",
                        Numero = "2359",
                        Complemento = null,
                        Cep = "98200000",
                        CodigoMunicipio = 4310009
                    },
                    Email = "blabla@gmail.com",
                    Telefones = new Telefones()
                    {
                        Celular = new Telefone() { Ddd = "14", Numero = "996850213" },
                        Fixo = new Telefone() { Ddd = "14", Numero = "36520000" },
                        Fax = new Telefone() { Ddd = "14", Numero = "36520000" }
                    },
                    ResponsavelPeloPagamento = false
                },
                Contratante = new PefAdicionarOperacaoTransporteContratante()
                {
                    NomeOuRazaoSocial = "Michel Bastos",
                    Rntrc = "123456789",
                    CpfOuCnpj = "90657289000109",
                    Endereco = new PefAdicionarOperacaoTransporteEndereco()
                    {
                        Bairro = "XXX",
                        Rua = "RUA MAUA",
                        Numero = "2359",
                        Complemento = null,
                        Cep = "98200000",
                        CodigoMunicipio = 4310009
                    },
                    Email = "blabla@gmail.com",
                    Telefones = new Telefones()
                    {
                        Celular = new Telefone() { Ddd = "14", Numero = "996850213" },
                        Fixo = new Telefone() { Ddd = "14", Numero = "36520000" },
                        Fax = new Telefone() { Ddd = "14", Numero = "36520000" }
                    },
                    ResponsavelPeloPagamento = true
                },
                SubContratante = new PefAdicionarOperacaoTransporteDestinatario()
                {
                    NomeOuRazaoSocial = "Maria José Ltda Me",
                    CpfOuCnpj = "90657289000109",
                    Endereco = new PefAdicionarOperacaoTransporteEndereco()
                    {
                        Bairro = "XXX",
                        Rua = "RUA MAUA",
                        Numero = "2359",
                        Complemento = null,
                        Cep = "98200000",
                        CodigoMunicipio = 4310009
                    },
                    Email = "blabla@gmail.com",
                    Telefones = new Telefones()
                    {
                        Celular = new Telefone() { Ddd = "14", Numero = "996850213" },
                        Fixo = new Telefone() { Ddd = "14", Numero = "36520000" },
                        Fax = new Telefone() { Ddd = "14", Numero = "36520000" }
                    },
                    ResponsavelPeloPagamento = false
                },
                Consignatario = new PefAdicionarOperacaoTransporteDestinatario()
                {
                    NomeOuRazaoSocial = "Maria José Ltda Me",
                    CpfOuCnpj = "90657289000109",
                    Endereco = new PefAdicionarOperacaoTransporteEndereco()
                    {
                        Bairro = "XXX",
                        Rua = "RUA MAUA",
                        Numero = "2359",
                        Complemento = null,
                        Cep = "98200000",
                        CodigoMunicipio = 4310009
                    },
                    Email = "blabla@gmail.com",
                    Telefones = new Telefones()
                    {
                        Celular = new Telefone() { Ddd = "14", Numero = "996850213" },
                        Fixo = new Telefone() { Ddd = "14", Numero = "36520000" },
                        Fax = new Telefone() { Ddd = "14", Numero = "36520000" }
                    },
                    ResponsavelPeloPagamento = false
                },
                TomadorServico = new PefAdicionarOperacaoTransporteDestinatario()
                {
                    NomeOuRazaoSocial = "Maria José Ltda Me",
                    CpfOuCnpj = "90657289000109",
                    Endereco = new PefAdicionarOperacaoTransporteEndereco()
                    {
                        Bairro = "XXX",
                        Rua = "RUA MAUA",
                        Numero = "2359",
                        Complemento = null,
                        Cep = "98200000",
                        CodigoMunicipio = 4310009
                    },
                    Email = "blabla@gmail.com",
                    Telefones = new Telefones()
                    {
                        Celular = new Telefone() { Ddd = "14", Numero = "996850213" },
                        Fixo = new Telefone() { Ddd = "14", Numero = "36520000" },
                        Fax = new Telefone() { Ddd = "14", Numero = "36520000" }
                    },
                    ResponsavelPeloPagamento = false
                },
                Veiculos = new PefAdicionarOperacaoTransporteVeiculos()
                {
                    Placa = "ABC1234"
                },
                CodigoIdentificacaoOperacaoPrincipal = "",
                ObservacoesTransportador = new PefAdicionarOperacaoTransporteObservacoes()
                {
                    String = null
                },
                ObservacoesCredenciado = new PefAdicionarOperacaoTransporteObservacoes()
                {
                    String = null
                },
                EntregaDocumentacao = EntregaDocumentacao.RedeCredenciada,
                QuantidadeSaques = 5,
                QuantidadeTransferencias = 0,
                CodigoTipoCarga = 1,
                AltoDesempenho = false,
                DestinacaoComercial = false,
                FreteRetorno = false,
                CepRetorno = "17300000",
                DistanciaRetorno = 50
            };

            var resposta = client.AdicionarOperacaoTransportePef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region AdicionarPagamentosPef

        private static bool AdicionarPagamentoPef(Client client)
        {
            var pef = new PefAdicionarPagamentoRequest(client)
            {
                CodigoIdentificacaoOperacao = "1",
                Pagamentos = new PefAdicionarPagamentoPagamento()
                {
                    Pagamentos = new List<PefAdicionarPagamentoPagamentoDados>() 
                    {
                        new PefAdicionarPagamentoPagamentoDados()
                        {
                            Categoria = CategoriaPagamento.Adiantamento,
                            DataLiberacao = DateTime.Now,
                            Documento = "Documento aqui",
                            IdPagamentoCliente = "2",
                            InformacaoAdicional = "Informação adicional aqui",
                            CnpjFilialAbastecimento = "01234567000189",
                            InformacoesBancarias = new PefAdicionarPagamentoInformacoesBancarias()
                            {
                                Agencia = "237",
                                Conta = "219320",
                                InstituicaoBancaria = "Sicoob"
                            },
                            Tipo = TipoPagamento.TransferenciaBancaria,
                            Valor = 250
                        }
                    }
                }
            };

            var resposta = client.AdicionarPagamentoPef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef

        private static bool ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(Client client)
        {
            var pef = new PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest(client)
            {
                MatrizCnpj = "01234567000189",
                IdOperacaoCliente = "1"
            };

            var resposta = client.ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClientePef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region ObterOperacaoTransportePdfPef

        private static bool ObterOperacaoTransportePdfPef(Client client)
        {
            var pef = new PefObterOperacaoTransportePdfRequest(client)
            {
                CodigoIdentificacaoOperacao = "1",
                DocumentoViagem = "O documento da viagem aqui"
            };

            var resposta = client.ObterOperacaoTransportePdfPef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region RetificarOperacaoTransportePef

        private static bool RetificarOperacaoTransportePef(Client client)
        {
            var pef = new PefRetificarOperacaoTransporteRequest(client)
            {
                CodigoIdentificacaoOperacao = "1",
                CodigoMunicipioDestino = 3510123,
                CodigoMunicipioOrigem = 3510123,
                Veiculos = new PefAdicionarOperacaoTransporteVeiculos()
                {
                    Placa = "ABC1234"
                },
                QuantidadeSaques = 5,
                QuantidadeTransferencias = 2
            };

            var resposta = client.RetificarOperacaoTransportePef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region CancelarOperacaoTransportePef

        private static bool CancelarOperacaoTransportePef(Client client)
        {
            var pef = new PefCancelarOperacaoTransporteRequest(client)
            {
                CodigoIdentificacaoOperacao = "1",
                Motivo = "Motivo do cancelamento aqui"
            };

            var resposta = client.CancelarOperacaoTransportePef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region EncerrarOperacaoTransportePef

        private static bool EncerrarOperacaoTransportePef(Client client)
        {
            var pef = new PefEncerrarOperacaoTransporteRequest(client)
            {
                CodigoIdentificacaoOperacao = "1",
                PesoCarga = 50,
                Impostos = new PefEncerrarOperacaoTransporteImpostos()
                {
                    DescricaoOutrosImpostos = "",
                    Inss = 0,
                    Irrf = 0,
                    Issqn = 0,
                    OutrosImpostos = 0,
                    SestSenai = 0
                },
                QuantidadeSaques = 0,
                QuantidadeTransferencias = 0
            };

            var resposta = client.EncerrarOperacaoTransportePef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion

        #region AdicionarViagemPef

        private static bool AdicionarViagemPef(Client client)
        {
            var pef = new PefAdicionarViagemRequest(client)
            {
                NaoAdicionarParcialmente = false,
                CodigoIdentificacaoOperacao = "0",
                Viagens = new PefAdicionarViagemViagens()
                {
                    CodigoMunicipioDestino = 3510123,
                    CodigoMunicipioOrigem = 3510123,
                    CepOrigem = "17300000",
                    CepDestino = "17300000",
                    DocumentoViagem = "Documento da viagem aqui",
                    NotasFiscais = new PefAdicionarViagemNotasFiscais()
                    {
                        CodigoNcmNaturezaCarga = "8471",
                        Data = DateTime.Now,
                        DescricaoMercadoria = "Descrição da mercadoria aqui",
                        Numero = "0",
                        QuantidadeMercadoriaNoEmbarque = 0,
                        Serie = "1",
                        TipoCalculo = TipoCalculoQuebraFrete.SemQuebra,
                        ToleranciaDePerdaDeMercadoria = new PefAdicionarOperacaoTransporteToleranciaDePerdaDeMercadoria()
                        {
                            Tipo = TipoToleranciaDePerda.Nenhum,
                            Valor = 0
                        },
                        UnidadeMedidaMercadoria = UnidadeMedidaDaMercadoria.Kg,
                        ValorMercadoriaPorUnidade = 0,
                        ValorFretePorUnidadeDeMercadoria = 0,
                        ValorTotal = 0
                    },
                    Valores = new PefAdicionarViagemValores()
                    {
                        Combustivel = 0,
                        JustificativaOutrosCreditos = "Justificativa aqui",
                        JustificativaOutrosDebitos = "Justificativa aqui",
                        OutrosCreditos = 0,
                        OutroDebitos = 0,
                        Pedagio = 0,
                        Seguro = 0,
                        TotalAdiantamento = 0,
                        TotalQuitacao = 0,
                        TotalOperacao = 0,
                        TotalViagem = 0
                    }                    
                },
                Pagamentos = new PefAdicionarViagemPagamentos()
                {
                    Categoria = CategoriaPagamento.Adiantamento,
                    DataLiberacao = DateTime.Now,
                    Documento = "Documento aqui",
                    IdPagamentoCliente = "",
                    InformacaoAdicional = "",
                    CnpjFilialAbastecimento = "01234567000189",
                    InformacoesBancarias = new PefAdicionarPagamentoInformacoesBancarias()
                    {
                        Agencia = "1395",
                        Conta = "256398",
                        InstituicaoBancaria = "Bradesco"
                    },
                    Tipo = TipoPagamento.eFRETE,
                    Valor = 0
                }
            };

            var resposta = client.AdicionarViagemPef(pef);

            if (!resposta.Sucesso)
                throw new ArgumentException($"{resposta.Excecao.Codigo} - {resposta.Excecao.Mensagem}");

            return resposta.Sucesso;
        }

        #endregion
    }
}