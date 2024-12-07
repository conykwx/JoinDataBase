using System;
using Microsoft.Data.SqlClient;

public class DatabaseConnection
{
    // Строка підключення до бази даних
    private string connectionString = "Server=DESKTOP-9K56BQI\\SQLEXPRESS;Database=Stationery;Trusted_Connection=True;TrustServerCertificate=True;";

    // Метод для підключення до бази даних
    public void Connect()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Підключення до бази даних успішне.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка підключення: {ex.Message}");
        }
    }

    // Метод для відключення від бази даних
    public void Disconnect()
    {
        // Підключення автоматично закривається при завершенні using-блоку
        Console.WriteLine("Підключення закрито.");
    }
}

public class DataDisplay
{
    // Строка підключення до бази даних
    private string connectionString = "Server=DESKTOP-9K56BQI\\SQLEXPRESS;Database=Stationery;Trusted_Connection=True;TrustServerCertificate=True;";

    // Метод для виведення всіх канцтоварів
    public void ShowAllStationery()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Stationery";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Назва: {reader["Name"]}, Тип: {reader["Type"]}, Кількість: {reader["Quantity"]}, Собівартість: {reader["Cost"]}");
            }
        }
    }

    // Метод для виведення канцтоварів з максимальною кількістю
    public void ShowStationeryWithMaxQuantity()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Stationery WHERE Quantity = (SELECT MAX(Quantity) FROM Stationery)";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Назва: {reader["Name"]}, Тип: {reader["Type"]}, Кількість: {reader["Quantity"]}");
            }
        }
    }

    // Метод для виведення канцтоварів з мінімальною собівартістю
    public void ShowStationeryWithMinCost()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Stationery WHERE Cost = (SELECT MIN(Cost) FROM Stationery)";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Назва: {reader["Name"]}, Тип: {reader["Type"]}, Собівартість: {reader["Cost"]}");
            }
        }
    }
}

public class FilterData
{
    // Строка підключення до бази даних
    private string connectionString = "Server=DESKTOP-9K56BQI\\SQLEXPRESS;Database=Stationery;Trusted_Connection=True;TrustServerCertificate=True;";

    // Метод для виведення канцтоварів за заданим типом
    public void ShowStationeryByType(string type)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Stationery WHERE Type = @Type";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Type", type);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Назва: {reader["Name"]}, Кількість: {reader["Quantity"]}, Собівартість: {reader["Cost"]}");
            }
        }
    }

    // Метод для виведення продажів за певним менеджером
    public void ShowSalesByManager(int managerId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Sales WHERE ManagerID = @ManagerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ManagerID", managerId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Менеджер: {reader["ManagerID"]}, Фірма: {reader["BuyerID"]}, Кількість проданої продукції: {reader["QuantitySold"]}");
            }
        }
    }
}
