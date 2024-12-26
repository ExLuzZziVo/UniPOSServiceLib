#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace UniPOSServiceLib.Types.Enums
{
    public enum UserCommandType: byte
    {
        /// <summary>
        /// Запрос краткого отчета
        ///</summary>
        [Display(Name = "Запрос краткого отчета")]
        ShortReport = 20,

        /// <summary>
        /// Запрос полного отчета
        ///</summary>
        [Display(Name = "Запрос полного отчета")]
        FullReport = 21,

        /// <summary>
        /// Запрос копии чека
        ///</summary>
        [Display(Name = "Запрос копии чека")] ReceiptCopy = 22
    }
}