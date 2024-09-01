using System;
using System.Collections.Generic;
using ToDoListApp;
using ToDoListApp.Models;

namespace ToDoListApp {
    class Program {
        // Lista que almacenará las tareas
        private static List<Tarea> tareas = new List<Tarea>();

        static void Main(string[] args) {
            bool salir = false; // Variable para controlar la salida del programa

            while (!salir)
            {
                MostrarMenu(); // Mostrar el menú de opciones
                string opcion = Console.ReadLine(); // Leer la opción seleccionada por el usuario

                switch (opcion)
                {
                    case "1":
                        AgregarTarea(); // Llamar al método para agregar una nueva tarea
                        break;
                    case "2":
                        ListarTareas(); // Llamar al método para listar las tareas
                        break;
                    case "3":
                        MarcarTareaComoCompletada(); // Llamar al método para marcar una tarea como completada
                        break;
                    case "4":
                        EliminarTarea(); // Llamar al método para eliminar una tarea
                        break;
                    case "5":
                        salir = true; // Cambiar la variable para salir del bucle
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intenta de nuevo.");
                        break;
                }
            }
        }

        // Método que muestra el menú de opciones
        static void MostrarMenu() {
            Console.WriteLine("Menú de Lista de Tareas:");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Marcar Tarea como Completada");
            Console.WriteLine("4. Eliminar Tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
        }

        // Método para agregar una nueva tarea
        static void AgregarTarea() {
            Console.Write("Ingresa la descripción de la tarea: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingresa la fecha límite (yyyy-mm-dd) o deja en blanco para no establecer límite: ");
            string entradaFechaLimite = Console.ReadLine();
            DateTime? fechaLimite = null;

            if (!string.IsNullOrEmpty(entradaFechaLimite))
            {
                try
                {
                    fechaLimite = DateTime.Parse(entradaFechaLimite); // Intentar convertir la entrada en una fecha
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de fecha inválido. La tarea se agregará sin fecha límite.");
                }
            }

            tareas.Add(new Tarea(descripcion, fechaLimite)); // Crear y agregar la tarea a la lista
            Console.WriteLine("Tarea agregada exitosamente.\n");
        }

        // Método para listar todas las tareas
        static void ListarTareas() {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas disponibles.\n");
                return;
            }

            Console.WriteLine("Lista de Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
            Console.WriteLine();
        }

        // Método para marcar una tarea como completada
        static void MarcarTareaComoCompletada() {
            ListarTareas(); // Listar las tareas para que el usuario vea las opciones
            Console.Write("Ingresa el número de la tarea que deseas marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int numeroTarea) && numeroTarea > 0 && numeroTarea <= tareas.Count)
            {
                tareas[numeroTarea - 1].MarcarComoCompletada(); // Marcar la tarea seleccionada como completada
                Console.WriteLine("Tarea marcada como completada.\n");
            }
            else
            {
                Console.WriteLine("Número de tarea inválido.\n");
            }
        }

        // Método para eliminar una tarea
        static void EliminarTarea() {
            ListarTareas(); // Listar las tareas para que el usuario vea las opciones
            Console.Write("Ingresa el número de la tarea que deseas eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int numeroTarea) && numeroTarea > 0 && numeroTarea <= tareas.Count)
            {
                tareas.RemoveAt(numeroTarea - 1); // Eliminar la tarea seleccionada
                Console.WriteLine("Tarea eliminada exitosamente.\n");
            }
            else
            {
                Console.WriteLine("Número de tarea inválido.\n");
            }
        }
    }
}
