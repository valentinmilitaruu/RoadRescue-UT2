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

        
    }
 

}