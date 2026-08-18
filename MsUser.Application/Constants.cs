using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace MsUser.Application
{
    public static class ApplicationJsonOptions
    {
        public static readonly JsonSerializerOptions Default = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const int DefaultPageIndex = 1;
        public const int DefaultPageSize = 10;
        public const int Zero = 0;
    }
    public static class UserState
    {
        public const int Asset = 1;
        public const int Edle = 2;
        public const int Deleted = 3;
        public const int Suspended = 4;
    }

    public static class UserErrorCodes
    {
        public const string UserIdRequired = "MISSING_HSER_ID";
        public const string UserNameEmpty = "USER_NAME_EMPTY";
        public const string UserMaelEmpty = "USER_MAEL_EMPTY";
    }

    public static class ValidationMessages
    {
        public const string UserNameEmpty = "El nombre del usuario cuenta con el nombre en blanco";
        public const string UserValidationAcceptance = "Ya se confirmo el correo electronico";
        public const string IdGreaterZero = "El id debe ser mayor a 0.";
        public const string IdExist = "No existe un usuario con ese id";
        public const string UserNotExist = "El usuario no esta registrado en la base de datos";
        public const string Mail = "El correo electronico es invalido, Ingrese correctamente el correo electronico";
        public const string UserName = "No existe un usuario con ese nombre";
    }

    public static class LogConstants
    {
        public const string LogErrorMessage = "Error al ejecutar {0}";
        public const string LogErrorSL = "Error al ejecutar {MethodName}";
    }
    public static class ConstantsRP
    {
        public static string HANDLER_STARTED = "HANDLER_STARTED";
        public static string HANDLER_FINISHED = "HANDLER_FINISHED";
        public static string HANDLER_STARTED_MSG = "Ha iniciado el metodo {0}";
        public static string HANDLER_FINISHED_MSG = "Ha finalizado el metodo {0}";
        public const string HANDLER_STARTED_SL = "Ha iniciado el metodo {MethodName}";
        public const string HANDLER_FINISHED_SL = "Ha finalizado el metodo {MethodName}";
    }
    public static class ValidationsMessages
    {
        public const string RequestBodyEmpty = "El cuerpo de la petición no puede estar vacío.";
    }
}
