#region

using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.EmergencyCancel
{
    /// <summary>
    /// Аварийная отмена платежа
    /// </summary>
    public class EmergencyCancelOperation : FinancialOperation<EmergencyCancelResult>
    {
        /// <summary>
        /// Аварийная отмена платежа
        /// </summary>
        /// <param name="amount">Сумма операции</param>
        /// <param name="currencyCode">Код валюты операции. По умолчанию: 643 (Российский рубль)</param>
        public EmergencyCancelOperation(decimal amount, string currencyCode = "643") : base(amount, currencyCode,
            OperationType.EmergencyCancelSell) { }
    }
}