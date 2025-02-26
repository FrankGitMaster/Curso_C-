namespace ConectarBD_2.Proyectos.Empleado.Sentencias
    {
    public static class SQL
        {

        public static string ConsultarEmpleado = """
            SELECT * FROM empleado WHERE id_empleado = @IdEmpleado;
            """;

        }
    }
