using System;
using CoreLib.CORE.Helpers.EnumHelpers;
using CoreLib.CORE.Helpers.StringHelpers;
using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Common
{
    /// <summary>
    /// Исключение, которое выбрасывается в случае ошибки выполнения операции службой DC2
    /// </summary>
    public class TerminalOperationException : Exception
    {
        /// <summary>
        /// Исключение, которое выбрасывается в случае ошибки выполнения операции службой DC2
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        /// <param name="message">Описание ошибки</param>
        internal TerminalOperationException(byte errorCode, string message)
        {
            ErrorCode = Enum.IsDefined(typeof(DC_Error_Code), errorCode)
                ? (DC_Error_Code)errorCode
                : DC_Error_Code.UNKNOWN;

            Message = message.IsNullOrEmptyOrWhiteSpace() ? ErrorCode.GetDisplayName() : message;
        }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public DC_Error_Code ErrorCode { get; }

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public override string Message { get; }
    }
}