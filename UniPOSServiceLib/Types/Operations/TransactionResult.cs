using System;
using System.ComponentModel.DataAnnotations;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class TransactionResult : OperationResult
    {
        /// <summary>
        /// Код ответа от хоста
        ///</summary>
        [Display(Name = "Код ответа от хоста")]
        [Id(15)]
        public string ResponseCode { get; set; }

        /// <summary>
        /// Дополнительные данные ответа
        ///</summary>
        [Display(Name = "Дополнительные данные ответа")]
        [Id(19)]
        public string AdditionalResponseData { get; set; }

        /// <summary>
        /// Уникальный номер транзакции на стороне внешнего устройства
        ///</summary>
        [Display(Name = "Уникальный номер транзакции на стороне внешнего устройства")]
        [Id(26)]
        public int? UniqueTransactionNumber { get; set; }

        /// <summary>
        /// Дополнительные данные транзакции
        ///</summary>
        [Display(Name = "Дополнительные данные транзакции")]
        [Id(86)]
        public string AdditionalTransactionData { get; set; }
    }
}