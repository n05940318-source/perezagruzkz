using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Overloading25;

internal static class Program
{
    private static void Section(int number, string title) => Console.WriteLine($"\n{number}. {title}");

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Section(1, "Автомобиль");
        Car.ShowInfo("Toyota");
        Car.ShowInfo("Toyota", 2022);
        Car.ShowInfo("Toyota", 2022, 12_500_000m);

        Section(2, "Студент");
        Console.WriteLine(Student.CalculateGrade(85));
        Console.WriteLine(Student.CalculateGrade(85, 95));
        Console.WriteLine(Student.CalculateGrade(75, 85, 95));

        Section(3, "Скидки");
        Console.WriteLine(Discount.CalculateDiscount(10_000m, 15));
        Console.WriteLine(Discount.CalculateDiscount(10_000m, 1_500m));

        Section(4, "Доставка");
        Console.WriteLine(Delivery.CalculateDelivery(1_000m));
        Console.WriteLine(Delivery.CalculateDelivery(1_000m, true));
        Console.WriteLine(Delivery.CalculateDelivery(1_000m, 3.5));

        Section(5, "Книга");
        Book.DisplayBook("Война и мир");
        Book.DisplayBook("Война и мир", "Лев Толстой");
        Book.DisplayBook("Война и мир", "Лев Толстой", 1869);

        Section(6, "Игровые очки");
        Console.WriteLine(Score.AddScore(100));
        Console.WriteLine(Score.AddScore(100, 25));
        Console.WriteLine(Score.AddScore(100, 25, 2));

        Section(7, "Файлы");
        string folder = Path.Combine(Environment.CurrentDirectory, "saved_files");
        Directory.CreateDirectory(folder);
        try
        {
            Files.SaveFile(Path.Combine(folder, "text.txt"), "Пример текста");
            Files.SaveFile(Path.Combine(folder, "lines.txt"), new[] { "Первая строка", "Вторая строка" });
            Files.SaveFile(Path.Combine(folder, "utf8.txt"), "Текст в UTF-8", Encoding.UTF8);
            Console.WriteLine($"Созданы 3 файла в {folder}");
        }
        catch (IOException ex) { Console.WriteLine($"Ошибка сохранения: {ex.Message}"); }
        catch (UnauthorizedAccessException ex) { Console.WriteLine($"Нет доступа к файлу: {ex.Message}"); }

        Section(8, "Геометрия");
        Console.WriteLine(Geometry.CalculateVolume(3.0));
        Console.WriteLine(Geometry.CalculateVolume(2.0, 3.0, 4.0));
        Console.WriteLine(Geometry.CalculateVolume(2.0, 5.0));

        Section(9, "Такси");
        Console.WriteLine(Taxi.CalculateFare(10.0));
        Console.WriteLine(Taxi.CalculateFare(10.0, 12));
        Console.WriteLine(Taxi.CalculateFare(10.0, CarClass.Comfort));

        Section(10, "Библиотека");
        var catalog = new[]
        {
            new LibraryBook("Абай жолы", "Мұхтар Әуезов"),
            new LibraryBook("Война и мир", "Лев Толстой"),
            new LibraryBook("Анна Каренина", "Лев Толстой")
        };
        PrintBooks(LibrarySearch.SearchBook(catalog, "Абай жолы"));
        PrintBooks(LibrarySearch.SearchBook(catalog, new AuthorQuery("Лев Толстой")));
        PrintBooks(LibrarySearch.SearchBook(catalog, "Анна Каренина", "Лев Толстой"));

