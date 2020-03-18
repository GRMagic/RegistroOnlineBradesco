using Newtonsoft.Json;
using System;

namespace RegistroOnlineBradesco
{

    public class JsonBradesco
    {

        public int cdErro { get; set; }
        public string msgErro { get; set; }

        /// <summary>
        /// Raiz CPF/CNPJ Beneficiário
        /// </summary>
        [Formato(TipoCampo.Numerico, 9)]
        public string nuCPFCNPJ { get; set; }

        /// <summary>
        /// Filial CPF/CNPJ Beneficiário 
        /// Se CPF, filial = 0
        /// </summary>
        [Formato(TipoCampo.Numerico, 4)] 
        public string filialCPFCNPJ { get; set; }

        /// <summary>
        /// Dígito de Controle CPF/CNPJ Beneficiário
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string ctrlCPFCNPJ { get; set; }

        /// <summary>
        /// Tipo de Acesso Fixo “2” – Negociação
        /// </summary>
        [Formato(TipoCampo.Numerico, 1)]
        public string cdTipoAcesso { get; private set; } = "2";

        /// <summary>
        /// Club Banco – 237 (Bradesco) Fixo “2269651”
        /// </summary>
        [Formato(TipoCampo.Numerico, 10)]
        public string clubBanco { get; private set; } = "2269651";

        /// <summary>
        /// Tipo de Contrato – Fixo “48” 
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string cdTipoContrato { get; private set; } = "48";

        /// <summary>
        /// Número de Sequência do Contrato
        /// </summary>
        [Formato(TipoCampo.Numerico, 10)]
        public string nuSequenciaContrato { get; set; }

        /// <summary>
        /// ID Produto (código da carteira/modalidade de cobrança. Ex 09 Cobrança escritural, 05 Cobrança de Seguros)
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string idProduto { get; private set; } = "09";

        /// <summary>
        /// Número da Negociação
        /// Formato:Agencia: 4 posições (Sem digito)
        /// Zeros: 7 posições
        /// Conta: 7 posições (Sem digito)
        /// </summary>
        [Formato(TipoCampo.Numerico, 18)]
        public string nuNegociacao { get; set; }

        /// <summary>
        /// Código do Banco – Fixo “237” 
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string cdBanco { get; private set; } = "237";

        /// <summary>
        /// Número de Sequência do Contrato
        /// </summary>
        [Formato(TipoCampo.Numerico, 10)]
        public string eNuSequenciaContrato { get; set; }

        /// <summary>
        /// Tipo de Registro – Fixo “1” (à vencer/vencido)
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string tpRegistro { get; private set; } = "1";

        /// <summary>
        /// Código do Produto
        /// </summary>
        [Formato(TipoCampo.Numerico, 8)]
        public string cdProduto { get; set; }

        /// <summary>
        /// Número do Título (Nosso Número sem o dígito) 
        /// </summary>
        [Formato(TipoCampo.Numerico, 11)]
        public string nuTitulo { get; set; }

