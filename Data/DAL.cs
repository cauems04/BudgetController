namespace BudgetController.Data;

public class DAL<T> where T: class
{
    public DAL(Context context)
    {
        _context = context;
    }

    private Context _context;

    public IEnumerable<T> ListAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? SearchFor(Func<T, bool> condition)
    {
        return _context.Set<T>().FirstOrDefault(condition);
    }
    
    public void Create(T item)
    {
        _context.Set<T>().Add(item);
        _context.SaveChanges();
    }

    public void Update(T item)
    {
        _context.Set<T>().Update(item);
        _context.SaveChanges();
    }

    public void Remove(T item)
    {
        _context.Set<T>().Remove(item);
        _context.SaveChanges();
    }
}
