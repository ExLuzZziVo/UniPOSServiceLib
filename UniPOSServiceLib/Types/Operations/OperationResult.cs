#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using CoreLib.CORE.Helpers.StringHelpers;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations
{
    public abstract class OperationResult
    {
        /// <summary>
        /// Оригинальная дата и время совершения операции на внешнем устройстве
        ///</summary>
        [Display(Name = "Оригинальная дата и время совершения операции на внешнем устройстве")]
        [Id(21)]
        public DateTime? TerminalOperationDateTime { get; set; }

        /// <summary>
        /// Код операции
        ///</summary>
        [Display(Name = "Код операции")]
        [Id(25)]
        public OperationType? OperationCode { get; set; }

        /// <summary>
        /// Идентификатор внешнего устройства
        ///</summary>
        [Display(Name = "Идентификатор внешнего устройства")]
        [Id(27)]
        public string TerminalId { get; set; }

        /// <summary>
        /// Статус проведения транзакции
        ///</summary>
        [Display(Name = "Статус проведения транзакции")]
        [Id(39)]
        public ResultStatusCode? TransactionStatus { get; set; }

        /// <summary>
        /// Данные для печати на чеке
        ///</summary>
        [Display(Name = "Данные для печати на чеке")]
        [Id(90)]
        public string ReceiptData { get; set; }

        /// <summary>
        /// Необработанные поля протокола SA
        ///</summary>
        [Display(Name = "Необработанные поля протокола SA")]
        public Dictionary<byte, string> UnhandledFields { get; set; }

        /// <summary>
        /// Сырые данные запроса
        ///</summary>
        [Display(Name = "Сырые данные запроса")]
        public string RawData { get; set; }

        /// <summary>
        /// Обрабатывает <see cref="ReceiptData"/>, выделяя значения тегов 0xDF и 0xDA
        /// </summary>
        /// <returns>Массив строк, в котором содержатся обработанные данные для печати на чеке (Значения тегов 0xDF и 0xDA). Если строка <see cref="ReceiptData"/> пустая или ее не удалось обработать - возвращает null</returns>
        public string[] GetFormattedReceiptData()
        {
            if (ReceiptData.IsNullOrEmptyOrWhiteSpace())
            {
                return null;
            }

            var result = Regex.Split(ReceiptData, @"0[xX][0-9a-fA-F]{2}\^\^").Where(s => s != string.Empty)
                .Select(s => s.Remove(s.Length - 1)).ToArray();

            return result.Any() ? result : null;
        }
    }
}