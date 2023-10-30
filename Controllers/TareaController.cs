using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaApi.Interfaces;
using TareaApi.Models;

namespace TareaApi.Controllers
{
    [Route("api/Tarea")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        // GET: api/Tarea
        [HttpGet]
        public IActionResult GetAllTareas() 
        {
            var tareas = _tareaRepository.GetAll();
            return Ok(tareas);
        }

        // GET: api/Tarea/5
        [HttpGet("{id}")]
        public IActionResult GetTareaById(int id) {
            var tarea = _tareaRepository.GetById(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        // PUT: api/Tarea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateTarea(int id, [FromBody] Tarea task)
        {
            var existingTarea = _tareaRepository.GetById(id);
            if (existingTarea == null)
            {
                return NotFound();
            }
            task.Id = id;
            _tareaRepository.Update(task);
            return NoContent();
        }

        // POST: api/Tarea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateTarea([FromBody] Tarea task)
        {
            _tareaRepository.Add(task);
            return CreatedAtAction(nameof(GetTareaById), new {id = task.Id}, task);
        }

        // DELETE: api/Tarea/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTarea(int id)
        {
            var existingTarea = _tareaRepository.GetById(id);
            if (existingTarea == null)
            {
                 return NotFound();
            }
            _tareaRepository.Delete(id);
            return NoContent();
        }

        /*private bool TareaExists(long id)
        {
            return (_context.Tareas?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
