using System;
using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    public class VeiculoObter : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Placa", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Placa { get; set; }

        [DFeElement(TipoCampo.Str, "Renavam", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Renavam { get; set; }

        [DFeElement(TipoCampo.Str, "Chassi", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Chassi { get; set; }

        [DFeElement(TipoCampo.Str, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Rntrc { get; set; }

        [DFeElement(TipoCampo.Int, "NumeroDeEixos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public int NumeroDeEixos { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoMunicipio", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public long CodigoMunicipio { get; set; }

        [DFeElement(TipoCampo.Str, "Marca", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public string Marca { get; set; }

        [DFeElement(TipoCampo.Str, "Modelo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string Modelo { get; set; }

        [DFeElement(TipoCampo.Int, "AnoFabricacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public int AnoFabricacao { get; set; }

        [DFeElement(TipoCampo.Int, "AnoModelo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 10)]
        public int AnoModelo { get; set; }

        [DFeElement(TipoCampo.Str, "Cor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 11)]
        public string Cor { get; set; }

        [DFeElement(TipoCampo.Int, "Tara", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 12)]
        public int Tara { get; set; }

        [DFeElement(TipoCampo.Int, "CapacidadeKg", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 13)]
        public int CapacidadeKg { get; set; }

        [DFeElement(TipoCampo.Int, "CapacidadeM3", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 14)]
        public int CapacidadeM3 { get; set; }

        [DFeIgnore]
        public TipoRodado? TipoRodado { get; set; }

        [DFeElement(TipoCampo.Str, "TipoRodado", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 15)]
        public string TipoRodadoProxy
        {
            get
            {
                if (!TipoRodado.HasValue)
                    return null;

                switch (TipoRodado.Value)
                {
                    case Classes.TipoRodado.NaoAplicavel: return "Não Aplicável";
                    case Classes.TipoRodado.Truck: return "Truck";
                    case Classes.TipoRodado.Toco: return "Toco";
                    case Classes.TipoRodado.Cavalo: return "Cavalo";
                    default: throw new NotImplementedException("Tipo rodado não implementado");
                }
            }

            set
            {
                if (value.IsNull())
                    TipoRodado = null;

                switch (value.ToLower())
                {
                    case "naoaplicavel": TipoRodado = Classes.TipoRodado.NaoAplicavel; break;
                    case "truck": TipoRodado = Classes.TipoRodado.Truck; break;
                    case "toco": TipoRodado = Classes.TipoRodado.Toco; break;
                    case "cavalo": TipoRodado = Classes.TipoRodado.Cavalo; break;
                    default: throw new NotImplementedException("Tipo rodado não implementado");
                }
            }
        }

        [DFeIgnore]
        public TipoCarroceria? TipoCarroceria { get; set; }

        [DFeElement(TipoCampo.Str, "TipoCarroceria", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 16)]
        public string TipoCarroceriaProxy
        {
            get
            {
                if (!TipoCarroceria.HasValue)
                    return null;

                switch (TipoCarroceria.Value)
                {
                    case Classes.TipoCarroceria.NaoAplicavel: return "Não Aplicável";
                    case Classes.TipoCarroceria.Aberta: return "Aberta";
                    case Classes.TipoCarroceria.FechadaOuBau: return "Fechada ou Baú";
                    case Classes.TipoCarroceria.Granelera: return "Granelera";
                    case Classes.TipoCarroceria.PortaContainer: return "Porta Container";
                    case Classes.TipoCarroceria.Sider: return "Sider";
                    default: throw new NotImplementedException("Tipo de carroceria não implementado");
                }
            }

            set
            {
                if (value.IsNull())
                    TipoCarroceria = null;

                switch (value.ToLower())
                {
                    case "naoaplicavel": TipoCarroceria = Classes.TipoCarroceria.NaoAplicavel; break;
                    case "aberta": TipoCarroceria = Classes.TipoCarroceria.Aberta; break;
                    case "fechadaoubau": TipoCarroceria = Classes.TipoCarroceria.FechadaOuBau; break;
                    case "granelera": TipoCarroceria = Classes.TipoCarroceria.Granelera; break;
                    case "portacontainer": TipoCarroceria = Classes.TipoCarroceria.PortaContainer; break;
                    case "sider": TipoCarroceria = Classes.TipoCarroceria.Sider; break;
                    default: throw new NotImplementedException("Tipo de carroceria não implementado");
                }
            }
        }

        #endregion
    }
}
