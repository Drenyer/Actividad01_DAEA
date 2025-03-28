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
}