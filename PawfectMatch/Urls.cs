using PawfectMatch.Components.Pages._Mascotas;
using PawfectMatch.Models._Mascotas;

namespace PawfectMatch
{
    public static class Urls
    {
        public static class Adoptantes
        {
            public const string Index = "/adoptantes";
            public const string Crear = "/adoptantes/crear";
            public const string Editar = "/adoptantes/editar/";
            public const string Detalle = "/adoptantes/id/";
        }

        public static class Citas
        {
            public const string Index = "/citas";
            public const string Editar = "/citas/editar/";
        }

        public static class Mascotas
        {
            public const string Index = "/mascotas";
            public const string Crear = "/mascotas/crear";
            public const string Editar = "/mascotas/editar/";
            public const string Detalle = "/mascotas/id/";
        }

        public static class Solicitudes
        {
            public const string Index = "/solicitudes";
            public const string Crear = "/solicitudes/crear";
            public const string Editar = "/solicitudes/Editar";
            public const string Detalle = "/solicitudes/id/";
        }

        public static class Account
        {
            public const string Login = "Account/Login";
            public const string Register = "Account/Register";
            public const string Manage = "Account/Manage";
        }

        public static class Sugerencias
        {
            public const string Index = "/Sugerencias";
            public const string Crear = "/Sugerencias/Crear";
        }

        public static class General
        {
            public const string Home = "/";
            public const string Nosotros = "/Nosotros";
            public const string Mascotas = "/Mascotas";

            public const string HistorialAdopciones = "/historial";

            public const string Error = "/error";
            public const string Auth = "/auth";
        }


    }
}
