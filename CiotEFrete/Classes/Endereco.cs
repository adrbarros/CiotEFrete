using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    public class Endereco : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Bairro", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Bairro { get; set; }

        [DFeIgnore]
        public string Cep { get; set; }

        [DFeElement(TipoCampo.Str, "CEP", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string CepProxy
        {
            get => $"{Cep.Substring(0, 5)}-{Cep.Substring(5, 3)}";
            set => Cep = string.Concat(value.Where(char.IsDigit));
        }

        [DFeIgnore]
        public long CodigoMunicipio { get; set; }

        [DFeElement(TipoCampo.Str, "CodigoMunicipio", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string CodigoMunicipioProxy 
        {
            get => CodigoMunicipio.ToString();
            set => CodigoMunicipio = long.Parse(value);
        }

        [DFeElement(TipoCampo.Str, "Rua", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Rua { get; set; }

        [DFeElement(TipoCampo.Str, "Numero", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string Numero { get; set; }

        [DFeElement(TipoCampo.Str, "Complemento", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public string Complemento { get; set; }
        #endregion 

    }
}
