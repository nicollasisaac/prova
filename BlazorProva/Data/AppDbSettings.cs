namespace BlazorProva.Data
{
    public class AppDbSettings
    {
        public string DefaultConnection { get; } =
            "Host=dpg-cu944fggph6c7384pimg-a.oregon-postgres.render.com;" +
            "Port=5432;" +
            "Database=ciatalento;" +
            "Username=ciatalento_user;" +
            "Password=gu6762XvLh72I0sxkqkAhmnoA8erVuDQ;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true;";

        public string SafeConnectionString { get; } =
            "Host=dpg-cu944fggph6c7384pimg-a.oregon-postgres.render.com;" +
            "Port=5432;" +
            "Database=ciatalento;" +
            "Username=ciatalento_user;" +
            "Password=******;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true;";
    }
}
