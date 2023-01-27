#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace UniPOSServiceLib.Types.Enums
{
    public enum ResultStatusCode : byte
    {
        /// <summary>
        /// Неопределенный статус. Транзакция не выполнена
        ///</summary>
        [Display(Name = "Неопределенный статус. Транзакция не выполнена")]
        Unknown = 0,

        /// <summary>
        /// Одобрено. Положительное завершение транзакции
        ///</summary>
        [Display(Name = "Одобрено. Положительное завершение транзакции")]
        Success = 1,

        /// <summary>
        /// Отказано. Транзакция проведена, но ее одобрение не получено
        ///</summary>
        [Display(Name = "Отказано. Транзакция проведена, но ее одобрение не получено")]
        Denied = 16,

        /// <summary>
        /// Нет соединения
        ///</summary>
        [Display(Name = "Нет соединения")] NoConnection = 34,

        /// <summary>
        /// Операция прервана
        ///</summary>
        [Display(Name = "Операция прервана")] OperationCanceled = 53,

        /// <summary>
        /// Oбщая ошибка
        ///</summary>
        [Display(Name = "Oбщая ошибка")] CommonError = 100,

        /// <summary>
        /// Ошибка загрузки SAClient.dll
        ///</summary>
        [Display(Name = "Ошибка загрузки SAClient.dll")]
        DllLoadError = 101,

        /// <summary>
        /// Ошибка параметров связи с терминалом
        ///</summary>
        [Display(Name = "Ошибка параметров связи с терминалом")]
        TerminalConnectionSettingsError = 102,

        /// <summary>
        /// Ошибка процесса обмена с терминалом
        ///</summary>
        [Display(Name = "Ошибка процесса обмена с терминалом")]
        TerminalExchangeError = 103,

        /// <summary>
        /// Ошибка удаления файлов отчёта
        ///</summary>
        [Display(Name = "Ошибка удаления файлов отчёта")]
        RemoveReportError = 104
    }
}