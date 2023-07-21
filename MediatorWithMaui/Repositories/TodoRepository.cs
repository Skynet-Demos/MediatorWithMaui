using MediatorWithMaui.Models;
using SQLite;

namespace MediatorWithMaui.Repositories;

public class TodoRepository
{
    private string dbPath;
    private SQLiteAsyncConnection con;

    public TodoRepository(string dbPath)
    {
        this.dbPath = dbPath;
    }

    // create table(s) if not created earlier
    private async Task Init()
    {
        if (con != null)
            return;

        con = new SQLiteAsyncConnection(dbPath);
        await con.CreateTableAsync<Todo>();
    }

    public async Task AddTodoAsync(Todo todo)
    {
        await Init();
        try
        {
            await con.InsertAsync(todo);
        }
        catch (Exception ex)
        {
            await Logger.WriteLogAsync($"Exception: {ex.Message}");
        }
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        await Init();
        try
        {
            return await con.Table<Todo>().ToListAsync();
        }
        catch (Exception ex)
        {
            await Logger.WriteLogAsync($"Exception: {ex.Message}");
            return null;
        }
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        await Init();
        try
        {
            await con.UpdateAsync(todo);
        }
        catch (Exception ex)
        {
            await Logger.WriteLogAsync($"Exception: {ex.Message}");
        }
    }

    public async Task DeleteTodoAsync(Todo todo)
    {
        await Init();
        try
        {
            await con.DeleteAsync(todo);
        }
        catch (Exception ex)
        {
            await Logger.WriteLogAsync($"Exception: {ex.Message}");
        }
    }
}
