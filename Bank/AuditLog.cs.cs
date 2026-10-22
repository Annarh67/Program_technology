
namespace Bank;

/// <summary>
/// Хранит журнал аудита банковских операций.
/// </summary>
public static class AuditLog
{
    private static readonly List<string> _entries = new List<string>();

    /// <summary>
    /// Добавляет операцию в журнал аудита.
    /// </summary>
    /// <param name="accountNumber">Номер счёта.</param>
    /// <param name="operationType">Тип операции.</param>
    /// <param name="amount">Сумма операции.</param>
    /// <param name="date">Дата операции.</param>
    public static void Log(
        string accountNumber,
        string operationType,
        decimal amount,
        DateTime date)
    {
        string entry = $"{accountNumber}\t{operationType}\t{amount}\t{date}";
        _entries.Add(entry);
    }

    /// <summary>
    /// Возвращает все записи журнала аудита.
    /// </summary>
    /// <returns>Строка с записями журнала.</returns>
    public static string GetLog()
    {
        return "Account\tType\tAmount\tDate\n"
            + string.Join("\n", _entries);
    }
}
