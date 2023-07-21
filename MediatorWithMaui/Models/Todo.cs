using SQLite;

namespace MediatorWithMaui.Models;

public class Todo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public DateTime? Duedate { get; set; }

    public string Status { get; set; }
}