        Section(11, "Массивы");
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { 3, 1, 2 })));
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { 3.3, 1.1, 2.2 })));
        Console.WriteLine(string.Join(", ", ArrayTools.Sort(new[] { "груша", "яблоко", "банан" })));

        Section(12, "Статистика массива");
        Console.WriteLine(ArrayStats.Analyze(new[] { 2.0, 4.0, 6.0 }));
        ArrayStats.Analyze(new[] { 1.0, 3.0, 8.0 }, out double min, out double max, out double average);
        Console.WriteLine($"min={min}, max={max}, среднее={average}");
        Console.WriteLine(ArrayStats.Analyze(new[] { 5, 10, 15 }));

        Section(13, "Пароль");
        Console.WriteLine(Password.ValidatePassword("Abcdefgh"));
        Console.WriteLine(Password.ValidatePassword("Abcdefg1", true));
        Console.WriteLine(Password.ValidatePassword("Abcdef1!", true, true));

        Section(14, "Валюта (учебные курсы)");
        Console.WriteLine(Currency.ConvertCurrency(100m));
        Console.WriteLine(Currency.ConvertCurrency(100m, 500m));
        Console.WriteLine(Currency.ConvertCurrency(100m, 500m, 2m));

        Section(15, "Дата и время");
        Console.WriteLine(DateTools.FormatDate(new DateTime(2026, 10, 27)));
        Console.WriteLine(DateTools.FormatDate("2026-10-27"));
        Console.WriteLine(DateTools.FormatDate(new DateTime(2026, 10, 27, 9, 55, 0), true));

        Section(16, "Уведомления");
        Notifications.SendNotification("Встреча в 10:00");
        Notifications.SendNotification("Напоминание", "Встреча в 10:00");
        Notifications.SendNotification("Преподаватель", "Напоминание", "Встреча в 10:00");

        Section(17, "Сотрудники");
        Console.WriteLine(Employees.CreateEmployee("Алия"));
        Console.WriteLine(Employees.CreateEmployee("Болат", "Разработчик"));
        Console.WriteLine(Employees.CreateEmployee("Дана", "Аналитик", 350_000m));

        Section(18, "Склад");
        var stock = new StockItem("Ноутбук", 10);
        Console.WriteLine(Stock.UpdateStock(stock, 5));
        Console.WriteLine(Stock.UpdateStock(stock, 3, true));
        Console.WriteLine(Stock.UpdateStock(stock, 20, StockMode.Set));

        Section(19, "Математика");
        Console.WriteLine(MathLibrary.Calculate(2, 3));
        Console.WriteLine(MathLibrary.Calculate(7.0, 2.5));
        Console.WriteLine(MathLibrary.Calculate(2m, 3m));
        Console.WriteLine(MathLibrary.Calculate(10m, 2m, '/'));

        Section(20, "Авторизация");
        Console.WriteLine(Auth.Login("student", "Pass123!"));
        Console.WriteLine(Auth.Login(new EmailAddress("student@example.com"), "Pass123!"));
        Console.WriteLine(Auth.Login("student", "Pass123!", "123456"));

        Section(21, "Изменение размера изображения (пиксели в памяти)");
        var image = ImageTools.CreateCheckerboard(800, 600);
        Console.WriteLine(ImageTools.ResizeImage(image, 400, 300));
        Console.WriteLine(ImageTools.ResizeImage(image, 0.5));
        Console.WriteLine(ImageTools.ResizeImage(image, 300, 300, true));

        Section(22, "Топливо");
        Console.WriteLine(Fuel.CalculateFuelCost(150.0, 8.0));
        Console.WriteLine(Fuel.CalculateFuelCost(150.0, 8.0, 250m));

        Section(23, "Электроника");
        Console.WriteLine(Electronics.CalculateFinalPrice(100_000m, 10));
        Console.WriteLine(Electronics.CalculateFinalPrice(100_000m, 10, 12));
        Console.WriteLine(Electronics.CalculateFinalPrice(100_000m, 10, 12, 2_000m));

        Section(24, "Оценивание");
        Console.WriteLine(Evaluation.EvaluateStudent(88));
        Console.WriteLine(Evaluation.EvaluateStudent(88, 92));
        Console.WriteLine(Evaluation.EvaluateStudent(new[] { 80, 90, 100 }));

        Section(25, "Универсальный помощник");
        var helper = new Helper();
        Console.WriteLine(helper.Calculate(2, 3));
        Console.WriteLine(helper.Calculate(9.0, 2.0, '/'));
        Console.WriteLine(helper.Calculate(2m, 3m, 4m));
        Console.WriteLine(helper.Format(1234.56));
        Console.WriteLine(helper.Format("  пример текста  "));
        Console.WriteLine(helper.Format(new DateTime(2026, 10, 27)));
        Console.WriteLine(helper.Find(new[] { 4, 7, 9 }, 7));
        Console.WriteLine(helper.Find(new[] { "а", "б", "в" }, "б"));
        Console.WriteLine(helper.Find("Привет, мир", "мир"));
        helper.Display(42);
        helper.Display("Готово");
        helper.Display(new Employee("Иван", "Инженер", 300_000m));
    }

    private static void PrintBooks(IEnumerable<LibraryBook> books) =>
        Console.WriteLine(string.Join("; ", books.Select(b => $"{b.Title} — {b.Author}")));
}

