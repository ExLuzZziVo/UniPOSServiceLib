using System;

namespace UniPOSServiceLib.Types.Common
{
    /// <summary>
    /// Атрибут для сопоставления свойства с полем протокола SA
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IdAttribute : Attribute
    {
        /// <summary>
        /// Атрибут для сопоставления свойства с полем протокола SA
        /// </summary>
        /// <param name="id">Поле протокола SA</param>
        public IdAttribute(byte id)
        {
            Id = id;
        }

        /// <summary>
        /// Поле протокола SA
        /// </summary>
        public byte Id { get; }
    }
}