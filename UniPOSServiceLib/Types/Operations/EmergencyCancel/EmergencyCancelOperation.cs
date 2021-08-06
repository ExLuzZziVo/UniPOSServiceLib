using UniPOSServiceLib.Types.Enums;

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
        /// <param name="currencyCode">Код валюты операции</param>
        public EmergencyCancelOperation(decimal amount, string currencyCode) : base(amount, currencyCode,
            OperationType.EmergencyCancelSell) { }
    }
}