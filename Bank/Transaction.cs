namespace Bank;

// record - Состояние объектов этого класса нельзя изменить

/// <summary>
/// Представляет банковскую транзакцию с суммой, датой и комментарием.
/// </summary>
/// <param name="Amount">Сумма банковской операции.</param>
/// <param name="Date">Дата выполнения операции.</param>
/// <param name="Note">Комментарий к банковской операции.</param>
public record Transaction(decimal Amount, DateTime Date, string Note);

//internal record Transaction
//{
//    public decimal Amount { get; }
//    public DateTime Date { get; }
//    public string Note { get; }
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    {
//        this.Amount = Amount;
//        this.Note = Note;
//        this.Date = Date;
//    }
//}
