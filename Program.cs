//Variables globales de la sesión (caja)
int operacionesCobradas = 0;
double recaudacionTotal = 0.0;
double importeMasCaro = 0.0;
string clienteMasCaro = "";
bool salir = false;

while (salir == false)
{
    Console.WriteLine("");
    Console.WriteLine($"===================================");
    Console.WriteLine($"   ROAD RESCUE - MENÚ PRINCIPAL");
    Console.WriteLine($"===================================");
    Console.WriteLine($"1. Registrar nueva asistencia");
    Console.WriteLine($"2. Consultar caja");
    Console.WriteLine($"3. Salir");
    Console.Write($"Elige una opción (1-3):");

    string opcionMenu = Console.ReadLine();

    if(opcionMenu == "1")
    {
        // Fase 1: Datos de la operación
        string cliente = "";
        while (cliente == "")
        {
            Console.WriteLine($"Introduce el nombre del cliente: ");
            cliente = Console.ReadLine();
            if(cliente == "")
            {
                Console.WriteLine($"Error: El nombre no puede estar vacío.");
            }
        }

        double precioServicio = 0;
        string nombreServicio = "";
        bool servicioValido = false;

        while(servicioValido == false)
        {
            Console.WriteLine($"--- SERVICIOS PRINCIPALES ---");
            Console.WriteLine($"1. Remolque urbano (50.00 €)");
            Console.WriteLine($"2. Rescate interurbano (80.00 €)");
            Console.WriteLine($"3. Reparación in situ (40.00 €)");
            Console.WriteLine($"Selecciona el servicio (1-3): ");
            string opcServicio = Console.ReadLine();

            if (opcServicio == "1")
            {
                precioServicio = 50.0;
                nombreServicio = "Remolque urbano";
                servicioValido = true;
            } else if (opcServicio == "2")
            {
                precioServicio = 80.0;
                nombreServicio = "Remolque interurbano";
                servicioValido = true;
            } else if (opcServicio == "3")
            {
                precioServicio = 40.0;
                nombreServicio = "Reparacion in situ";
                servicioValido = true;
            } else
            {
                Console.WriteLine($"Opción no válida. Inténtalo de nuevo");
            }
        }
    }
 

}