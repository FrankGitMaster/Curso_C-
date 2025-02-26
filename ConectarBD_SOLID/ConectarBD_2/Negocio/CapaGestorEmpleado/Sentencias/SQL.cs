namespace ConectarBD_2.Negocio.CapaGestorEmpleado.Sentencias
    {
    public static class SQL
        {

        public static string ConsultarEmpleado = """
            SELECT 
            	id_empleado as "IdEmpleado",
            	nombre as "Nombre",
            	sueldo as "Sueldo",
            	bonificacion as "Bonificacion",
            	fecha_contrato as "FechaContrato"
            FROM 
                empleado;
            """;

        public static string InsertarEmpleado = """
            INSERT INTO empleado (
            	nombre, sueldo, bonificacion, fecha_contrato)
            VALUES (
            	@Nombre, @Sueldo, @Bonificacion, @FechaContrato);
            """;

        public static string ActualizarEmpleado = """
            UPDATE 
                empleado 
            SET 
                nombre = @Nombre,
                sueldo = @Sueldo,
                bonificacion = @Bonificacion,
                fecha_contrato = @FechaContrato
            WHERE
                id_empleado = @IdEmpleado;
            """;

        public static string EliminarEmpleado = """
            DELETE FROM 
                empleado
            WHERE
                id_empleado = @IdEmpleado;
            """;
        }
    }
