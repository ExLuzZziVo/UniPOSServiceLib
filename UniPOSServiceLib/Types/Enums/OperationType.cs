using System.ComponentModel.DataAnnotations;

namespace UniPOSServiceLib.Types.Enums
{
    public enum OperationType : byte
    {
        /// <summary>
        /// Оплата товаров и услуг
        ///</summary>
        [Display(Name = "Оплата товаров и услуг")]
        Sell = 1,

        /// <summary>
        /// Отмена операции, выполненной в текущем операционном дне
        ///</summary>
        [Display(Name = "Отмена операции, выполненной в текущем операционном дне")]
        CancelSell = 4,

        /// <summary>
        /// Проверка соединения
        ///</summary>
        [Display(Name = "Проверка соединения")]
        CheckConnection = 26,

        /// <summary>
        /// Возврат
        ///</summary>
        [Display(Name = "Возврат")] Refund = 29,

        /// <summary>
        /// Аварийная отмена
        ///</summary>
        [Display(Name = "Аварийная отмена")] EmergencyCancelSell = 53,

        /// <summary>
        /// Сверка итогов
        ///</summary>
        [Display(Name = "Сверка итогов")] CloseSession = 59,

        /// <summary>
        /// Выполнение пользовательской команды
        ///</summary>
        [Display(Name = "Выполнение пользовательской команды")]
        UserCommand = 63
    }
}