        /// <summary>
        /// Número do Cliente (Seu Número) - (Identificação do título para o cliente)
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 10)] 
        public string nuCliente { get; set; }

        /// <summary>
        /// Data de Emissão do Título (Formato: DD.MM.AAAA)
        /// </summary>
        public DateTime dtEmissaoTitulo { get; set; }

        /// <summary>
        /// Data de Vencimento do Título (Formato: DD.MM.AAAA)
        /// Obs: Data de Vencimento do título deve ser maior ou igual a data de emissão do título
        /// </summary>
        public DateTime dtVencimentoTitulo { get; set; }

        /// <summary>
        /// Tipo de Vencimento – Fixo “0” 
        /// </summary>
        public string tpVencimento { get; private set; } = "0";

        /// <summary>
        /// Valor Nominal do Título
        /// Se moeda Real, preencher no formato: 10000 (título no valor de R$100,00). Se moeda indexada, preencher no formato: 10000000 (título no valor de U$100,00).
        /// Caso o contrato de Cobrança não seja específico para moeda indexada, o registro será realizado em moeda Real.
        /// </summary>
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlNominalTitulo { get; set; }

        /// <summary>
        /// Código da Espécie do Título Códigos possíveis de acordo com item 9.1
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string cdEspecieTitulo { get; private set; } = "02"; // DM - Duplicata Mercantil

        /// <summary>
        /// Tipo de Protesto Automático ou Negativação 
        /// 01 - DIAS CORRIDOS PARA PROTESTO 
        /// 02 - DIAS ÚTEIS PARA PROTESTO 
        /// 03 - DIAS CORRIDOS PARA NEGATIVAÇÃO
        /// (Não disponível para o Registro Online)
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string tpProtestoAutomaticoNegativacao { get; private set; } = "0";

        /// <summary>
        /// ( Prazo de Protesto, prazo mínimo de protesto 5 dias )
        /// (Não disponível para o Registro Online)
        /// 
        /// Prazo para Protesto Automático ou Negativação
        /// Para Protesto na condição de dias úteis: 3 dias após o vencimento. 
        /// Dias corridos 5 dias após vencimento.
        /// Para Negativação considerar 5 dias corridos após o vencimento.
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string prazoProtestoAutomaticoNegativacao { get; private set; } = "0";

        /// <summary>
        /// Controle Participante
        /// ( Campo de responsabilidade do cliente, não consistido pelo banco ) 
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 25)] 
        public string controleParticipante { get; set; }

        /// <summary>
        /// Indicador de Pagamento Parcial
        /// domínio ‘S’ ou ‘N’ 
        /// ( Indicador de pagamento parcial, segundo regra da nova Plataforma de Cobrança)
        /// (Campo não disponível para o registro online)
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 1)] 
        public string cdPagamentoParcial { get; private set; } = "";

        /// <summary>
        /// Quantidade de Pagamentos Parciais
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)] 
        public string qtdePagamentoParcial { get; private set; } = "0";

        /// <summary>
        /// Percentual de Juros
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)] 
        public string percentualJuros { get; set; }

        /// <summary>
        /// Valor de Juros
        /// Se o campo percentualjuros for preenchido, não deve ser preenchido esse campo
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlJuros { get; set; } 

        /// <summary>
        /// Quantidade de dias para cálculo Juros
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)]
        public string qtdeDiasJuros { get; set; }

        /// <summary>
        /// Percentual de Multa
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)] 
        public string percentualMulta { get; set; }

        /// <summary>
        /// Valor da Multa 
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlMulta { get; set; }

        /// <summary>
        /// Quantidade de dias para cálculo Multa
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string qtdeDiasMulta { get; set; }

        /// <summary>
        /// Percentual do Desconto 1
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)]
        public string percentualDesconto1 { get; set; }

        /// <summary>
        /// Valor do Desconto 1
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlDesconto1 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 1 
        /// </summary>
        public string dataLimiteDesconto1 { get; set; }

        /// <summary>
        /// Percentual do Desconto 2
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)]
        public string percentualDesconto2 { get; set; }

        /// <summary>
        /// Valor do Desconto 2 
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlDesconto2 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 2
        /// </summary>
        public string dataLimiteDesconto2 { get; set; }

        /// <summary>
        /// Percentual do Desconto 3 
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)]
        public string percentualDesconto3 { get; set; }

        /// <summary>
        /// Valor do Desconto 3
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlDesconto3 { get; set; }

        /// <summary>
        /// Data Limite para Desconto 3 
        /// </summary>
        public string dataLimiteDesconto3 { get; set; }

        /// <summary>
        /// Prazo para Bonificação:
        /// 1 – dias corridos
        /// 2 – dias úteis
        /// Obrigatório quando houver bonificação
        /// </summary>
        [Formato(TipoCampo.Numerico, 2)] 
        public string prazoBonificacao { get; set; }

        /// <summary>
        /// Percentual de Bonificação
        /// Formato do Campo: Conforme item 9.2 do manual
        /// </summary>
        [Formato(TipoCampo.Numerico, 8, 5)]
        public string percentualBonificacao { get; set; }

        /// <summary>
        /// Valor de Bonificação
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlBonificacao { get; set; }

        /// <summary>
        /// Data Limite para Bonificação
        /// </summary>
        public string dtLimiteBonificacao { get; set; }

        /// <summary>
        /// Valor do Abatimento
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlAbatimento { get; set; }

        /// <summary>
        /// Valor do IOF 
        /// </summary>
