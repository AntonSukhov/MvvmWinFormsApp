# KODA.md — Контекст проекта MvvmWinFormsApp

## Обзор проекта

**MvvmWinFormsApp** — это Windows Forms-приложение (**.NET Framework 4.7**, C# 8.0) для просмотра **справочника персон** (Person), построенное по паттерну **MVVM** (Model – View – ViewModel) с использованием **Autofac** для внедрения зависимостей.

Проект построен по слоистой архитектуре с чётким разделением на уровни:
- **View** (Views) — формы WinForms, только отображение
- **ViewModel** (ViewModels) — презентационная логика и команды
- **Model** (Models) — доменные данные (PersonModel)
- **Service** (Services) — сервисы данных и UI-обёртки (окна, сообщения)
- **Infrastructure** (Factories, DependencyConfiguration) — фабрика окон и Composition Root
- **Common** — общие утилиты (базовый класс уведомлений, команда, константы)

**Стадия развития:** проект находится на начальном этапе — это учебно-эталонный каркас MVVM на WinForms. Реализован один домен (Person) с одним окном-справочником (`PersonDirectoryView`), открываемым из MDI-родителя (`MainView`). Архитектура закладывалась с расчётом на расширение — новые окна и домены добавляются через `WindowServiceFactory` и регистрацию в `CompositionRoot`.

---

## Структура проекта

```
MvvmWinFormsApp/
├── MvvmWinFormsApp.sln              # Решение (1 проект)
├── README.md                        # Документация (архитектура, диаграммы)
└── MvvmWinFormsApp/                 # Основной (и единственный) проект
    ├── Program.cs                   # Точка входа (сборка контейнера, запуск MainView)
    ├── App.config                   # Конфигурация (binding redirects)
    ├── MvvmWinFormsApp.csproj       # Старый формат csproj (net47, LangVersion 8.0)
    ├── Common/                      # Общие утилиты
    │   ├── Constants.cs             # Имена сервисов для named-регистраций
    │   ├── NotifyPropertyChangedBase.cs  # INotifyPropertyChanged + SetProperty
    │   └── RelayCommand.cs          # ICommand (namespace MvvmWinFormsApp.Commands!)
    ├── DependencyConfiguration/
    │   └── CompositionRoot.cs       # Autofac-контейнер (named singletons)
    ├── Enums/
    │   └── WindowActionResult.cs    # None/OK/Cancel/Yes/No
    ├── Factories/
    │   ├── IWindowServiceFactory.cs # Интерфейс фабрики окон
    │   └── WindowServiceFactory.cs  # Создание View+ViewModel из ILifetimeScope
    ├── Models/
    │   └── PersonModel.cs           # Id, Name, Age (+ уведомления об изменениях)
    ├── Services/
    │   ├── IWindowService.cs        # Абстракция окна (Show/ShowDialog/SetMdiParent)
    │   ├── WindowService.cs         # Form, реализующая IWindowService
    │   ├── IMessageBoxService.cs    # Абстракция сообщений
    │   ├── MessageBoxService.cs     # MessageBox.Show
    │   ├── IDataSourceService.cs    # Абстракция источника данных
    │   └── DataSourceService.cs     # Возврат захардкоженного списка персон
    ├── ViewModels/
    │   ├── MainViewModel.cs         # Команда открытия справочника персон
    │   └── PersonDirectoryViewModel.cs  # Список персон, выбранная персона
    ├── Views/
    │   ├── MainView.cs/.Designer.cs/.resx          # MDI-родитель
    │   └── PersonDirectoryView.cs/.Designer.cs/.resx  # Справочник персон (MDI-потомок)
    └── Properties/                  # AssemblyInfo, Resources, Settings
```

---

## Технологии и зависимости

### Фреймворк
- **.NET Framework 4.7** (`v4.7`), OutputType `WinExe`
- **C# 8.0** (`<LangVersion>8.0</LangVersion>`)
- Старый формат csproj (ToolsVersion 15.0, явный список `Compile Include`)

### DI
- **Autofac 8.2.0** — контейнер зависимостей
- **Autofac.Extras.CommonServiceLocator 6.1.0** — адаптер CommonServiceLocator

### Пакеты-обёртки (бэкпорты для net47)
- `Microsoft.Bcl.AsyncInterfaces 9.0.3`
- `System.Diagnostics.DiagnosticSource 9.0.3`
- `System.Memory 4.6.2`
- `System.Threading.Tasks.Extensions 4.6.2`

### Legacy-ссылки
- **Infragistics2 v9.1** (Shared / Win / Win.Misc) — должны быть в GAC или рядом с проектом для компиляции

### Настройки проекта
- `<AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>`
- Binding redirects для System.Runtime.CompilerServices.Unsafe, System.Buffers и др. — в `App.config`

---

## Сборка и запуск

```bash
# Сборка (требуется .NET Framework 4.7 targeting pack / Visual Studio)
dotnet build MvvmWinFormsApp.sln

# Запуск
dotnet run --project MvvmWinFormsApp
```

Тестов в проекте нет.

---

## Архитектура и зависимости

```
Program.cs (точка входа)
  ├── DependencyConfiguration/CompositionRoot  (Autofac-контейнер)
  ├── Factories/WindowServiceFactory           (создание окон)
  ├── ViewModels/MainViewModel
  └── Views/MainView                           (MDI-родитель)

Зависимости идут "вниз":
  Views → ViewModels (data binding)
  ViewModels → Services (через интерфейсы), Models, Common
  ViewModels → Factories (через IWindowServiceFactory)
  Factories → Views + ViewModels + Autofac scope
  Models → Common (NotifyPropertyChangedBase)
  CompositionRoot → Services (регистрация реализаций)
```

### Слои

1. **Program.cs** — точка входа. Строит контейнер, открывает lifetime scope, создаёт фабрику, ViewModel и MainView, запускает `Application.Run`.
2. **Views** — формы WinForms (`MainView`, `PersonDirectoryView`). Знают только о своих ViewModel, ничего не знают про Autofac.
3. **ViewModels** — презентационная логика. Наследуются от `NotifyPropertyChangedBase`, выставляют `RelayCommand`. Не обращаются к UI-типам напрямую.
4. **Models** — доменные данные (`PersonModel`) с уведомлениями об изменениях.
5. **Services** — интерфейсы и реализации: `IWindowService` (поведение окна), `IMessageBoxService` (сообщения), `IDataSourceService` (данные).
6. **Factories** — `WindowServiceFactory` — единственное место (кроме `Program`), знающее про Autofac.
7. **Common** — `NotifyPropertyChangedBase`, `RelayCommand`, `Constants`.

---

## Внедрение зависимостей (Autofac)

### Регистрации (`CompositionRoot.BuildContainer()`)

| Сервис | Регистрация | Lifetime |
|---|---|---|
| `MessageBoxService` | named `Constants.MessageBoxServiceName` → `IMessageBoxService` | Singleton |
| `DataSourceService` | named `Constants.DataSourceServiceName` → `IDataSourceService` | Singleton |

### Поток запуска

```
Program.Main
  → CompositionRoot.BuildContainer()
  → container.BeginLifetimeScope()        (scope живёт всё время работы приложения)
  → new WindowServiceFactory(scope)
  → new MainViewModel(factory)
  → new MainView(viewModel)
  → Application.Run(mainView)
```

### Создание нового окна

`WindowServiceFactory.CreatePersonDirectoryWindow()`:
1. `ResolveNamed<IMessageBoxService>(...)` и `ResolveNamed<IDataSourceService>(...)` из scope
2. `new PersonDirectoryViewModel(messageBoxService, dataSourceService)`
3. `new PersonDirectoryView(viewModel)` — View реализует `IWindowService`

**Соглашение:** для добавления нового окна — добавить метод в `IWindowServiceFactory` / `WindowServiceFactory`, создать View (наследник `WindowService`) и ViewModel, при необходимости зарегистрировать новые сервисы в `CompositionRoot`.

---

## Стиль кодирования и практики

- **Constructor injection** — все зависимости передаются через конструктор с проверкой `?? throw new ArgumentNullException(nameof(...))`
- **MVVM-биндинги** — модели и ViewModel наследуются от `NotifyPropertyChangedBase`; изменения через `SetProperty(ref field, value, nameof(Property))`
- **Команды** — `RelayCommand` (ICommand) с `CanExecute` и `RaiseCanExecuteChanged()`; при смене связанных свойств вызывается `RaiseCanExecuteChanged()`
- **Named-регистрации** — имена сервисов вынесены в константы `Constants` (`MessageBoxServiceName`, `DataSourceServiceName`, `PersonDirectoryViewName`)
- **Абстракция UI** — ViewModel не вызывает `MessageBox`/`Form` напрямую, только через `IMessageBoxService` / `IWindowService`
- **MDI** — дочерние окна привязываются к родителю через `IWindowService.SetMdiParent(owner)`
- **Внимание:** файл `Common/RelayCommand.cs` лежит в папке `Common`, но его namespace — **`MvvmWinFormsApp.Commands`** (не `MvvmWinFormsApp.Common`)
- Комментарии в коде — на русском языке (XML-doc и пояснения)

---

## Ключевые домены

### Person (Персона)
- `Id` (int) — идентификатор
- `Name` (string) — имя (используется в `ToString()`)
- `Age` (int) — возраст

### Окна

#### MainView (MDI-родитель)
- Кнопка, привязанная к `MainViewModel.ShowPersonDirectoryCommand`, открывает справочник персон как MDI-потомка

#### PersonDirectoryView (MDI-потомок)
- Список персон (привязан к `PersonDirectoryViewModel.Persons`)
- Выбор персоны (`Person`)
- Команда `ShowPersonCommand` — показывает `{Id} {Name} {Age}` через `IMessageBoxService` (доступна только при выбранной персоне)

---

## TODO / Известные места

- `DataSourceService.GetPersons()` возвращает захардкоженный список из 3 персон — при переходе к реальным данным заменить реализацию `IDataSourceService`
- `Constants.PersonDirectoryViewName` объявлен, но пока нигде не используется
- `Autofac.Extras.CommonServiceLocator` подключён как пакет, но в коде не задействован
- Ссылки на Infragistics v9.1 в csproj — устаревшие legacy-зависимости
- Тестовый проект отсутствует
