using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    //Lista estática de tareas 
    private static List<Tarea> tareas = new List<Tarea>
    {
        new Tarea { Id = 1, Titulo = "TAREA 1", Estado = EstadoTarea.Pendiente },
        new Tarea { Id = 2, Titulo = "TAREA 2", Estado = EstadoTarea.Completado }
    };

    //Obtener datos
    [HttpGet]
    public IActionResult ObtenerTareas()
    {
        return Ok(new {mensaje = "Obteniendo todas las tareas.",tareas});
    }
    
    //Obtner datos por Id
    [HttpGet("{id}")]
    public IActionResult ObtenerTareasId(int id)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id); 

        if (tarea == null)
        {
            return NotFound(new { mensaje = $"No se encontró la tarea con ID {id}" });
        }

        return Ok(new { mensaje = $"Tarea con el id: {id} encontrado.",tarea});
    }
    
    [HttpPost]
    public IActionResult CrearTarea([FromBody] Tarea nuevaTarea)
    {
        if (nuevaTarea == null || string.IsNullOrWhiteSpace(nuevaTarea.Titulo))
        {
            return BadRequest(new { mensaje = "El título de la tarea es obligatorio." });
        }

        nuevaTarea.Id = tareas.Count + 1; 
        tareas.Add(nuevaTarea);

        return CreatedAtAction(nameof(ObtenerTareasId), new { id = nuevaTarea.Id }, nuevaTarea);
    }
    
    [HttpPut("{id}")]
    public IActionResult ActualizarTarea(int id, [FromBody] Tarea tareaActualizada)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id);

        if (tarea == null)
        {
            return NotFound(new { mensaje = $"No se encontró la tarea con ID {id}" });
        }

        if (tareaActualizada == null || string.IsNullOrWhiteSpace(tareaActualizada.Titulo))
        {
            return BadRequest(new { mensaje = "El título de la tarea es obligatorio." });
        }

        tarea.Titulo = tareaActualizada.Titulo;
        tarea.Estado = tareaActualizada.Estado;

        return Ok(new { mensaje = $"Tarea con ID {id} actualizada correctamente.", tarea });
    }
    
    [HttpDelete("{id}")]
    public IActionResult EliminarTarea(int id)
    {
        var tarea = tareas.FirstOrDefault(t => t.Id == id);

        if (tarea == null)
        {
            return NotFound(new { mensaje = $"No se encontró la tarea con ID {id}" });
        }

        tareas.Remove(tarea);

        return Ok(new { mensaje = $"Tarea con ID {id} eliminada correctamente." });
    }
}