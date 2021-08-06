using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;

namespace UniPOSServiceLib.Types.Common
{
    /// <summary>
    /// Параметры службы DC2
    /// </summary>
    public class TerminalConnectionSettings
    {
        /// <summary>
        /// Номер порта службы DC2
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Должно лежать в диапазоне: 1-65535</item>
        /// </list>
        [Display(Name = "Номер порта службы DC2")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Range(1, 65535, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int ServicePort { get; set; } = 9015;

        /// <summary>
        /// Идентификатор внешнего устройства
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Идентификатор внешнего устройства")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        public string TerminalId { get; set; }

        /// <summary>
        /// Номер COM-порта
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-99</item>
        /// </list>
        [Display(Name = "Номер COM-порта")]
        [Range(1, 99, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Ncom { get; set; }

        /// <summary>
        /// Скорость COM-порта
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 1-230400</item>
        /// </list>
        [Display(Name = "Скорость COM-порта")]
        [Range(1, 230400, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Baudrate { get; set; }

        /// <summary>
        /// IP-адрес и порт подключения терминала
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно соответствовать регулярному выражению <see cref="RegexExtensions.IpAddressWithPortPattern"/></item>
        /// </list>
        [Display(Name = "IP-адрес и порт подключения терминала")]
        [RegularExpression(RegexExtensions.IpAddressWithPortPattern,
            ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringFormatError")]
        public string IpAddr { get; set; }

        /// <summary>
        /// Предоставляемое время на выполнение операции в секундах
        ///</summary>
        /// <list type="bullet">
        /// <item>Должно лежать в диапазоне: 0-3600</item>
        /// </list>
        [Display(Name = "Предоставляемое время на выполнение операции в секундах")]
        [Range(0, 3600, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "DigitRangeValuesError")]
        public int? Timeout { get; set; }

        /// <summary>
        /// Проверка параметров
        /// </summary>
        /// <returns>Список ошибок</returns>
        internal IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            return validationResults;
        }
    }
}