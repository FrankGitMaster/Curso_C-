namespace EnumDictionary
    {

    class Program
        {

        public static void Main(string[] args)
            {

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

            Dictionary<TipoVehiculo, List<string>> diccionarioVehiculos = new Dictionary<TipoVehiculo, List<string>>()
                {
                    { TipoVehiculo.SEDAN, listaSedan},
                    { TipoVehiculo.SUV, listaSuv},
                    { TipoVehiculo.CAMIONETA, listaCamineta},
                    { TipoVehiculo.MOTOCICLETA, listaMotocicleta},
                    { TipoVehiculo.DEPORTIVO, listaDeportivo},
                };

            void AgregarVehiculo(List<string> lista, string nuevoVehiculo)
                {
                lista.Add(nuevoVehiculo);
                Console.WriteLine($"Se agrego el vehículo {nuevoVehiculo} a la lista.");
                }

            void MostrarVehiculos<T>()
                {
                foreach (var tipo in diccionarioVehiculos)
                    {
                    string tipoVehiculo = tipo.Key.ToString();
                    List<string> listaVehiculos = diccionarioVehiculos[tipo.Key];
                    Console.WriteLine(tipoVehiculo);
                    foreach(string vehiculo in listaVehiculos)
                        {
                        Console.WriteLine($"- {vehiculo}");
                        }
                    Console.WriteLine();
                    }
                }

            void ObtenerListaTiposVehiculos<T>(Action<List<T>, string> OtraFuncion)
                {
                do
                    {
                    Console.WriteLine("Ingrese el tipo del vehículo");
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
                        TipoVehiculo TipoSeleccionado = listaTiposVehiculos[resultadoTipo - 1];
                        List<T> listaTipoSeleccionado = diccionarioVehiculos[TipoSeleccionado] as List<T>;
                        Console.WriteLine("Ingrese el nombre del nuevo vehículo");
                        string nuevoVehiculo = Console.ReadLine();
                        OtraFuncion(listaTipoSeleccionado, nuevoVehiculo);
                        break;
                        }
                    } while (true);
                }

            do
                {
                Console.WriteLine("Sistema de gestión de vehiculos\n\n" +
                    "Elija una opción en el menú:\n" +
                    "1. Agregar un vehículo\n" +
                    "2. Mostrar todos los vehículos\n" +
                    "3. Mostrar la cantidad de vehículos por tipo\n" +
                    "4. Salir del programa");
                string opcion = Console.ReadLine();
                if (!Int32.TryParse(opcion, out int resultado) || resultado > 4 || resultado < 1)
                    {
                    Console.WriteLine("ERROR! Ingrese una opcion del menu");
                    continue;
                    }
                else
                    {
                    switch (resultado)
                        {
                        case 1:
                            ObtenerListaTiposVehiculos<string>(AgregarVehiculo);
                            break;
                        case 2:
                            MostrarVehiculos<string>();
                            break;
                        case 3:
                            Console.WriteLine("caso 3");
                            break;
                        case 4:
                            Console.WriteLine("caso 4");
                            break;
                        }
                    if (resultado == 4)
                        {
                        break;
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