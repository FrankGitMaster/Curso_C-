namespace ConectarBD.Sentencias
    {

    /// <summary>
    /// Clase con las sentencias SELECT, INSERT, UPDATE y DELETE de la tabla empleado
    /// </summary>
    public static class SQL
        {

        public static string ConsultarEmpleados = """
            SELECT * FROM empleado;
            """;

        public static string IngresarEmpleado = """
            INSERT INTO empleado (nombre, sueldo, bonificacion, fecha_contrato)
            VALUES (@nombre, @sueldo, @bonificacion, @fecha_contrato);
            """;

        public static string ActualizarEmpleado = """
            UPDATE empleado 
            SET sueldo = @Sueldo, bonificacion = @Bonificacion 
            WHERE id_empleado = @IdEmpleado;
            """;

        public static string EliminarEmpleado = """
            DELETE FROM empleado 
            WHERE id_empleado = @idEmpleado;
            """;

        }
    }
