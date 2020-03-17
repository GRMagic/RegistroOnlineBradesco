using Microsoft.Extensions.Configuration;
using System;

namespace RegistroOnlineBradesco
{
    class Program
    {
        public static readonly IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

        static void Main(string[] args)
        {

            var bradesco = new Bradesco(Configuration["urlHomologacao"], Configuration["certificadoArquivo"], Configuration["certificadoSenha"]);

            bradesco.Enviar(new Boleto
            {
                CPFCNPJBeneficiario = "12345678901234",
                AgenciaBeneficiario = "123",
                ContaBeneficiario = "456",
                SequenciaContrato = 1234567890,
                NumeroTitulo = 123,
                EmissaoTitulo = DateTime.Now,
                VencimentoTitulo = DateTime.Now.AddDays(7),
                ValorNominal = 123.45m,
                ControleParticipante = "???",
                PercentualJuros = 1m,
                PercentualMulta = 123m,
                
            });
        }
    }
}