// 1. Отличаются количество и типы параметров.
internal static class Car
{
    public static void ShowInfo(string brand) => Console.WriteLine($"Марка: {brand}");
    public static void ShowInfo(string brand, int year) => Console.WriteLine($"Марка: {brand}, год: {year}");
    public static void ShowInfo(string brand, int year, decimal price) => Console.WriteLine($"Марка: {brand}, год: {year}, цена: {price:N0} тг");
}

// 2. Шкала: 90–100 = 5, 75–89 = 4, 60–74 = 3, иначе 2.
internal static class Student
{
    public static int CalculateGrade(int score) => ToGrade(score);
    public static int CalculateGrade(int a, int b) => ToGrade((a + b) / 2.0);
    public static int CalculateGrade(int a, int b, int c) => ToGrade((a + b + c) / 3.0);
    private static int ToGrade(double score)
    {
        if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
        return score >= 90 ? 5 : score >= 75 ? 4 : score >= 60 ? 3 : 2;
    }
}

// 3. Возвращается итоговая цена после скидки.
internal static class Discount
{
    public static decimal CalculateDiscount(decimal price, int percent)
    {
        Checks.NonNegative(price); Checks.Percent(percent);
        return price * (100 - percent) / 100;
    }
    public static decimal CalculateDiscount(decimal price, decimal fixedAmount)
    {
        Checks.NonNegative(price); Checks.NonNegative(fixedAmount);
        if (fixedAmount > price) throw new ArgumentOutOfRangeException(nameof(fixedAmount));
        return price - fixedAmount;
    }
}

// 4. Базовый тариф, срочность +50%, вес свыше 1 кг: +100 тг/кг.
internal static class Delivery
{
    public static decimal CalculateDelivery(decimal basePrice) { Checks.NonNegative(basePrice); return basePrice; }
    public static decimal CalculateDelivery(decimal basePrice, bool urgent) => CalculateDelivery(basePrice) * (urgent ? 1.5m : 1m);
    public static decimal CalculateDelivery(decimal basePrice, double weightKg)
    {
        Checks.Positive(weightKg);
        return CalculateDelivery(basePrice) + (decimal)Math.Max(0, weightKg - 1) * 100m;
    }
}

// 5.
internal static class Book
{
    public static void DisplayBook(string title) => Console.WriteLine(title);
    public static void DisplayBook(string title, string author) => Console.WriteLine($"{title} — {author}");
    public static void DisplayBook(string title, string author, int year) => Console.WriteLine($"{title} — {author}, {year}");
}

// 6. По умолчанию начисляется 10 очков; бонус можно умножить.
internal static class Score
{
    public static int AddScore(int current) => checked(current + 10);
    public static int AddScore(int current, int bonus) => checked(current + bonus);
    public static int AddScore(int current, int bonus, int multiplier)
    {
        if (multiplier < 0) throw new ArgumentOutOfRangeException(nameof(multiplier));
        return checked(current + bonus * multiplier);
    }
}

// 7. Файлы создаются в текущей папке проекта/saved_files.
internal static class Files
{
    public static void SaveFile(string path, string text) => File.WriteAllText(path, text);
    public static void SaveFile(string path, string[] lines) => File.WriteAllLines(path, lines);
    public static void SaveFile(string path, string text, Encoding encoding) => File.WriteAllText(path, text, encoding);
}

// 8. Радиус и высота цилиндра — два параметра.
internal static class Geometry
{
    public static double CalculateVolume(double side) { Checks.Positive(side); return side * side * side; }
    public static double CalculateVolume(double length, double width, double height)
    { Checks.Positive(length); Checks.Positive(width); Checks.Positive(height); return length * width * height; }
    public static double CalculateVolume(double radius, double height)
    { Checks.Positive(radius); Checks.Positive(height); return Math.PI * radius * radius * height; }
}

