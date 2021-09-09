using System;
using System.ComponentModel.DataAnnotations;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class TransactionResult : OperationResult
    {
        /// <summary>
        /// Оригинальная дата и время совершения операции на хосте
        ///</summary>
        [Display(Name = "Оригинальная дата и время совершения операции на хосте")]
        [Id(6)]
        public DateTime? HostOperationDateTime { get; set; }

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
        /// Идентификатор транзакции в коммуникационном сервере
        ///</summary>
        [Display(Name = "Идентификатор транзакции в коммуникационном сервере")]
        [Id(23)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Уникальный номер транзакции на стороне внешнего устройства
        ///</summary>
        [Display(Name = "Уникальный номер транзакции на стороне внешнего устройства")]
        [Id(26)]
        public int? UniqueTransactionNumber { get; set; }

        /// <summary>
        /// Идентификатор продавца
        ///</summary>
        [Display(Name = "Идентификатор продавца")]
        [Id(28)]
        public int? MerchantId { get; set; }

        /// <summary>
        /// Дополнительные данные транзакции
        ///</summary>
        [Display(Name = "Дополнительные данные транзакции")]
        [Id(86)]
        public string AdditionalTransactionData { get; set; }
    }
}