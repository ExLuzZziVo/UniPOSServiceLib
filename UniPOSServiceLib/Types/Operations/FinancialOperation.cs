using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.ObjectHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class FinancialOperation<T> : Operation<T> where T : FinancialResult, new()
    {
        /// <summary>
        /// Создание запроса к службе DC2, связанного с финансовыми операциями
        /// </summary>
        /// <param name="amount">Сумма операции</param>
        /// <param name="currencyCode">Код валюты операции</param>
        /// <param name="type">Тип операции</param>
        protected FinancialOperation(decimal amount, string currencyCode, OperationType type) : base(type)
        {
            if (!amount.IsInRange(0.01m, 9999999999.99m))
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    string.Format(ValidationStrings.ResourceManager.GetString("DigitRangeValuesError"),
                        GetType().GetProperty(nameof(Amount)).GetPropertyDisplayName(), 0.01, 9999999999.99));
            }

            if (currencyCode.IsNullOrEmptyOrWhiteSpace() || currencyCode.Length > 3 ||
                !Regex.IsMatch(currencyCode, RegexExtensions.PositiveNumberPattern))
            {
                throw new ArgumentException(
                    string.Format(
                        ValidationStrings.ResourceManager.GetString("StringFormatError"),
                        GetType().GetProperty(nameof(CurrencyCode)).GetPropertyDisplayName()),
                    nameof(currencyCode));
            }

            Amount = amount;
            CurrencyCode = currencyCode;
        }

        /// <summary>
        /// Сумма операции
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 0.01-9999999999.99</item>
        /// </list>
        [Display(Name = "Сумма операции")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(0.01, 9999999999.99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Id(0)]
        public decimal Amount { get; }

        /// <summary>
        /// Код валюты операции
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.PositiveNumberPattern"/></item>
        /// <item>Максимальная длина: 3</item>
        /// </list>
        [Display(Name = "Код валюты операции")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(3, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        [RegularExpression(RegexExtensions.PositiveNumberPattern, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        [Id(4)]
        public string CurrencyCode { get; }

        /// <summary>
        /// Уникальный номер транзакции на стороне внешнего устройства
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-999999</item>
        /// </list>
        [Display(Name = "Уникальный номер транзакции на стороне внешнего устройства")]
        [Range(0, 999999, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        [Id(26)]
        public int? UniqueTransactionNumber { get; set; }
    }
}