using System.Diagnostics.CodeAnalysis;

namespace MsUser.Database
{
    [ExcludeFromCodeCoverage]
    public static class MigrationConstants
    {
        public static readonly string[] Sources = {"Migrations/Tables", "Migrations/Procedures", "Migrations/Inserts", "Migrations/Functions", "Migrations/Views"};
        public const string ScriptPrefix = "V";
        public const string RepeatableScriptPrefix = "R";
        public static readonly string[] Commands = { "migrate", "repair", "info" };
        public const string Strategy = "each";
        public const string ConnectionStringKey = "DefaultConnection";
    }
}