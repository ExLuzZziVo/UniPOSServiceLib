#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace UniPOSServiceLib.Types.Enums
{
    public enum DC_Error_Code: byte
    {
        /// <summary>
        /// Ошибок нет
        ///</summary>
        [Display(Name = "Ошибок нет")] OK = 0,

        /// <summary>
        /// Истёк таймаут операции
        ///</summary>
        [Display(Name = "Истёк таймаут операции")]
        TIMEOUT = 1,

        /// <summary>
        /// Ошибка создания LOG файла
        ///</summary>
        [Display(Name = "Ошибка создания LOG файла")]
        LOG_ERROR = 2,

        /// <summary>
        /// Общая ошибка
        ///</summary>
        [Display(Name = "Общая ошибка")] SYSTEM_ERROR = 3,

        /// <summary>
        /// Ошибка данных запроса
        ///</summary>
        [Display(Name = "Ошибка данных запроса")]
        REQUEST_ERROR = 4,

        /// <summary>
        /// Не найден файл конфигурации
        ///</summary>
        [Display(Name = "Не найден файл конфигурации")]
        CONFIG_NOT_FOUND = 6,

        /// <summary>
        /// Ошибка формата файла конфигурации
        ///</summary>
        [Display(Name = "Ошибка формата файла конфигурации")]
        CONFIG_ERROR_FORMAT = 7,

        /// <summary>
        /// Ошибка параметров логирования
        ///</summary>
        [Display(Name = "Ошибка параметров логирования")]
        CONFIG_ERROR_LOG = 8,

        /// <summary>
        /// Ошибка в параметрах терминала
        ///</summary>
        [Display(Name = "Ошибка в параметрах терминала")]
        CONFIG_ERROR_DEVICES = 9,

        /// <summary>
        /// Ошибка настройки устройства на COM порт
        ///</summary>
        [Display(Name = "Ошибка настройки устройства на COM порт")]
        CONFIG_ERROR_DUBLCOMPORTS = 10,

        /// <summary>
        /// Ошибка в выходных параметрах
        ///</summary>
        [Display(Name = "Ошибка в выходных параметрах")]
        CONFIG_ERROR_OUTPUT = 11,

        /// <summary>
        /// Ошибка при передаче образа чека
        ///</summary>
        [Display(Name = "Ошибка при передаче образа чека")]
        PRINT_ERROR = 12,

        /// <summary>
        /// Ошибка установки связи с устройством
        ///</summary>
        [Display(Name = "Ошибка установки связи с устройством")]
        ERROR_CONNECT = 13,

        /// <summary>
        /// Ошибка в параметрах настройки интерфейса взаимодействия с пользователем
        ///</summary>
        [Display(Name = "Ошибка в параметрах настройки интерфейса взаимодействия с пользователем")]
        CONFIG_ERROR_GUI = 14,

        /// <summary>
        /// Отмена операции
        ///</summary>
        [Display(Name = "Отмена операции")] CANCEL_OPERATION = 15,

        /// <summary>
        /// Устройство занято
        ///</summary>
        [Display(Name = "Устройство занято")] DEVICE_BUSY = 16,

        /// <summary>
        /// Неизвестная ошибка
        ///</summary>
        [Display(Name = "Неизвестная ошибка")] UNKNOWN = 255
    }
}