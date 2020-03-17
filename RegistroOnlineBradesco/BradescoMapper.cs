using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroOnlineBradesco
{
    static class BradescoMapper
    {
        public static IMapper Mapper { get; private set; } = CreateMapper();

        private static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Boleto, JsonBradesco>()
                .ForMember(j => j.nuCPFCNPJ, opt => opt.MapFrom( b => b.CPFCNPJBeneficiario.Substring(0,9)))
                .ForMember(j => j.filialCPFCNPJ, opt => opt.MapFrom( b => b.CPFCNPJBeneficiario.Length < 14 ? "0" : b.CPFCNPJBeneficiario.Substring(9, 4)))
                .ForMember(j => j.ctrlCPFCNPJ, opt => opt.MapFrom( b => b.CPFCNPJBeneficiario.Length < 14 ? b.CPFCNPJBeneficiario.Substring(9, 2) : b.CPFCNPJBeneficiario.Substring(12, 2)))
                .ForMember(j => j.nuSequenciaContrato, opt => opt.MapFrom( b => b.SequenciaContrato))
                .ForMember(j => j.nuNegociacao, opt => opt.MapFrom( b=> b.AgenciaBeneficiario.PadLeft(4,'0') + "0000000" + b.ContaBeneficiario.PadLeft(7, '0')))
                .ForMember(j => j.eNuSequenciaContrato, opt => opt.MapFrom(b => b.SequenciaContrato))
                .ForMember(j => j.nuTitulo, opt => opt.MapFrom(b => b.NumeroTitulo))
                .ForMember(j => j.nuCliente, opt => opt.MapFrom(b => b.NumeroTitulo))
                .ForMember(j => j.dtEmissaoTitulo, opt => opt.MapFrom(b => b.EmissaoTitulo))
                .ForMember(j => j.nuCliente, opt => opt.MapFrom(b => b.NumeroTitulo))
                .ForMember(j => j.dtVencimentoTitulo, opt => opt.MapFrom(b => b.VencimentoTitulo))
                .ForMember(j => j.vlNominalTitulo, opt => opt.MapFrom(b => b.ValorNominal))
                .ForMember(j => j.vlJuros, opt => opt.MapFrom(b => b.ValorJuros))
                .ForMember(j => j.qtdeDiasJuros, opt => opt.MapFrom(b => b.QuantidadeDiasJuros))
                .ForMember(j => j.vlMulta, opt => opt.MapFrom(b => b.ValorMulta))
                .ForMember(j => j.qtdeDiasMulta, opt => opt.MapFrom(b => b.QuantidadeDiasMulta))
                .ForMember(j => j.vlDesconto1, opt => opt.MapFrom(b => b.ValorDesconto1))
                .ForMember(j => j.dataLimiteDesconto1, opt => opt.MapFrom(b => b.LimiteDesconto1==null? "" : b.LimiteDesconto1.Value.ToString("dd.MM.yyyy")))
                .ForMember(j => j.vlDesconto2, opt => opt.MapFrom(b => b.ValorDesconto2))
                .ForMember(j => j.dataLimiteDesconto2, opt => opt.MapFrom(b => b.LimiteDesconto2 == null ? "" : b.LimiteDesconto2.Value.ToString("dd.MM.yyyy")))
                .ForMember(j => j.vlDesconto3, opt => opt.MapFrom(b => b.ValorDesconto3))
                .ForMember(j => j.dataLimiteDesconto3, opt => opt.MapFrom(b => b.LimiteDesconto3 == null ? "" : b.LimiteDesconto3.Value.ToString("dd.MM.yyyy")))
                .ForMember(j => j.vlBonificacao, opt => opt.MapFrom(b => b.ValorBonificacao))
                .ForMember(j => j.dtLimiteBonificacao, opt => opt.MapFrom(b => b.LimiteBonificacao == null ? "" : b.LimiteBonificacao.Value.ToString("dd.MM.yyyy")))
                .ForMember(j => j.vlAbatimento, opt => opt.MapFrom(b => b.ValorAbatimento))
                .ForMember(j => j.vlIOF, opt => opt.MapFrom(b => b.ValorIOF))
                .ForMember(j => j.nuLogradouroPagador, opt => opt.MapFrom(b => b.NumeroLogradouroPagador))
                .ForMember(j => j.cepPagador, opt => opt.MapFrom(b => b.CepPagador!=null?b.CepPagador.Substring(0, 5):""))
                .ForMember(j => j.complementoCepPagador, opt => opt.MapFrom(b => b.CepPagador != null?b.CepPagador.Substring(5, 3):""))
                .ForMember(j => j.nuCpfcnpjPagador, opt => opt.MapFrom(b => b.CPFCNPJPagador))
                .ForMember(j => j.cdIndCpfcnpjPagador, opt => opt.MapFrom(b => b.CPFCNPJPagador.Length==11?1:2))
                .ForMember(j => j.endEletronicoPagador, opt => opt.MapFrom(b => b.EmailPagador))
                .ForMember(j => j.nuLogradouroSacadorAvalista, opt => opt.MapFrom(b => b.NumeroLogradouroSacadorAvalista))
                .ForMember(j => j.cepSacadorAvalista, opt => opt.MapFrom(b => b.CepSacadorAvalista != null?b.CepSacadorAvalista.Substring(0, 5):""))
                .ForMember(j => j.complementoCepSacadorAvalista, opt => opt.MapFrom(b => b.CepSacadorAvalista!= null?b.CepSacadorAvalista.Substring(5, 3):""))
                .ForMember(j => j.cdIndCpfcnpjSacadorAvalista, opt => opt.MapFrom(b => b.CPFCNPJSacadorAvalista.Length == 11 ? 1 : 2))
                .ForMember(j => j.endEletronicoSacadorAvalista, opt => opt.MapFrom(b => b.EmailSacadorAvalista));
            });

            return configuration.CreateMapper();
        }
    }
}
