using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Фірма канцтоварів: Доступ до бази даних");

        // Створення об'єктів для підключення та відображення даних
        DatabaseConnection dbConnection = new DatabaseConnection();
        DataDisplay dataDisplay = new DataDisplay();
        FilterData filterData = new FilterData();

        // Підключення до бази даних
        dbConnection.Connect();

        // Меню вибору дій
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Показати всі канцтовари");
            Console.WriteLine("2. Показати канцтовар з максимальною кількістю");
            Console.WriteLine("3. Показати канцтовар з мінімальною собівартістю");
            Console.WriteLine("4. Показати канцтовар заданого типу");
            Console.WriteLine("5. Показати продажі певного менеджера");
            Console.WriteLine("6. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    dataDisplay.ShowAllStationery();
                    break;

                case "2":
                    dataDisplay.ShowStationeryWithMaxQuantity();
                    break;

                case "3":
                    dataDisplay.ShowStationeryWithMinCost();
                    break;

                case "4":
                    Console.WriteLine("Введіть тип канцтоварів:");
                    string type = Console.ReadLine();
                    filterData.ShowStationeryByType(type);
                    break;

                case "5":
                    Console.WriteLine("Введіть ID менеджера:");
                    int managerId;
                    if (int.TryParse(Console.ReadLine(), out managerId))
                    {
                        filterData.ShowSalesByManager(managerId);
                    }
                    else
                    {
                        Console.WriteLine("Невірний формат ID менеджера.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Вихід...");
                    dbConnection.Disconnect();
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
