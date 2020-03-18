using System;

namespace RegistroOnlineBradesco
{
    class FormatoAttribute : Attribute
    {
        public TipoCampo Tipo { get; set; }
        public int Caracteres { get; set; }
        public int Decimais { get; set; }

        public FormatoAttribute(TipoCampo tipo, int caracteres, int decimais = 0)
        {
            Tipo = tipo;
            Caracteres = caracteres;
            Decimais = decimais;
        }
    }
}
