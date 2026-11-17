using Lab_11;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №11 (варіант 8, структурні шаблони) ===");
    Console.WriteLine("1 - Adapter: телематика нового постачальника");
    Console.WriteLine("2 - Facade: початок поїздки");
    Console.WriteLine("3 - Proxy: керування авто через віддалений сервер");
    Console.WriteLine("4 - Decorator: додаткові опції поїздки");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1": DemoRunner.RunAdapter(); break;
        case "2": DemoRunner.RunFacade(); break;
        case "3": DemoRunner.RunProxy(); break;
        case "4": DemoRunner.RunDecorator(); break;
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
    }
}