using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using ISII_Taxis.Data.Objects;

// It appears Connections in .NET are handled the opposite of how I was taught in uni: You open a new one every query, preferably inside a using, and .NET is so smart that it pools it
// That's what I get from here anyway https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-connection-pooling and here https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection?view=dotnet-plat-ext-5.0#remarks

namespace ISII_Taxis.Data.Database
{
    public static class SQLInteracter
    {
        private const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Database=ISII-TAXIS;Integrated Security=True;";
        
        public static async Task<bool> RegistroUsuario(string usuario, string contrasena, string direccion, string email, string telefono)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{RegistroUsuarioParams.nombre_usuario}", SqlDbType.VarChar),
                new($"@{RegistroUsuarioParams.contrasena}", SqlDbType.VarChar),
                new($"@{RegistroUsuarioParams.direccion}", SqlDbType.VarChar),
                new($"@{RegistroUsuarioParams.email}", SqlDbType.VarChar),
                new($"@{RegistroUsuarioParams.telefono}", SqlDbType.VarChar),

            };
            parameters[0].Value = usuario;
            parameters[1].Value = contrasena;
            parameters[2].Value = direccion;
            parameters[3].Value = email;
            parameters[4].Value = telefono;
            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.registro_usuario, connection, parameters);
            
            if(!reader.HasRows)
                throw new InvalidOperationException(NoRowsError(ProcedureNames.registro_usuario));

            reader.Read();
            return (bool)reader[RegistroUsuarioColumns.result_value];
        }
        public static async Task<bool> RegistroTaxi(string matricula, byte? numeroParada, byte? numeroEstado, string email, int? numeroPlazas, DateTime horaDisponible)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{RegistroTaxiParams.matricula_taxi}", SqlDbType.VarChar),
                new($"@{RegistroTaxiParams.id_parada}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.id_estado}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.email}", SqlDbType.VarChar),
                new($"@{RegistroTaxiParams.n_plazas}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.hora_disponible}", SqlDbType.DateTime),

            };
            parameters[0].Value = matricula;
            parameters[1].Value = numeroParada;
            parameters[2].Value = numeroEstado;
            parameters[3].Value = email;
            parameters[4].Value = numeroPlazas;
            parameters[5].Value = horaDisponible;
            
            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.registro_taxi, connection, parameters);
            
            if(!reader.HasRows)
                throw new InvalidOperationException(NoRowsError(ProcedureNames.registro_taxi));

            reader.Read();
            return (bool)reader[RegistroTaxiColumns.result_value];
        }
        public static async Task<int> EditarTaxi(string matricula, byte? numeroParada, byte? numeroEstado, string email, int? numeroPlazas, DateTime horaDisponible)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{RegistroTaxiParams.matricula_taxi}", SqlDbType.VarChar),
                new($"@{RegistroTaxiParams.id_parada}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.id_estado}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.email}", SqlDbType.VarChar),
                new($"@{RegistroTaxiParams.n_plazas}", SqlDbType.TinyInt),
                new($"@{RegistroTaxiParams.hora_disponible}", SqlDbType.DateTime),

            };
            parameters[0].Value = matricula;
            parameters[1].Value = numeroParada;
            parameters[2].Value = numeroEstado;
            parameters[3].Value = email;
            parameters[4].Value = numeroPlazas;
            parameters[5].Value = horaDisponible;
            
            return await ExecuteReturnValueProcedure(ProcedureNames.editar_taxi, parameters);
        }
        
        public static async Task<int> EliminarTaxi(string matricula)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{RegistroTaxiParams.matricula_taxi}", SqlDbType.VarChar)

            };
            parameters[0].Value = matricula;
            
            return await ExecuteReturnValueProcedure(ProcedureNames.eliminar_taxi, parameters);
        }

        public static async Task<int> CrearSolicitud(string? username, string? matricula, byte? numeroParadaInicial, byte? numeroParadaFinal, DateTime fechaDisponible)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{CrearSolicitudParams.nombre_usuario}", SqlDbType.VarChar),
                new($"@{CrearSolicitudParams.matricula_taxi}", SqlDbType.VarChar),
                new($"@{CrearSolicitudParams.id_parada_origen}", SqlDbType.Int),
                new($"@{CrearSolicitudParams.id_parada_destino}", SqlDbType.Int),
                new($"@{CrearSolicitudParams.hora_fecha}", SqlDbType.DateTime),

            };
            parameters[0].Value = username;
            parameters[1].Value = matricula;
            parameters[2].Value = numeroParadaInicial;
            parameters[3].Value = numeroParadaFinal;
            parameters[4].Value = fechaDisponible;
            
            int result = await ExecuteReturnValueProcedure(ProcedureNames.registro_solicitud, parameters);

            return result;
            
        }
        public static async Task<bool> LoginUsuario(string usuario, string contrasena)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{LoginUsuarioParams.nombre_usuario}", SqlDbType.VarChar),
                new($"@{LoginUsuarioParams.contrasena}", SqlDbType.VarChar),

            };
            parameters[0].Value = usuario;
            parameters[1].Value = contrasena;
            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.login_usuario, connection, parameters);

            return reader.HasRows;
        }

        public static async Task<Taxi?> ConsultaTaxi(string matricula)
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            SqlParameter[] parameters =
            {
                new($"@{ConsultaTaxiParams.matricula_taxi}", SqlDbType.VarChar),
            };
            parameters[0].Value = matricula;
            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.consulta_taxi, connection, parameters);
            
            if(!reader.HasRows)
                return null;

            reader.Read();
            return new Taxi()
            {
                matricula = (string)reader[TablaTaxiColumns.matricula_taxi],
                estado = (string)reader[TablaTaxiColumns.desc_estado],
                parada = (string)reader[TablaTaxiColumns.nombre_parada],
                email = (string)reader[TablaTaxiColumns.email],
                horaDisponible = (DateTime)reader[TablaTaxiColumns.hora_disponible]
            };
        }
        public static async Task<List<Taxi>> ConsultaTaxis()
        {
            await using SqlConnection connection = new(CONNECTION_STRING);

            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.consulta_taxis, connection);

            List<Taxi> result = new();

            while (reader.Read())
            {
                result.Add(new Taxi()
                {
                    matricula = (string)reader[TablaTaxiColumns.matricula_taxi],
                    estado = (string)reader[TablaTaxiColumns.desc_estado],
                    parada = (string)reader[TablaTaxiColumns.nombre_parada],
                    email = (string)reader[TablaTaxiColumns.email],
                    horaDisponible = (DateTime)reader[TablaTaxiColumns.hora_disponible]
                });
            }

            return result;
        }

        public static async Task<List<Parada>?> ConsultaParadas()
        {
            await using SqlConnection connection = new(CONNECTION_STRING);
            await using SqlDataReader reader = await ExecuteReturnQueryProcedure(ProcedureNames.consulta_paradas, connection);
            
            List<Parada> paradas = new();

            while (reader.Read())
            {
                paradas.Add(new Parada()
                {
                    id_parada = (int)reader[ParadasColumns.id_parada], 
                    nombre_parada = (string) reader[ParadasColumns.nombre_parada]
                });
            }

            return paradas;
        }

        #region helper functions
        private static async Task<SqlDataReader> ExecuteReturnQueryProcedure(string procedure_name, SqlConnection conn, SqlParameter[]? parameters = null)
        {
            await conn.OpenAsync();
            SqlCommand sqlComm = new(procedure_name, conn) {CommandType = CommandType.StoredProcedure};
            if (parameters != null)
                sqlComm.Parameters.AddRange(parameters);
            sqlComm.CommandTimeout = 60;
            
            SqlDataReader reader = await sqlComm.ExecuteReaderAsync();
            return reader;
        }


        private static async Task<int> ExecuteReturnValueProcedure(string procedure_name, SqlParameter[]? parameters = null)
        {
            await using SqlConnection conn = new(CONNECTION_STRING);
            await conn.OpenAsync();
            SqlCommand sqlComm = new(procedure_name, conn) {CommandType = CommandType.StoredProcedure};
            if (parameters != null)
                sqlComm.Parameters.AddRange(parameters);
            sqlComm.CommandTimeout = 60;
            SqlParameter? returnValueIndex = sqlComm.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            returnValueIndex.Direction = ParameterDirection.ReturnValue;
            
            await sqlComm.ExecuteNonQueryAsync();
            return (int) returnValueIndex.Value;
        }

        private static string NoRowsError(string procedure)
        {
            return $"The \"{procedure}\" stored procedure returned no rows. Have you populated the database?";
        }

        #endregion
        
    }
}