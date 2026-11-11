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
    Console.Write($"Elige una opción (1-3): ");

    string opcionMenu = Console.ReadLine()!;

    if(opcionMenu == "1")
    {
        // Fase 1: Datos de la operación
        string cliente = "";
        while (cliente == "")
        {
            Console.Write($"Introduce el nombre del cliente: ");
            cliente = Console.ReadLine()!;
            if(cliente.Trim() == "")
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
            Console.WriteLine("");
            Console.WriteLine($"--- SERVICIOS PRINCIPALES ---");
            Console.WriteLine($"1. Remolque urbano (50.00 €)");
            Console.WriteLine($"2. Rescate interurbano (80.00 €)");
            Console.WriteLine($"3. Reparación in situ (40.00 €)");
            Console.Write($"Selecciona el servicio (1-3): ");
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
            Console.WriteLine("");
            Console.WriteLine($"--- EXTRAS ---");
            Console.WriteLine($"1. Vehículo de sustitución (+30.00 €)");
            Console.WriteLine($"2. Custodia en depósito (+20.00 €)");
            Console.WriteLine($"3. Grúa pluma de extracción (+50.00 €)");
            Console.WriteLine($"0. Terminar de añadir extras");
            Console.Write($"Añade un extra (0-3): ");
            string opcExtra = Console.ReadLine()!;

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
            } else
            {
                Console.WriteLine($"Opción fuera de rango.");
            }
        }

        // Fase 4: Condición específica (horario)

        double recargoHorario = 0;
        string tipoHorario ="";
        bool horarioValido = false;

        while (horarioValido == false)
        {
            Console.WriteLine("");
            Console.WriteLine($"--- HORARIO DE ATENCIÓN ---");
            Console.WriteLine($"1. Diurno (Sin recargo)");
            Console.WriteLine($"2. Nocturno / Festivo (+20% sobre el servicio principal)");
            Console.Write($"Selecciona el horario (1-2): ");
            string opcHorario = Console.ReadLine()!;

            if (opcHorario == "1")
            {
                recargoHorario = 0;
                tipoHorario = "Diurno";
                horarioValido = true;
            } else if (opcHorario == "2")
            {
                recargoHorario = precioServicio * 0.20;
                tipoHorario = "Nocturno / Festivo";
                horarioValido = true;
            } else
            {
                Console.WriteLine("opción no válida.");
            }
        }

        // Fase 5: Cálculos y Descuento

        double subtotal = precioServicio + precioExtras + recargoHorario;
        double descuento = 0;

        if (subtotal > 100)
        {
            descuento = subtotal * 0.10;
        }

        double totalFinal = subtotal - descuento;
        if (totalFinal < 0)
        {
            totalFinal = 0;
        }
        Console.WriteLine($"TOTAL A COBRAR: {totalFinal.ToString("F2")} €");

        // Fase 6: Cobro 

        double dineroEntregado = 0;
        while (dineroEntregado < totalFinal)
        {
            Console.Write($"Introduce el dinero entregado por el cliente: ");
            string entradaPago = Console.ReadLine()!;

            if(entradaPago != "")
            {
                dineroEntregado = Convert.ToDouble(entradaPago);
                if (dineroEntregado < totalFinal)
                {
                    Console.WriteLine($"Pago Insuficiente. Falta {(totalFinal - dineroEntregado).ToString("F2")} € para completar el pago.");
                }
            }
        }
        double cambio = dineroEntregado - totalFinal;

        operacionesCobradas++;
        recaudacionTotal += totalFinal;

        if (totalFinal > importeMasCaro)
        {
            importeMasCaro = totalFinal;
            clienteMasCaro = cliente;
        }

        // Fase 7: Justificante

        Console.WriteLine("");
        Console.WriteLine($"==============================");
        Console.WriteLine($"   TICKET DE ROAD RESCUE      ");
        Console.WriteLine($"==============================");
        Console.WriteLine($"Nº Operación: {operacionesCobradas}");
        Console.WriteLine($"Cliente: {cliente}");
        Console.WriteLine($"Servicio: {nombreServicio} ({precioServicio.ToString("F2")} €)");
        Console.WriteLine($"Horario: {tipoHorario} (+{recargoHorario.ToString("F2")}) €");

        if (contadorExtras > 0)
        {
            Console.WriteLine($"Extras ({contadorExtras}):");
            if (tieneVehiculoSustitucion)
            {
                Console.WriteLine($" - Vehículo sustitución (30.00€)");
            }
            if (tieneCustodia)
            {
                Console.WriteLine($" - Custodia en depósito (20.00€)");
            }
            if (tieneGruaPluma)
            {
                Console.WriteLine($" - Grúa pluma (50.00€)");
            }
        } else
        {
            Console.WriteLine($"Extras: Ninguno");
        }

        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"Subtotal: {subtotal.ToString("F2")}€");
        if (descuento > 0)
        {
            Console.WriteLine($"Descuento (10% por importe > 100€) -{descuento.ToString("F2")} €");
        }
        Console.WriteLine($"TOTAL: {totalFinal.ToString("F2")} €");
        Console.WriteLine($"Entregado: {dineroEntregado.ToString("F2")} €");
        Console.WriteLine($"Cambio: {cambio.ToString("F2")} €");
        Console.WriteLine($"===================================");
    } else if (opcionMenu == "2")
    {
        // Fase 8: Caja
        Console.WriteLine("");
        Console.WriteLine("====================================");
        Console.WriteLine("    ESTADÍSTICAS DE LA CAJA         ");
        Console.WriteLine("====================================");

        if (operacionesCobradas == 0)
        {
            Console.WriteLine($"Aún no hay asistencias registradas en esta sesión.");
        } else
        {
            double media = recaudacionTotal / operacionesCobradas;
            Console.WriteLine($"Asistencias cobradas: {operacionesCobradas}");
            Console.WriteLine($"Recaudación total: {recaudacionTotal.ToString("F2")} €");
            Console.WriteLine($"Importe medio por asistencia: {media.ToString("F2")} €");
            Console.WriteLine($"Servicio más caro: {importeMasCaro.ToString("F2")} € (Cliente: {clienteMasCaro})");      

        }
        Console.WriteLine("====================================");

    } else if (opcionMenu == "3")
    {
        Console.WriteLine($"Cerrando sistema Road Rescue. ¡Buen Turno!");
        if (operacionesCobradas > 0)
        {
            Console.WriteLine($"Resumen final del turno: {operacionesCobradas} asistencias realizadas. Total ingresos: {recaudacionTotal.ToString("F2")} €");
        }
        salir = true;
    } else
    {
        Console.WriteLine($"Opción no válida. Por favor, introduce 1, 2 o 3.");
    }
}