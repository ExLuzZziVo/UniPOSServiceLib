using System;
using System.ComponentModel.DataAnnotations;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class FinancialResult : TransactionResult
    {
        /// <summary>
        /// Сумма операции
        ///</summary>
        [Display(Name = "Сумма операции")]
        [Id(0)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Код валюты операции
        ///</summary>
        [Display(Name = "Код валюты операции")]
        [Id(4)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Код авторизации
        ///</summary>
        [Display(Name = "Код авторизации")]
        [Id(13)]
        public string AuthCode { get; set; }

        /// <summary>
        /// Номер ссылки (RRN)
        ///</summary>
        [Display(Name = "Номер ссылки (RRN)")]
        [Id(14)]
        public string LinkNum { get; set; }

        /// <summary>
        /// Номер карты
        ///</summary>
        [Display(Name = "Номер карты")]
        [Id(10)]
        public string CardNumber { get; set; }

        /// <summary>
        /// Срок действия карты
        ///</summary>
        [Display(Name = "Срок действия карты")]
        [Id(11)]
        public DateTime? CardExpirationDate { get; set; }
    }
}