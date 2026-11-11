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

    string opcionMenu = Console.ReadLine()!;

    if(opcionMenu == "1")
    {
        // Fase 1: Datos de la operación
        string cliente = "";
        while (cliente == "")
        {
            Console.WriteLine($"Introduce el nombre del cliente: ");
            cliente = Console.ReadLine()!;
            if(cliente == "")
            {
                Console.WriteLine($"Error: El nombre no puede estar vacío.");
            }
        }

        // Fase 2: Servicio Principal

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
            string opcServicio = Console.ReadLine()!;

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

        // Fase 3: Extras

        bool tieneVehiculoSustitucion = false;
        bool tieneCustodia = false;
        bool tieneGruaPluma = false;
        int contadorExtras = 0;
        double precioExtras = 0;
        bool finExtras = false;

        while(finExtras == false)
        {
            Console.WriteLine($"--- EXTRAS ---");
            Console.WriteLine($"1. Vehículo de sustitución (+30.00 €)");
            Console.WriteLine($"2. Custodia en depósito (+20.00 €)");
            Console.WriteLine($"3. Grúa pluma de extracción (+50.00 €)");
            Console.WriteLine($"0. Terminar de añadir extras");
            Console.WriteLine($"Añade un extra (0-3): ");
            string opcExtra = Console.ReadLine();

            if (opcExtra == "0")
            {
                finExtras = true;

            } else if (opcExtra == "1")
            {
                if (tieneVehiculoSustitucion)
                {
                    Console.WriteLine ($"Aviso: Ya has añadido este extra. No se cobrará doble.");
                } else
                {
                    tieneVehiculoSustitucion = true;
                    precioExtras += 30.0;
                    contadorExtras++;
                    Console.WriteLine($"Extra añadido.");
                }
            } else if (opcExtra == "2")
            {
                if (tieneCustodia)
                {
                    Console.WriteLine ($"Aviso: Ya has añadido este extra. No se cobrará doble.");
                } else
                {
                    tieneCustodia = true;
                    precioExtras += 20.0;
                    contadorExtras++;
                    Console.WriteLine($"Extra añadido.");
                }
            } else if (opcExtra == "3")
            {
                if (tieneGruaPluma)
                {
                    Console.WriteLine ($"Aviso: Ya has añadido este extra. No se cobrará doble.");
                } else
                {
                    tieneGruaPluma = true;
                    precioExtras += 50.0;
                    contadorExtras++;
                    Console.WriteLine($"Extra añadido.");
                }
            }else
            {
                Console.WriteLine($"Opción fuera de rango.");
            }
        }
    }
 

}