#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.Cancel
{
    /// <summary>
    /// Отмена платежа
    /// </summary>
    public class CancelOperation : FinancialOperation<CancelResult>
    {
        /// <summary>
        /// Отмена платежа
        /// </summary>
        /// <param name="amount">Сумма операции</param>
        /// <param name="currencyCode">Код валюты операции. По умолчанию: 643 (Российский рубль)</param>
        public CancelOperation(decimal amount, string currencyCode = "643") : base(amount, currencyCode,
            OperationType.CancelSell) { }

        /// <summary>
        /// Код авторизации
        ///</summary>
        /// <list type="bullet">
        /// <item>Максимальная длина: 8</item>
        /// </list>
        /// <remarks>Если оставить пустым, то терминал может запросить его сам</remarks>
        [Display(Name = "Код авторизации")]
        [MaxLength(8, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [Id(13)]
        public string AuthCode { get; set; }

        /// <summary>
        /// Номер ссылки (RRN)
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.PositiveNumberPattern"/></item>
        /// <item>Максимальная длина: 12</item>
        /// </list>
        /// <remarks>Если оставить пустым, то терминал может запросить его сам</remarks>
        [Display(Name = "Номер ссылки (RRN)")]
        [MaxLength(12, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Id(14)]
        public string LinkNum { get; set; }
    }
}