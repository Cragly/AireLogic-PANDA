namespace AireLogic.PANDA.API;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Appointments
    {
        private const string Base = $"{ApiBase}/appointments";
        public const string Create = Base;
        public const string GetAll = Base;
    }

    public static class Patients
    {
        private const string Base = $"{ApiBase}/patients";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Clinicians
    {
        private const string Base = $"{ApiBase}/clinicians";
        public const string GetAll = Base;
    }
}
