#region

using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.CheckConnection
{
    /// <summary>
    /// Проверка соединения с банком
    /// </summary>
    public class CheckConnectionOperation : Operation<CheckConnectionResult>
    {
        /// <summary>
        /// Проверка соединения с банком
        /// </summary>
        public CheckConnectionOperation() : base(OperationType.CheckConnection) { }
    }
}