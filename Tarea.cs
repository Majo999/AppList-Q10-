using System;

namespace ToDoListApp.Models {
    // Clase que representa una Tarea
    public class Tarea {
        // Propiedades de la Tarea
        public string Descripcion { get; set; } // Descripción de la tarea
        public DateTime? FechaLimite { get; set; } // Fecha límite de la tarea (opcional)
        public bool EstaCompletada { get; private set; } // Indica si la tarea está completada

        // Constructor de la clase Tarea
        public Tarea(string descripcion, DateTime? fechaLimite = null) {
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            EstaCompletada = false; // Por defecto, la tarea no está completada
        }

        // Método para marcar la tarea como completada
        public void MarcarComoCompletada() {
            EstaCompletada = true;
        }

        // Método que devuelve la información de la tarea en forma de cadena de texto
        public override string ToString() {
            // Si la fecha límite existe, formatearla, de lo contrario indicar que no hay límite
            string fechaLimiteStr = FechaLimite.HasValue ? FechaLimite.Value.ToString("yyyy-MM-dd") : "Sin límite";
            // Estado de la tarea
            string estado = EstaCompletada ? "Completada" : "Pendiente";
            return $"Tarea: {Descripcion}, Fecha Límite: {fechaLimiteStr}, Estado: {estado}";
        }
    }
}