internal enum CarClass { Economy, Comfort, Business }
// 9. Учебные тарифы: посадка 500, километр 100, ожидание 20 тг/мин.
internal static class Taxi
{
    public static decimal CalculateFare(double distanceKm)
    { Checks.NonNegative(distanceKm); return 500m + (decimal)distanceKm * 100m; }
    public static decimal CalculateFare(double distanceKm, int waitingMinutes)
    { if (waitingMinutes < 0) throw new ArgumentOutOfRangeException(nameof(waitingMinutes)); return CalculateFare(distanceKm) + waitingMinutes * 20m; }
    public static decimal CalculateFare(double distanceKm, CarClass carClass) =>
        CalculateFare(distanceKm) * (carClass switch { CarClass.Economy => 1m, CarClass.Comfort => 1.5m, CarClass.Business => 2m, _ => throw new ArgumentOutOfRangeException(nameof(carClass)) });
}

internal record LibraryBook(string Title, string Author);
internal record AuthorQuery(string Value);
// 10. Отдельный тип AuthorQuery нужен, потому что SearchBook(catalog, string)
// не может одновременно обозначать и название, и автора.
internal static class LibrarySearch
{
    public static LibraryBook[] SearchBook(LibraryBook[] catalog, string title) =>
        catalog.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToArray();
    public static LibraryBook[] SearchBook(LibraryBook[] catalog, AuthorQuery author) =>
        catalog.Where(b => b.Author.Contains(author.Value, StringComparison.OrdinalIgnoreCase)).ToArray();
    public static LibraryBook[] SearchBook(LibraryBook[] catalog, string title, string author) =>
        catalog.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToArray();
}

// 11. Копируем массив, чтобы исходный массив не менялся.
internal static class ArrayTools
{
    public static int[] Sort(int[] items) { int[] copy = (int[])items.Clone(); Array.Sort(copy); return copy; }
    public static double[] Sort(double[] items) { double[] copy = (double[])items.Clone(); Array.Sort(copy); return copy; }
    public static string[] Sort(string[] items) { string[] copy = (string[])items.Clone(); Array.Sort(copy, StringComparer.CurrentCulture); return copy; }
}

// 12. Три варианта параметров: double[], double[] + out, int[].
internal static class ArrayStats
{
    public static (double Min, double Max, double Average) Analyze(double[] values)
    { Checks.NotEmpty(values); return (values.Min(), values.Max(), values.Average()); }
    public static void Analyze(double[] values, out double min, out double max, out double average)
    { var result = Analyze(values); min = result.Min; max = result.Max; average = result.Average; }
    public static (int Min, int Max, double Average) Analyze(int[] values)
    { Checks.NotEmpty(values); return (values.Min(), values.Max(), values.Average()); }
}

// 13. Минимальная длина 8, необязательные требования включаются параметрами.
internal static class Password
{
    public static bool ValidatePassword(string value) => !string.IsNullOrEmpty(value) && value.Length >= 8;
    public static bool ValidatePassword(string value, bool requireDigit) =>
        ValidatePassword(value) && (!requireDigit || value.Any(char.IsDigit));
    public static bool ValidatePassword(string value, bool requireDigit, bool requireSpecial) =>
        ValidatePassword(value, requireDigit) && (!requireSpecial || value.Any(c => !char.IsLetterOrDigit(c)));
}

// 14. Пример, а не актуальный рыночный курс: 1 единица = 480 тг.
internal static class Currency
{
    public static decimal ConvertCurrency(decimal amount) => ConvertCurrency(amount, 480m);
    public static decimal ConvertCurrency(decimal amount, decimal rate)
    { Checks.NonNegative(amount); Checks.Positive(rate); return amount * rate; }
    public static decimal ConvertCurrency(decimal amount, decimal rate, decimal commissionPercent)
    { Checks.Percent(commissionPercent); return ConvertCurrency(amount, rate) * (1 - commissionPercent / 100); }
}

