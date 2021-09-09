using System.ComponentModel.DataAnnotations;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations.CheckConnection
{
    /// <summary>
    /// Результат проверки соединения с банком
    /// </summary>
    public class CheckConnectionResult : OperationResult
    {
        /// <summary>
        /// Дополнительные данные ответа
        ///</summary>
        [Display(Name = "Дополнительные данные ответа")]
        [Id(19)]
        public string AdditionalResponseData { get; set; }
    }
}