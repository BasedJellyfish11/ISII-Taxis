namespace ISII_Taxis.Data.Database
{
    // Pretty much nothing in this file will follow C# naming conventions due to it matching SQL names.
    // This is also just a glorified string dictionary ngl
    public static class ProcedureNames
    {
        public const string registro_usuario = nameof(registro_usuario);
        public const string registro_taxi = nameof(registro_taxi);
        public const string editar_taxi = nameof(editar_taxi);
        public const string eliminar_taxi = nameof(eliminar_taxi);
        public const string registro_solicitud = nameof(registro_solicitud);
        public const string login_usuario = nameof(login_usuario);
        public const string consulta_taxi = nameof(consulta_taxi);
        public const string consulta_taxis = nameof(consulta_taxis);
        public const string consulta_paradas = nameof(consulta_paradas);
    }


    #region ProcedureReturnColumns
    
    public static class TablaTaxiColumns
    {
        public const string matricula_taxi = nameof(matricula_taxi);
        public const string nombre_parada = nameof(nombre_parada);
        public const string desc_estado = nameof(desc_estado);
        public const string email = nameof(email);
        public const string hora_disponible = nameof(hora_disponible);
    }
    public static class RegistroUsuarioColumns
    {
        public const string result_value = nameof(result_value);
    }
    
    public static class RegistroTaxiColumns
    {
        public const string result_value = nameof(result_value);
    }
    public static class ParadasColumns
    {
        public const string id_parada = nameof(id_parada);
        public const string nombre_parada = nameof(nombre_parada);
        public const string coord_x = nameof(coord_x);
        public const string coord_y = nameof(coord_y);
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
    
    public static class CrearSolicitudParams
    {
        public const string nombre_usuario = nameof(nombre_usuario);
        public const string matricula_taxi = nameof(matricula_taxi);
        public const string id_parada_origen = nameof(id_parada_origen);
        public const string id_parada_destino = nameof(id_parada_destino);
        public const string hora_fecha = nameof(hora_fecha);
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
    public static class LoginUsuarioParams
    {
        public const string nombre_usuario = nameof(nombre_usuario);
        public const string contrasena = nameof(contrasena);
    }

    public static class ConsultaTaxiParams
    {
        public const string matricula_taxi = nameof(matricula_taxi);
    }

    #endregion
    

    
}