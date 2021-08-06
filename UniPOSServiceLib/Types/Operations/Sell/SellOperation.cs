using UniPOSServiceLib.Types.Enums;

namespace UniPOSServiceLib.Types.Operations.Sell
{
    /// <summary>
    /// Оплата
    /// </summary>
    public class SellOperation : FinancialOperation<SellResult>
    {
        /// <summary>
        /// Оплата
        /// </summary>
        /// <param name="amount">Сумма операции</param>
        /// <param name="currencyCode">Код валюты операции</param>
        public SellOperation(decimal amount, string currencyCode) : base(amount, currencyCode,
            OperationType.Sell) { }
    }
}