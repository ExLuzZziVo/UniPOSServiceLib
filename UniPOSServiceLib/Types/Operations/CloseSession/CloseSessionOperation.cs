#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.CloseSession
{
    /// <summary>
    /// Сверка итогов
    /// </summary>
    public class CloseSessionOperation: Operation<CloseSessionResult>
    {
        /// <summary>
        /// Сверка итогов
        /// </summary>
        public CloseSessionOperation() : base(OperationType.CloseSession) { }

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