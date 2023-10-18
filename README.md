# UniPOSServiceLib
Библиотека для работы с терминалами на базе ПО UNIPOS Terminal при помощи службы DUALConnector2.


Создана по официальной документации со следующих источников: [1](https://inpas.ru/content/svobodno-rasprostranyaemoe-po).


Для работы библиотеки необходима поддержка кодировки win-1251, поэтому перед ее использованием необходимо установить NuGet пакет **System.Text.Encoding.CodePages** в основной проект и вызвать следующий метод:

```csharp
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
```

Пример использования:


```csharp
// В настроках необходимо указать порт службы DC2 и идентификатор терминала
var connectionSettings = new TerminalConnectionSettings();
// Если используете HttpClient через внедрение зависимостей
var result = await new <Операция>.ExecuteAsync(_httpClient, connectionSettings);
// Если нет
var result = await new <Операция>.ExecuteAsync(connectionSettings);
```

Все доступные операции находятся в пространстве имен **UniPOSServiceLib.Types.Operations**


Зависимости CoreLib вы можете найти [тут](https://github.com/ExLuzZziVo/CoreLib).
