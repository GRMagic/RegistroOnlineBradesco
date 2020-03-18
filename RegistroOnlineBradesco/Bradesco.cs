using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;

namespace RegistroOnlineBradesco
{
    public class Bradesco
    {
        protected X509Certificate2 Certificado { get; set; }
        protected CmsSigner Assinador { get; set; }
        protected string EndPoint { get; set; }
        private JsonSerializerSettings JsonSettings { get; set; }
        private BoletoValidacao Validador { get; set; } = new BoletoValidacao();

        public Bradesco(string endPoint, string certificadoCaminho, string certificadoSenha)
        {
            Certificado = new X509Certificate2(certificadoCaminho, certificadoSenha);
            Assinador = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, Certificado);
            EndPoint = endPoint;
            Certificado.Verify();

            JsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd.MM.yyyy",
                ContractResolver = new JsonBradescoResolver()
            };
        }

        public void Enviar(Boleto boleto)
        {
            var validacao = Validador.Validate(boleto);
            if (!validacao.IsValid) throw new Exception(validacao.ToString());

            var dados = BradescoMapper.Mapper.Map<JsonBradesco>(boleto);
            var json = JsonConvert.SerializeObject(dados, Newtonsoft.Json.Formatting.Indented, JsonSettings);
            var bytesJson = new UTF8Encoding().GetBytes(json);

            SignedCms signedCms = new SignedCms(new ContentInfo(bytesJson), false);
            signedCms.ComputeSignature(Assinador);

            byte[] signEnv = signedCms.Encode();
            var string64 = Convert.ToBase64String(signEnv);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Timeout = 1000 * 60;
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = "POST";
            request.ContentType = "text/xml";

            var bytes64 = Encoding.UTF8.GetBytes(string64);
            request.ContentLength = bytes64.Length;
            using (var stream = request.GetRequestStream())
            {
                // Escreve o pkcs#7 na request
                stream.Write(bytes64, 0, bytes64.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            using (Stream strm = response.GetResponseStream())
            {
                var doc = new XmlDocument();
                doc.Load(strm);

                var jsonRetorno = HttpUtility.HtmlDecode(doc.GetElementsByTagName("return")?[0]?.InnerText);
                var objRetorno = JsonConvert.DeserializeObject<JsonBradesco>(jsonRetorno);

                if (objRetorno.cdErro != 0)
                    throw new Exception($"O banco retornou a seguinte mensagem de erro: {objRetorno.msgErro} (Cód.:{objRetorno.cdErro})" );
            }
        }
    }
}
