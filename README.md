# Тестирование программного обеспечения
- CalculatorProj.Core - Ядро калькулятора
- CalculatorProj.WPF - UI desktop приложение
- CalculatorProj - Консольное приложение : View & Presenter
- Tests/
    - CalculatorProj.UITests - Программные UI тесты desktop-приложения
    - CalculatorProj.Tests - Тестирование ядра + View & Presenter частей

### Примечания
- Проекты собраны под Windows
- Проекты собраны в Debug версиях
- Присутствует жестко заданный путь, который не должен повлиять на выполнение. Если захотите поменять настройки путей сборки, измените [эту строку](https://github.com/devTryer31/Testing-software/blob/52bd656ac0d9f94b1667f5d36ef9b6f648db1b20/CalculatorProj.UITests/UITestsBase.cs#L10)

## Для запуска UITests тестов
1. Скачайте и установите [WinAppDriver](https://github.com/microsoft/WinAppDriver/releases)
2. Запустите WinAppDriver.exe. Обычно располагается по пути `c:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe`
3. Ошибка при запуске даст вам понять, что нужно сделать =) 
    <details><summary>Подсказка</summary>
        Включите режим разработчика в Windows.
    </details>
4. Запустите тесты CalculatorProj.UITests

## Для запуска SpecFlowTests тестов
- Ознакомьтесь с [данным](https://docs.specflow.org/projects/getting-started/en/latest/GettingStarted/Step1.html) ресурсом.
- Если хотите расширить функционал тестов, то советую заглянуть [сюда](https://docs.specflow.org/projects/specflow/en/latest/ui-automation/Selenium-with-Page-Object-Pattern.html).
