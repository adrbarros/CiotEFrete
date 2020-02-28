using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace CiotEFrete
{
    internal static class Funcoes
    {
        public static bool IsNull(this string _str) => string.IsNullOrEmpty(_str) || string.IsNullOrWhiteSpace(_str) || string.IsNullOrEmpty(_str.Trim());

        public static string TrimOrNull(this string _str) => _str.IsNull() ? null : _str.Trim();

    }
}
