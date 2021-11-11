namespace ISII_Taxis.Data.Database
{
    // Pretty much nothing in this file will follow C# naming conventions due to it matching SQL names.
    // This is also just a glorified string dictionary ngl
    public static class ProcedureNames
    {
        public const string registro_usuario = nameof(registro_usuario);
        public const string registro_taxi = nameof(registro_taxi);
    }


    #region ProcedureReturnColumns
    
    public static class RegistroUsuarioColumns
    {
        public const string result_value = nameof(result_value);
    }
    
    public static class RegistroTaxiColumns
    {
        public const string result_value = nameof(result_value);
    }
    
    #endregion
    // Procedure params

    #region ProcedureParameters

    public static class RegistroUsuarioParams
    {
        public const string nombre_usuario = nameof(nombre_usuario);
        public const string contrasena = nameof(contrasena);
        public const string direccion = nameof(direccion);
        public const string email = nameof(email);
        public const string telefono = nameof(telefono);
    }
    public static class RegistroTaxiParams
    {
        public const string matricula_taxi = nameof(matricula_taxi);
        public const string id_parada = nameof(id_parada);
        public const string id_estado = nameof(id_estado);
        public const string email = nameof(email);
        public const string n_plazas = nameof(n_plazas);
        public const string hora_disponible = nameof(hora_disponible);
    }
    #endregion
    

    
}