# UniPOSServiceLib
Библиотека для работы с терминалами на базе ПО UNIPOS Terminal при помощи службы DUALConnector2.
<br/>
<br/>
Создана по официальной документации со следующих источников: <a href="https://inpas.ru/content/svobodno-rasprostranyaemoe-po" rel="nofollow">1</a>.
<br/>
<br/>
Для работы библиотеки необходима поддержка кодировки win-1251, поэтому перед ее использованием необходимо установить NuGet пакет <b>System.Text.Encoding.CodePages</b> в основной проект и вызвать следующий метод: 
```csharp
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
```
<br/>
Пример использования:
<br/>
```csharp
var connectionSettings = new TerminalConnectionSettings();
// Если используете HttpClient через внедрение зависимостей
var result = await new <Операция>.ExecuteAsync(_httpClient, connectionSettings);
// Если нет
var result = await new <Операция>.ExecuteAsync(connectionSettings);
```

Все доступные операции находятся в пространстве имен <b>UniPOSServiceLib.Types.Operations</b>
<br/>
<br/>
Зависимости CoreLib вы можете найти <a href="https://github.com/ExLuzZziVo/CoreLib" rel="nofollow">тут</a>.
