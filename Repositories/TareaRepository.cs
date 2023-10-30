using TareaApi.Interfaces;
using TareaApi.Models;

public class TareaRepository: ITareaRepository 
{
    private readonly TareaContext _context;

    public TareaRepository(TareaContext context) 
    {
        _context = context;
    }

    public void Add(Tarea task)
    {
        _context.Tareas.Add(task);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _context.Tareas.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.Tareas.Remove(product);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Tarea> GetAll()
    {
        return _context.Tareas.ToList();
    }

    public Tarea GetById(int id) 
    {
        return _context.Tareas.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Tarea task)
    {
        _context.Tareas.Update(task);
        _context.SaveChanges();
    }
}