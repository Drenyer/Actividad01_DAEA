using System.Text.Json.Serialization;

namespace ToDoApi.Models
{
    public enum EstadoTarea
    {
        Pendiente,
        Completado
    }

    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public EstadoTarea Estado { get; set; }
    }
}   

