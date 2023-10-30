using TareaApi.Models;

namespace TareaApi.Interfaces;

public interface ITareaRepository
{
    IEnumerable<Tarea> GetAll();
    Tarea GetById(int id);
    void Add(Tarea task);
    void Update(Tarea task);
    void Delete(int id);
}
