using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Globalization;

namespace RegistroOnlineBradesco
{
    class JsonBradescoProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public JsonBradescoProvider(PropertyInfo memberInfo) => _MemberInfo = memberInfo;
        public void SetValue(object target, object value) => _MemberInfo.SetValue(target, value);


        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (_MemberInfo.PropertyType == typeof(string))
            {
                var formato = (FormatoAttribute)_MemberInfo.GetCustomAttribute(typeof(FormatoAttribute));
                if (formato == null)
                {
                    result = result??"";
                }
                else
                {
                    result = Formatar(result as string, formato.Tipo, formato.Caracteres, formato.Decimais);
                }
            }
            return result;
        }

        public string Formatar(string valor, TipoCampo tipo, int tamanho, int decimais)
        {
            if(tipo == TipoCampo.Numerico)
            {
                if (string.IsNullOrWhiteSpace(valor)) valor = "0";

                var numberInfo = new CultureInfo("en-US", false).NumberFormat;
                numberInfo.NumberDecimalSeparator = "|";
                numberInfo.NumberGroupSeparator = "";

                var nValor = decimal.Parse(valor);
                var esquerda = new string('0', tamanho - decimais);
                var direita = new string('0', decimais);
                valor = nValor.ToString(esquerda + "." + direita, numberInfo).Replace("|","");
                if (valor.Length > tamanho) throw new Exception("Campo longo demais!");
            }
            if (tipo == TipoCampo.Alfanumerico)
            {
                if (string.IsNullOrWhiteSpace(valor)) valor = "";
                if (valor.Length > tamanho) return valor.Substring(0, tamanho);
            }
            return valor;
        }
    }

}