#warning Não encontrei o formato correto desse campo, então usei o mesmo formato de outro campo de valor que tinha o mesmo tamanho.
        [Formato(TipoCampo.Numerico, 17, 2)]
        public string vlIOF { get; set; }

        /// <summary>
        /// Nome do Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 70)]
        public string nomePagador { get; set; }

        /// <summary>
        /// Endereço do Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string logradouroPagador { get; set; }

        /// <summary>
        /// Número do logradouro do endereço do Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 10)]
        public string nuLogradouroPagador { get; set; }

        /// <summary>
        /// Complemento do Endereço do Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 15)]
        public string complementoLogradouroPagador { get; set; }

        /// <summary>
        /// CEP do Pagador 
        /// </summary>
        [Formato(TipoCampo.Numerico, 5)]
        public string cepPagador { get; set; }

        /// <summary>
        /// Complemento do CEP do Pagador
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string complementoCepPagador { get; set; }

        /// <summary>
        /// Bairro Pagador 
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string bairroPagador { get; set; }

        /// <summary>
        /// Município Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 30)]
        public string municipioPagador { get; set; }

        /// <summary>
        /// UF Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 2)]
        public string ufPagador { get; set; }

        /// <summary>
        /// Indicador CPF/CNPJ Pagador
        /// 1 – CPF 
        /// 2 – CNPJ 
        /// </summary>
        [Formato(TipoCampo.Numerico, 1)]
        public string cdIndCpfcnpjPagador { get; set; }

        /// <summary>
        /// Número do CPF/CNPJ Pagador 
        /// Se CPF = 00099999999999 com controle 
        /// Se CNPJ = 99999999999999 com filial e controle
        /// </summary>
        [Formato(TipoCampo.Numerico, 14)]
        public string nuCpfcnpjPagador { get; set; }

        /// <summary>
        /// Endereço Eletrônico Pagador
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 70)]
        public string endEletronicoPagador { get; set; }

        /// <summary>
        /// Nome do Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string nomeSacadorAvalista { get; set; }

        /// <summary>
        /// Endereço do Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string logradouroSacadorAvalista { get; set; }

        /// <summary>
        /// Número do Endereço do Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 10)] 
        public string nuLogradouroSacadorAvalista { get; set; }

        /// <summary>
        /// Complemento do Endereço Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 15)] 
        public string complementoLogradouroSacadorAvalista { get; set; }

        /// <summary>
        /// CEP do Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Numerico, 5)]
        public string cepSacadorAvalista { get; set; }

        /// <summary>
        /// Complemento do CEP do Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Numerico, 3)]
        public string complementoCepSacadorAvalista { get; set; }

        /// <summary>
        /// Bairro Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string bairroSacadorAvalista { get; set; }

        /// <summary>
        /// Município Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 40)]
        public string municipioSacadorAvalista { get; set; }

        /// <summary>
        /// UF Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 2)]
        public string ufSacadorAvalista { get; set; }

        /// <summary>
        /// Indicador CPF/CNPJ Sacador Avalista
        /// 1 – CPF 
        /// 2 – CNPJ 
        /// </summary>
        [Formato(TipoCampo.Numerico, 1)]
        public string cdIndCpfcnpjSacadorAvalista { get; set; }

        /// <summary>
        /// Número do CPF/CNPJ Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Numerico, 14)]
        public string nuCpfcnpjSacadorAvalista { get; set; }

        /// <summary>
        /// Endereço Eletrônico Sacador Avalista
        /// </summary>
        [Formato(TipoCampo.Alfanumerico, 70)]
        public string endEletronicoSacadorAvalista { get; set; }

    }
}
