#region

using System.ComponentModel.DataAnnotations;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.ExecuteUserCommand
{
    /// <summary>
    /// Результат выполнения пользовательской команды
    /// </summary>
    public class ExecuteUserCommandResult: OperationResult
    {
        /// <summary>
        /// Идентификатор пользовательской команды
        ///</summary>
        [Display(Name = "Идентификатор пользовательской команды")]
        [Id(65)]
        public UserCommandType? UserCommandType { get; set; }

        /// <summary>
        /// Результат выполнения команды
        ///</summary>
        [Display(Name = "Результат выполнения команды")]
        [Id(67)]
        public int? ExecutionStatus { get; set; }
    }
}