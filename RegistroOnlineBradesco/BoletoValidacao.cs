using FluentValidation;

namespace RegistroOnlineBradesco
{
    class BoletoValidacao : AbstractValidator<Boleto>
    {
        public BoletoValidacao()
        {
            RuleFor(x => x.CPFCNPJBeneficiario)
                .NotEmpty()
                .Length(11,14);

            RuleFor(x => x.AgenciaBeneficiario)
                .NotEmpty();

            RuleFor(x => x.ContaBeneficiario)
                .NotEmpty();

            RuleFor(x => x.NumeroTitulo)
                .GreaterThan(0);

            RuleFor(x => x.EmissaoTitulo)
                .NotEmpty();

            RuleFor(x => x.VencimentoTitulo)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.EmissaoTitulo);

            RuleFor(x => x.ValorNominal)
                .NotEmpty();

            RuleFor(x => x.ValorJuros)
                .Empty().When(x => x.PercentualJuros > 0);

            RuleFor(x => x.ValorMulta)
                .Empty().When(x => x.PercentualMulta > 0);

            RuleFor(x => x.ValorBonificacao)
                .Empty().When(x => x.PercentualBonificacao > 0);

            RuleFor(x => x.ValorDesconto1)
                .Empty().When(x => x.PercentualDesconto1 > 0);
            
            RuleFor(x => x.ValorDesconto2)
                .Empty().When(x => x.PercentualDesconto2 > 0);

            RuleFor(x => x.ValorDesconto3)
                .Empty().When(x => x.PercentualDesconto3 > 0);

            RuleFor(x => x.PrazoBonificacao)
                .NotEmpty().When(x => x.ValorBonificacao > 0 || x.PercentualBonificacao > 0 );

            RuleFor(x => x.LimiteDesconto1)
                .NotEmpty().When(x => x.ValorDesconto1 > 0 || x.PercentualDesconto1 > 0);
            
            RuleFor(x => x.LimiteDesconto2)
                .NotEmpty().When(x => x.ValorDesconto2 > 0 || x.PercentualDesconto2 > 0);
            
            RuleFor(x => x.LimiteDesconto3)
                .NotEmpty().When(x => x.ValorDesconto3 > 0 || x.PercentualDesconto3 > 0);

            RuleFor(x => x.PrazoBonificacao)
                .NotEmpty().When(x => x.ValorBonificacao > 0 || x.PercentualBonificacao > 0);

            RuleFor(x => x.LimiteBonificacao)
                .NotEmpty().When(x => x.ValorBonificacao > 0 || x.PercentualBonificacao > 0);

            RuleFor(x => x.NomePagador)
                .NotEmpty();

            RuleFor(x => x.LogradouroPagador)
                .NotEmpty();

            RuleFor(x => x.NumeroLogradouroPagador)
                .NotEmpty();

            RuleFor(x => x.CepPagador)
                .NotEmpty();

            RuleFor(x => x.BairroPagador)
                .NotEmpty();

            RuleFor(x => x.MunicipioPagador)
                .NotEmpty();

            RuleFor(x => x.UFPagador)
                .NotEmpty();

            RuleFor(x => x.CPFCNPJPagador)
                .NotEmpty();

            RuleFor(x => x.LogradouroSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

            RuleFor(x => x.NumeroLogradouroSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

            RuleFor(x => x.CepSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

            RuleFor(x => x.BairroSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

            RuleFor(x => x.MunicipioSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

            RuleFor(x => x.UFSacadorAvalista)
                .NotEmpty().When(x => !string.IsNullOrWhiteSpace(x.CPFCNPJSacadorAvalista));

        }
    }
}
