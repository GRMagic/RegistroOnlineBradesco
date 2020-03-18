using Microsoft.Extensions.Configuration;
using System;

namespace RegistroOnlineBradesco.Console
{
    class Program
    {
        public static readonly IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

        static void Main(string[] args)
        {
            var bradesco = new Bradesco(Configuration["urlHomologacao"], Configuration["certificadoArquivo"], Configuration["certificadoSenha"]);

            bradesco.Enviar(new Boleto
            {
                CPFCNPJBeneficiario = "?",
                AgenciaBeneficiario = "?",
                ContaBeneficiario = "?",
                SequenciaContrato = 123,
                NumeroTitulo = 12324473,
                EmissaoTitulo = new DateTime(2020, 03, 18),
                VencimentoTitulo = new DateTime(2020, 03, 21),
                ValorNominal = 32352m,
                ValorJuros = 43.13m,
                CPFCNPJPagador = "12345678901",
                NomePagador = "Bilbo Baggins",
                UFPagador = "SC",
                MunicipioPagador = "The Shire",
                BairroPagador = "The Shire",
                LogradouroPagador = "Rua dos Bobos",
                NumeroLogradouroPagador = "0",
                CepPagador = "55555333"
            });
        }
    }
}