// 15. Строку принимаем только в формате ISO yyyy-MM-dd.
internal static class DateTools
{
    public static string FormatDate(DateTime date) => date.ToString("dd.MM.yyyy");
    public static string FormatDate(string isoDate) =>
        DateTime.ParseExact(isoDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dd.MM.yyyy");
    public static string FormatDate(DateTime date, bool includeTime) => date.ToString(includeTime ? "dd.MM.yyyy HH:mm" : "dd.MM.yyyy");
}

// 16. Имитация отправки через консоль.
internal static class Notifications
{
    public static void SendNotification(string message) => Console.WriteLine(message);
    public static void SendNotification(string title, string message) => Console.WriteLine($"{title}: {message}");
    public static void SendNotification(string recipient, string title, string message) => Console.WriteLine($"Кому: {recipient}; {title}: {message}");
}

internal sealed class Employee
{
    public string Name { get; }
    public string Position { get; }
    public decimal Salary { get; }
    public Employee(string name, string position, decimal salary)
    { Name = name; Position = position; Salary = salary; }
    public override string ToString() => $"{Name}, {Position}, {Salary:N0} тг";
}
// 17.
internal static class Employees
{
    public static Employee CreateEmployee(string name) => CreateEmployee(name, "Не указана", 0m);
    public static Employee CreateEmployee(string name, string position) => CreateEmployee(name, position, 0m);
    public static Employee CreateEmployee(string name, string position, decimal salary)
    { if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно", nameof(name)); Checks.NonNegative(salary); return new Employee(name, position, salary); }
}

internal sealed class StockItem
{
    public string Name { get; }
    public int Quantity { get; set; }
    public StockItem(string name, int quantity)
    { if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity)); Name = name; Quantity = quantity; }
    public override string ToString() => $"{Name}: {Quantity} шт.";
}
internal enum StockMode { Set }
// 18. Уменьшение вызывает вариант с true; установка — с StockMode.Set.
internal static class Stock
{
    public static StockItem UpdateStock(StockItem item, int increase)
    { if (increase < 0) throw new ArgumentOutOfRangeException(nameof(increase)); item.Quantity = checked(item.Quantity + increase); return item; }
    public static StockItem UpdateStock(StockItem item, int decrease, bool subtract)
    { if (decrease < 0 || (subtract && decrease > item.Quantity)) throw new ArgumentOutOfRangeException(nameof(decrease)); item.Quantity = subtract ? item.Quantity - decrease : checked(item.Quantity + decrease); return item; }
    public static StockItem UpdateStock(StockItem item, int newQuantity, StockMode mode)
    { if (mode != StockMode.Set || newQuantity < 0) throw new ArgumentOutOfRangeException(nameof(newQuantity)); item.Quantity = newQuantity; return item; }
}

// 19. Типы намеренно различаются: int +, double -, decimal *, decimal /.
internal static class MathLibrary
{
    public static int Calculate(int a, int b) => checked(a + b);
    public static double Calculate(double a, double b) => a - b;
    public static decimal Calculate(decimal a, decimal b) => a * b;
    public static decimal Calculate(decimal a, decimal b, char operation)
    { if (operation != '/') throw new ArgumentException("Ожидается /", nameof(operation)); if (b == 0) throw new DivideByZeroException(); return a / b; }
}

internal record EmailAddress(string Value);
// 20. Учебная проверка с фиксированными данными; сетевой авторизации нет.
internal static class Auth
{
    private const string Secret = "Pass123!";
    public static bool Login(string username, string password) => username == "student" && password == Secret;
    public static bool Login(EmailAddress email, string password) => email.Value.Equals("student@example.com", StringComparison.OrdinalIgnoreCase) && password == Secret;
    public static bool Login(string username, string password, string code) => Login(username, password) && code == "123456";
}

internal sealed class PixelImage
{
    public int[,] Pixels { get; }
    public int Width => Pixels.GetLength(1);
    public int Height => Pixels.GetLength(0);
    public PixelImage(int width, int height)
    {
        if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException(nameof(width));
        Pixels = new int[height, width];
    }
    public override string ToString() => $"Изображение {Width} × {Height} пикселей";
}
// 21. Реальное изменение массива пикселей методом ближайшего соседа.
internal static class ImageTools
{
    public static PixelImage CreateCheckerboard(int width, int height)
    {
        var image = new PixelImage(width, height);
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++) image.Pixels[y, x] = ((x / 50 + y / 50) % 2 == 0) ? unchecked((int)0xFFFFFFFF) : unchecked((int)0xFF2020FF);
        return image;
    }
    public static PixelImage ResizeImage(PixelImage source, int width, int height)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        var result = new PixelImage(width, height);
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                result.Pixels[y, x] = source.Pixels[(int)((long)y * source.Height / height), (int)((long)x * source.Width / width)];
        return result;
    }
    public static PixelImage ResizeImage(PixelImage source, double scale)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        Checks.Positive(scale);
        return ResizeImage(source, Math.Max(1, checked((int)Math.Round(source.Width * scale))), Math.Max(1, checked((int)Math.Round(source.Height * scale))));
    }
    public static PixelImage ResizeImage(PixelImage source, int maxWidth, int maxHeight, bool preserveAspect)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (maxWidth <= 0 || maxHeight <= 0) throw new ArgumentOutOfRangeException(nameof(maxWidth));
        if (!preserveAspect) return ResizeImage(source, maxWidth, maxHeight);
        double scale = Math.Min((double)maxWidth / source.Width, (double)maxHeight / source.Height);
        return ResizeImage(source, scale);
    }
}

