namespace GestionVehiculos
{

    class Program
    {

        public static void Main(string[] args)
        {

            string opcion1 = "1. Agregar Vehiculo";
            string opcion2 = "2. Mostrar todos los vehículos";
            string opcion3 = "3. Mostrar la cantidad de vehículos por tipo";
            string opcion4 = "4. Salir del programa";

            List<string> listaSedan = new List<string>
                {
                "Sedan 1", "Sedan 2"
                };

            List<string> listaSuv = new List<string>
                {
                "Suv 1", "Suv 2"
                };

            List<string> listaCamineta = new List<string>
                {
                "Camioneta 1", "Camioneta 2"
                };

            List<string> listaMotocicleta = new List<string>
                {
                "Motocicleta 1", "Motocicleta 2"
                };

            List<string> listaDeportivo = new List<string>
                {
                "Deportivo 1", "Deportivo 2"
                };

            // diccionarioVehiculos es una estructura de datos que almacena pares clave-valor
            // Clave es de tipo enum TipoVehiculo
            // Clave es una lista de strings
            Dictionary<TipoVehiculo, List<string>> diccionarioVehiculos = new Dictionary<TipoVehiculo, List<string>>()
                {
                    { TipoVehiculo.SEDAN, listaSedan},
                    { TipoVehiculo.SUV, listaSuv},
                    { TipoVehiculo.CAMIONETA, listaCamineta},
                    { TipoVehiculo.MOTOCICLETA, listaMotocicleta},
                    { TipoVehiculo.DEPORTIVO, listaDeportivo},
                };

            // Método que será usado como delegado
            void AgregarVehiculo(List<string> lista, string nuevoVehiculo, TipoVehiculo tipoVehiculo)
            {
                lista.Add(nuevoVehiculo);
                Console.WriteLine($"Se agrego el vehículo {nuevoVehiculo} a la lista {tipoVehiculo}.");
            }
            /*
             ¿Qué es un delegado?

                Un delegado es un tipo que almacena una referencia a un método. Es como un puntero a funciones que se puede pasar como parámetro, almacenar o invocar.
                Aquí está ocurriendo lo siguiente:
                Action<List<string>, string, TipoVehiculo>:

                    Action es un elegado predefinido en C#.
                    Sirve para métodos que no retornan ningún valor (void) pero aceptan parámetros.
                    En este caso, el Action espera tres parámetros:
                    List<string>: Una lista de string (vehículos).
                    string: Un nuevo vehículo (nombre del vehículo).
                    TipoVehiculo: Un tipo de vehículo (del enum TipoVehiculo).
                    OtraFuncion:
                    
                    Es el nombre del parámetro que representa una función que coincida con la firma de Action.
                    Es decir, OtraFuncion debe ser un método que reciba List<string>, string y TipoVehiculo como parámetros, y que no retorne nada.
                    ¿Qué hace esto?
                    
                    La función ObtenerListaTiposVehiculos recibe como argumento una función (el delegado OtraFuncion).
                    Luego, invoca esa función dentro de su lógica, pasándole los parámetros adecuados.

                ¿Por qué usar un delegado aquí?
                    
                    Puedes pasar diferentes métodos como argumento en OtraFuncion.
                    Si quisieras realizar otra acción, como eliminar un vehículo o modificar la lista, solo necesitarías crear un método que coincida con la misma firma y pasarlo como delegado.
             */

            // La función ObtenerListaTiposVehiculosParaAgregar recibe como parámetro un delegado Action llamado OtraFuncion.
            // Este delegado permite pasar cualquier método que cumpla con la misma firma (List<string>, string, TipoVehiculo)
            void ObtenerListaTiposVehiculosParaAgregar(Action<List<string>, string, TipoVehiculo> OtraFuncion)
            {
                do
                {
                    // El usuario elige el tipo de vehículo de un diccionario.
                    Console.WriteLine("Ingrese el tipo del vehículo");
                    // Se crea una nueva lista para almacenar las llaves del diccionario casteadas como una lista con ToList()
                    List<TipoVehiculo> listaTiposVehiculos = diccionarioVehiculos.Keys.ToList();
                    for (int i = 0; i < listaTiposVehiculos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {listaTiposVehiculos[i]}");
                    }
                    string opcionTipo = Console.ReadLine();
                    if (!Int32.TryParse(opcionTipo, out int resultadoTipo))
                    {
                        Console.WriteLine("ERROR! Elija una opción válida");
                        continue;
                    }
                    else
                    {
                        TipoVehiculo tipoSeleccionado = listaTiposVehiculos[resultadoTipo - 1];
                        List<string> listaTipoSeleccionado = diccionarioVehiculos[tipoSeleccionado];
                        // Se le solicita un nombre para el nuevo vehículo.
                        Console.WriteLine($"Ingrese el nombre del nuevo vehículo para la lista de {tipoSeleccionado}");
                        string nuevoVehiculo = Console.ReadLine();
                        // Se llama al delegado OtraFuncion y se le pasan los parámetros
                        OtraFuncion(listaTipoSeleccionado, nuevoVehiculo, tipoSeleccionado);
                        break;
                    }
                } while (true);
            }

            void MostrarVehiculos<T>()
            {
                // La variable tipo tiene el tipo KeyValuePair<TipoVehiculo, List<string>> porque diccionarioVehiculos es un diccionario
                foreach (var tipo in diccionarioVehiculos)
                {
                    string tipoVehiculo = tipo.Key.ToString();
                    List<string> listaVehiculos = tipo.Value;
                    Console.WriteLine(tipoVehiculo);
                    foreach (string vehiculo in listaVehiculos)
                    {
                        Console.WriteLine($"{vehiculo}");
                    }
                    Console.WriteLine();
                }
            }

            void MostrarCantidadVehiculos()
            {
                foreach (var tipo in diccionarioVehiculos)
                {
                    string tipoVehiculo = tipo.Key.ToString();
                    List<string> listaVehiculos = tipo.Value.ToList();
                    Console.WriteLine($"{tipoVehiculo}\n{listaVehiculos.Count}\n");
                }
            }

            do
            {
                Console.WriteLine("Sistema de gestión de vehiculos\n" +
                    "Elija una opción en el menú:\n" +
                    $"{opcion1}\n" +
                    $"{opcion2}\n" +
                    $"{opcion3}\n" +
                    $"{opcion4}");
                string opcion = Console.ReadLine();
                if (!Int32.TryParse(opcion, out int resultado) || resultado > 4 || resultado < 1)
                {
                    Console.WriteLine("ERROR! Ingrese una opción valida.\n");
                    continue;
                }
                else
                {
                    Console.WriteLine();
                    switch (resultado)
                    {
                        case 1:
                            Console.WriteLine(opcion1);
                            ObtenerListaTiposVehiculosParaAgregar(AgregarVehiculo);
                            break;
                        case 2:
                            Console.WriteLine(opcion2);
                            MostrarVehiculos<string>();
                            break;
                        case 3:
                            Console.WriteLine(opcion3);
                            MostrarCantidadVehiculos();
                            break;
                        case 4:
                            Console.WriteLine("El programa finalizó.");
                            // return: Indica que el método debe finalizar inmediatamente. Una vez que el programa
                            // llega a return, se interrumpe cualquier ejecución restante, sin importar si hay un
                            // continue o cualquier otra lógica después del bloque actual.
                            // return está asociado al método, no al bloque específico(como el do -while o el switch)
                            // en el que está contenido. Esta dentro de Main().
                            return;
                    }
                    continue;
                }
            } while (true);
        }

        enum TipoVehiculo
        {
            SEDAN, SUV, CAMIONETA, MOTOCICLETA, DEPORTIVO
        }

    }
}
/*
Ejercicio: Sistema de Gestión de Vehículos
Crea un programa en C# que gestione información de diferentes tipos de vehículos. Deberás usar un enum para definir los tipos de vehículos y un Dictionary para almacenar información sobre ellos.

Requisitos:
Define un enum llamado TipoVehiculo que contenga los siguientes valores:

Sedan
SUV
Camioneta
Motocicleta
Deportivo
Utiliza un Dictionary para almacenar información de vehículos donde:

La clave es el TipoVehiculo.
El valor es una lista de nombres de vehículos de ese tipo.
Implementa las siguientes funcionalidades:

AgregarVehiculo: Permite agregar un vehículo a un tipo específico.
MostrarVehiculos: Imprime todos los vehículos registrados agrupados por su tipo.
ContarVehiculosPorTipo: Cuenta cuántos vehículos hay en cada tipo.
Crea un menú interactivo para el usuario donde pueda:

Agregar un vehículo.
Mostrar todos los vehículos.
Mostrar la cantidad de vehículos por tipo.
Salir del programa.
 */