using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroOnlineBradesco
{
    public class Boleto
    {
        /// <summary>
        /// CPF/CNPJ Beneficiário
        /// </summary>
        public string CPFCNPJBeneficiario { get; set; }

        /// <summary>
        /// Número de Sequência do Contrato
        /// </summary>
        public long SequenciaContrato { get; set; }

        /// <summary>
        /// Agência do beneficiário sem o dígito verificador
        /// </summary>
        public string AgenciaBeneficiario { get; set; }

        /// <summary>
        /// Conta do beneficiário sem o dígito verificador
        /// </summary>
        public string ContaBeneficiario { get; set; }

        /// <summary>
        /// Número do Título (Nosso Número sem o dígito)
        /// </summary>
        public long NumeroTitulo { get; set; }

        /// <summary>
        /// Data de Emissão do Título
        /// </summary>
        public DateTime EmissaoTitulo { get; set; }

        /// <summary>
        /// Data de Vencimento do Título (Formato: DD.MM.AAAA)
        /// </summary>
        public DateTime VencimentoTitulo { get; set; }

        /// <summary>
        /// Valor Nominal do Título
        /// </summary>
        public decimal ValorNominal { get; set; }

        /// <summary>
        /// Controle Participante
        /// ( Campo de responsabilidade do cliente, não consistido pelo banco ) 
        /// </summary>
        public string ControleParticipante { get; set; }

        /// <summary>
        /// Percentual de Juros
        /// </summary>
        public decimal PercentualJuros { get; set; }

        /// <summary>
        /// Valor de Juros 
        /// Se o percentual de juros for preenchido, não deve ser preenchido esse campo
        /// </summary>
        public decimal ValorJuros { get; set; }

        /// <summary>
        /// Quantidade de dias para cálculo Juros
        /// </summary>
        public int QuantidadeDiasJuros { get; set; }

        /// <summary>
        /// Percentual de Multa
        /// </summary>
        public decimal PercentualMulta { get; set; }

        /// <summary>
        /// Valor da Multa
        /// </summary>
        public decimal ValorMulta { get; set; }

        /// <summary>
        /// Quantidade de dias para cálculo Multa
        /// </summary>
        public int QuantidadeDiasMulta { get; set; }

        /// <summary>
        /// Percentual do Desconto 1
        /// </summary>
        public decimal PercentualDesconto1 { get; set; }

        /// <summary>
        /// Valor do Desconto 1
        /// </summary>
        public decimal ValorDesconto1 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 1 
        /// </summary>
        public DateTime? LimiteDesconto1 { get; set; }

        /// <summary>
        /// Percentual do Desconto 2
        /// </summary>
        public decimal PercentualDesconto2 { get; set; }

        /// <summary>
        /// Valor do Desconto 2 
        /// </summary>
        public decimal ValorDesconto2 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 2
        /// </summary>
        public DateTime? LimiteDesconto2 { get; set; }

        /// <summary>
        /// Percentual do Desconto 3 
        /// </summary>
        public decimal PercentualDesconto3 { get; set; }

        /// <summary>
        /// Valor do Desconto 3
        /// </summary>
        public decimal ValorDesconto3 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 3 
        /// </summary>
        public DateTime? LimiteDesconto3 { get; set; }

        /// <summary>
        /// Prazo para Bonificação:
        /// 1 – dias corridos
        /// 2 – dias úteis
        /// Obrigatório quando houver bonificação
        /// </summary>
        public int PrazoBonificacao { get; set; }

        /// <summary>
        /// Percentual de Bonificação
        /// </summary>
        public decimal PercentualBonificacao { get; set; }

        /// <summary>
        /// Valor de Bonificação
        /// </summary>
        public decimal ValorBonificacao { get; set; }

        /// <summary>
        /// Data Limite para Bonificação
        /// </summary>
        public DateTime? LimiteBonificacao { get; set; }

        /// <summary>
        /// Valor do Abatimento
        /// </summary>
        public decimal ValorAbatimento { get; set; }

        /// <summary>
        /// Valor do IOF 
        /// </summary>
        public decimal ValorIOF { get; set; }

        /// <summary>
        /// Nome do Pagador
        /// </summary>
        public string NomePagador { get; set; }

        /// <summary>
        /// Endereço do Pagador
        /// </summary>
        public string LogradouroPagador { get; set; }

        /// <summary>
        /// Número do logradouro do endereço do Pagador
        /// </summary>
        public string NumeroLogradouroPagador { get; set; }

        /// <summary>
        /// Complemento do Endereço do Pagador
        /// </summary>
        public string ComplementoLogradouroPagador { get; set; }

        /// <summary>
        /// CEP do Pagador 
        /// </summary>
        public string CepPagador { get; set; }

        /// <summary>
        /// Bairro Pagador 
        /// </summary>
        public string BairroPagador { get; set; }

        /// <summary>
        /// Município Pagador
        /// </summary>
        public string MunicipioPagador { get; set; }

        /// <summary>
        /// UF Pagador
        /// </summary>
        public string UFPagador { get; set; }

        /// <summary>
        /// CPF/CNPJ Pagador
        /// </summary>
        public string CPFCNPJPagador { get; set; }

        /// <summary>
        /// Endereço Eletrônico Pagador
        /// </summary>
        public string EmailPagador { get; set; }

        /// <summary>
        /// Nome do Sacador Avalista
        /// </summary>
        public string NomeSacadorAvalista { get; set; }

        /// <summary>
        /// Endereço do Sacador Avalista
        /// </summary>
        public string LogradouroSacadorAvalista { get; set; }

        /// <summary>
        /// Número do Endereço do Sacador Avalista
        /// </summary>
        public string NumeroLogradouroSacadorAvalista { get; set; }

        /// <summary>
        /// Complemento do Endereço Sacador Avalista
        /// </summary>
        public string ComplementoLogradouroSacadorAvalista { get; set; }

        /// <summary>
        /// CEP do Sacador Avalista
        /// </summary>
        public string CepSacadorAvalista { get; set; }

        /// <summary>
        /// Bairro Sacador Avalista
        /// </summary>
        public string BairroSacadorAvalista { get; set; }

        /// <summary>
        /// Município Sacador Avalista
        /// </summary>
        public string MunicipioSacadorAvalista { get; set; }

        /// <summary>
        /// UF Sacador Avalista
        /// </summary>
        public string UFSacadorAvalista { get; set; }

        ///// <summary>
        ///// Número do CPF/CNPJ Sacador Avalista
        ///// </summary>
        public string CPFCNPJSacadorAvalista { get; set; }

        /// <summary>
        /// Endereço Eletrônico Sacador Avalista
        /// </summary>
        public string EmailSacadorAvalista { get; set; }

    }
}