// 22. Расход — литры на 100 км; цена по умолчанию 250 тг/л.
internal static class Fuel
{
    public static decimal CalculateFuelCost(double distanceKm, double litersPer100Km) => CalculateFuelCost(distanceKm, litersPer100Km, 250m);
    public static decimal CalculateFuelCost(double distanceKm, double litersPer100Km, decimal pricePerLiter)
    { Checks.NonNegative(distanceKm); Checks.NonNegative(litersPer100Km); Checks.NonNegative(pricePerLiter); return (decimal)(distanceKm * litersPer100Km / 100) * pricePerLiter; }
}

// 23. Налог начисляется после скидки, затем прибавляется доставка.
internal static class Electronics
{
    public static decimal CalculateFinalPrice(decimal price, int discountPercent) => Discount.CalculateDiscount(price, discountPercent);
    public static decimal CalculateFinalPrice(decimal price, int discountPercent, int taxPercent)
    { Checks.Percent(taxPercent); return CalculateFinalPrice(price, discountPercent) * (100 + taxPercent) / 100; }
    public static decimal CalculateFinalPrice(decimal price, int discountPercent, int taxPercent, decimal deliveryPrice)
    { Checks.NonNegative(deliveryPrice); return CalculateFinalPrice(price, discountPercent, taxPercent) + deliveryPrice; }
}

// 24. Возвращается средний балл (0–100).
internal static class Evaluation
{
    public static double EvaluateStudent(int exam) { Checks.Score(exam); return exam; }
    public static double EvaluateStudent(int exam, int test) { Checks.Score(exam); Checks.Score(test); return (exam + test) / 2.0; }
    public static double EvaluateStudent(int[] exams) { Checks.NotEmpty(exams); foreach (int exam in exams) Checks.Score(exam); return exams.Average(); }
}

// 25. Каждая версия Calculate, Format, Find и Display вызывается в Main.
internal sealed class Helper
{
    public int Calculate(int a, int b) => checked(a + b);
    public double Calculate(double a, double b, char operation) => operation switch
    { '+' => a + b, '-' => a - b, '*' => a * b, '/' when b != 0 => a / b, '/' => throw new DivideByZeroException(), _ => throw new ArgumentException("Неизвестная операция") };
    public decimal Calculate(decimal a, decimal b, decimal c) => a * b * c;

    public string Format(double value) => value.ToString("N2", System.Globalization.CultureInfo.InvariantCulture);
    public string Format(string value) => value.Trim().ToUpperInvariant();
    public string Format(DateTime value) => value.ToString("dd.MM.yyyy");

    public int Find(int[] values, int target) => Array.IndexOf(values, target);
    public int Find(string[] values, string target) => Array.FindIndex(values, v => string.Equals(v, target, StringComparison.OrdinalIgnoreCase));
    public int Find(string text, string term) => text.IndexOf(term, StringComparison.OrdinalIgnoreCase);

    public void Display(int value) => Console.WriteLine($"Число: {value}");
    public void Display(string value) => Console.WriteLine($"Строка: {value}");
    public void Display(Employee value) => Console.WriteLine($"Сотрудник: {value.Name}, {value.Position}, {value.Salary:N0} тг");
}

internal static class Checks
{
    public static void NonNegative(decimal x) { if (x < 0) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void NonNegative(double x) { if (!double.IsFinite(x) || x < 0) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void Positive(decimal x) { if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void Positive(double x) { if (!double.IsFinite(x) || x <= 0) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void Percent(decimal x) { if (x is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void Score(int x) { if (x is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(x)); }
    public static void NotEmpty<T>(T[] values) { if (values is null || values.Length == 0) throw new ArgumentException("Массив не должен быть пустым", nameof(values)); }
}
