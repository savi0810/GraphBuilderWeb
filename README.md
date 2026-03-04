# GraphBuilderWeb

## Цель проекта

Проект представляет собой веб-приложение для построения графиков математических функций. 
Структура:

- фронтенд на Blazor (`GraphBuilderFrontend`), отвечающий за UI;
- общую библиотеку `GraphBuilderShared` с моделями данных;
- бэкенд на ASP.NET Core (`GraphBuilderWeb`), который парсит и вычисляет значения функции, используя библиотеку (mXparser).

---

## Основные модули

1. **GraphBuilderFrontend/** – Blazor-приложение, содержит компоненты интерфейса, страницы и сервисы, работающие с API  (`Components/`, `Pages/`, `Services/` и т.д.) содержат Razor-компоненты и менеджеры состояния.. 
2. **GraphBuilderShared/** – общие модели, используемые на фронте и сервере (`GraphRequest`, `PointDTO`, `GraphFunction`).
3. **GraphBuilderWeb/** – ASP.NET Core Web API:
   - `Controllers/` – контроллеры API (например, `GraphController`).
   - `Services/` – сервисы для парсинга и вычисления (`FunctionParserService`, `GraphCalculationService`) и их интерфейсы.

---

## Быстрый старт

1. **Клонирование и открытие**
   ```bash
   git clone <repo-url>
   cd GraphBuilderWeb
   ```

2. **Зависимости и сборка**
   - Убедитесь, что установлен .NET 9 SDK.
   - В корне решения выполните:
     ```powershell
     dotnet restore
     dotnet build
     ```

3. **Запуск бэкенда**
   ```powershell
   cd GraphBuilderWeb
   dotnet run
   ```
   API будет доступно по адресу `https://localhost:5001`.

4. **Запуск фронтенда**
   ```powershell
   cd ..\GraphBuilderFrontend
   dotnet run
   ```
   Браузер автоматически откроет интерфейс; он обращается к API на предыдущем шаге.

> ⚠️ При необходимости настройте `launchSettings.json` или переменные окружения для URL-адресов.

---

## Примеры кода

### Серверные службы

**GraphCalculationService** вычисляет набор точек для функции:
```csharp
var service = new GraphCalculationService();
var points = await service.CalculateFunctionAsync(
    "sin(x)",
    fromX: 0, toX: Math.PI * 2,
    pointsCount: 100);
```

**FunctionParserService** проверяет корректность выражения:
```csharp
var parser = new FunctionParserService();
var validation = await parser.ValidateExpressionAsync("x^2 + 3");
if (!validation.IsValid)
    Console.WriteLine("Ошибка: " + validation.ErrorMessage);
```

### Контроллер API

Метод `POST /api/graph/calculate` принимает `GraphRequest` и возвращает список `PointDTO`.

Пример запроса с помощью `curl`:
```bash
curl -X POST https://localhost:5001/api/graph/calculate \
     -H "Content-Type: application/json" \
     -d '{
           "function":"x^2",
           "fromX":-5,
           "toX":5,
           "pointsCount":50
         }'
```
Ответ:
```json
[
  {"X":-5.0,"Y":25.0},
  {"X":-4.795918,"Y":23.0057},
  ...
]
```


