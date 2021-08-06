using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using CoreLib.CORE.Types;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class Operation<T> where T : OperationResult, new()
    {
        private static readonly Encoding Windows1251Encoding = Encoding.GetEncoding("windows-1251");

        /// <summary>
        /// Создание запроса к службе DC2
        /// </summary>
        /// <param name="type">Тип операции</param>
        public Operation(OperationType type)
        {
            Type = type;
        }

        /// <summary>
        /// Тип операции
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип операции")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Id(25)]
        public OperationType Type { get; }

        /// <summary>
        /// Идентификатор внешнего устройства
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор внешнего устройства")]
        [Id(27)]
        public string TerminalId { get; private set; }

        /// <summary>
        /// Проверка текущего запроса
        /// </summary>
        /// <returns>Список ошибок</returns>
        protected virtual IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            return validationResults;
        }

        /// <summary>
        /// Асинхронное выполнение текущего запроса
        /// </summary>
        /// <param name="connectionSettings">Параметры службы DC2</param>
        /// <returns>Задача, представляющая асинхронную операцию выполнения текущего запроса к службе DC2</returns>
        public virtual async Task<T> ExecuteAsync(TerminalConnectionSettings connectionSettings)
        {
            var xmlData = Windows1251Encoding.GetBytes(GenerateXML(connectionSettings));

            var request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:{connectionSettings.ServicePort}");
            request.Method = WebRequestMethods.Http.Post;
            request.Accept = "text/xml";
            request.ContentType = "text/xml; charset=windows-1251";
            request.ContentLength = xmlData.Length;

            using (var str = request.GetRequestStream())
            {
                await str.WriteAsync(xmlData, 0, xmlData.Length);
            }

            string responseResult;

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var sr = new MemoryStream())
                {
                    await response.GetResponseStream().CopyToAsync(sr);

                    responseResult = Windows1251Encoding.GetString(sr.ToArray());
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpRequestException(responseResult);
                }
            }

            return ProcessResponse(responseResult);
        }

        /// <summary>
        /// Асинхронное выполнение текущего запроса
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="connectionSettings">Параметры службы DC2</param>
        /// <returns>Задача, представляющая асинхронную операцию выполнения текущего запроса к службе DC2</returns>
        public virtual async Task<T> ExecuteAsync(HttpClient httpClient,
            TerminalConnectionSettings connectionSettings)
        {
            var xml = GenerateXML(connectionSettings);

            string responseResult;

            using (var response = await httpClient.SendAsync(
                new HttpRequestMessage(HttpMethod.Post, $"http://127.0.0.1:{connectionSettings.ServicePort}")
                {
                    Content = new StringContent(xml, Windows1251Encoding, "text/xml"),
                    Headers = { Accept = { MediaTypeWithQualityHeaderValue.Parse("text/xml") } }
                }))
            {
                responseResult = Windows1251Encoding.GetString(await response.Content.ReadAsByteArrayAsync());

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(responseResult);
                }
            }

            return ProcessResponse(responseResult);
        }

        /// <summary>
        /// Генерирует XML-строку с параметрами текущего запроса для передачи в службу DC2
        /// </summary>
        /// <param name="connectionSettings">Параметры службы DC2</param>
        /// <returns>XML-строка с параметрами текущего запроса для передачи в службу DC2</returns>
        private string GenerateXML(TerminalConnectionSettings connectionSettings)
        {
            if (connectionSettings == null)
            {
                throw new ArgumentNullException(nameof(connectionSettings));
            }

            var validationResults = connectionSettings.Validate();

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            TerminalId = connectionSettings.TerminalId;

            validationResults = Validate();

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            var xml = "<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"no\"?>\n<request>";

            foreach (var p in typeof(TerminalConnectionSettings).GetProperties())
            {
                if (p.Name == nameof(TerminalConnectionSettings.ServicePort))
                {
                    continue;
                }

                var pV = p.GetValue(connectionSettings);

                if (pV != null)
                {
                    xml += $"\n\t<{p.Name.ToLower()}>{pV}</{p.Name.ToLower()}>";
                }
            }

            foreach (var p in GetType().GetProperties())
            {
                var pV = p.GetValue(this);

                if (pV != null)
                {
                    string xmlValue;

                    switch (pV)
                    {
                        case decimal decimalValue:
                            xmlValue = ((int)(Math.Round(decimalValue, 2, MidpointRounding.AwayFromZero) * 100))
                                .ToString();

                            break;
                        case Enum enumValue:
                            xmlValue = enumValue.ToString("d");

                            break;
                        default:
                            xmlValue = pV.ToString();

                            break;
                    }

                    var id = ((IdAttribute)Attribute.GetCustomAttribute(p, typeof(IdAttribute))).Id;

                    xml += $"\n\t<field id=\"{id.ToString("00")}\">{xmlValue}</field>";
                }
            }

            xml += $"\n</request>";

            return xml;
        }

        /// <summary>
        /// Обрабатывает ответ на текущий запрос, полученный от службы DC2
        /// </summary>
        /// <param name="xmlResponse">Ответ, полученный от службы DC2</param>
        /// <returns>Результат выполнения операции</returns>
        private static T ProcessResponse(string xmlResponse)
        {
            if (xmlResponse.IsNullOrEmptyOrWhiteSpace())
            {
                return null;
            }

            var responseValues = new Dictionary<byte, string>();

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlResponse);

            byte statusCode = 0;
            var errorDescription = string.Empty;

            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                if (node.Name == "errorcode")
                {
                    if (byte.TryParse(node.InnerText, out var val))
                    {
                        statusCode = val;
                    }
                }
                else if (node.Name == "errordescription")
                {
                    errorDescription = node.InnerText;
                }
                else if (node.Name == "field")
                {
                    var id = node.Attributes?.GetNamedItem("id")?.Value;

                    if (byte.TryParse(id, out var val))
                    {
                        responseValues.Add(val, node.InnerText);
                    }
                }
            }

            if (statusCode > 0 || !errorDescription.IsNullOrEmptyOrWhiteSpace() || responseValues.Count == 0)
            {
                throw new TerminalOperationException(statusCode, errorDescription);
            }

            var result = new T { RawData = xmlResponse };

            foreach (var p in typeof(T).GetProperties())
            {
                if (Attribute.GetCustomAttribute(p, typeof(IdAttribute)) is IdAttribute idAttr)
                {
                    if (responseValues.ContainsKey(idAttr.Id))
                    {
                        switch (idAttr.Id)
                        {
                            case 0:
                            {
                                if (decimal.TryParse(responseValues[idAttr.Id], out var val))
                                {
                                    p.SetValue(result, val / 100);
                                }

                                break;
                            }
                            case 6:
                            case 21:
                            {
                                if (DateTime.TryParseExact(responseValues[idAttr.Id], "yyyyMMddHHmmss",
                                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            case 11:
                            {
                                if (DateTime.TryParseExact(responseValues[idAttr.Id], "yyMM",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            case 25:
                            {
                                if (Enum.TryParse<OperationType>(responseValues[idAttr.Id], out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            case 26:
                            case 28:
                            case 67:
                            {
                                if (int.TryParse(responseValues[idAttr.Id], out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            case 39:
                            {
                                if (Enum.TryParse<ResultStatusCode>(responseValues[idAttr.Id], out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            case 65:
                            {
                                if (Enum.TryParse<UserCommandType>(responseValues[idAttr.Id], out var val))
                                {
                                    p.SetValue(result, val);
                                }

                                break;
                            }
                            default:
                                p.SetValue(result, responseValues[idAttr.Id]);

                                break;
                        }

                        responseValues.Remove(idAttr.Id);
                    }
                }
            }

            result.UnhandledFields = responseValues;

            return result;
        }
    }
}