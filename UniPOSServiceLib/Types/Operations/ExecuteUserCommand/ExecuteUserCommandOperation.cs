#region

using System.ComponentModel.DataAnnotations;
using CoreLib.CORE.Resources;
using UniPOSServiceLib.Types.Common;
using UniPOSServiceLib.Types.Enums;

#endregion

namespace UniPOSServiceLib.Types.Operations.ExecuteUserCommand
{
    /// <summary>
    /// Выполнение пользовательской команды
    /// </summary>
    public class ExecuteUserCommandOperation : Operation<ExecuteUserCommandResult>
    {
        /// <summary>
        /// Выполнение пользовательской команды
        /// </summary>
        /// <param name="userCommandType">Тип пользовательской операции</param>
        public ExecuteUserCommandOperation(UserCommandType userCommandType) : base(OperationType.UserCommand)
        {
            UserCommandType = userCommandType;
        }

        /// <summary>
        /// Тип пользовательской операции
        ///</summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// </list>
        [Display(Name = "Тип пользовательской операции")]
        [Required(ErrorMessageResourceType = typeof(ValidationStrings), ErrorMessageResourceName = "RequiredError")]
        [Id(65)]
        public UserCommandType UserCommandType { get; }
    }
}