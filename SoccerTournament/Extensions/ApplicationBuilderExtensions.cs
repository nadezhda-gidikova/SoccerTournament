namespace SoccerTournament.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Admin"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Admin" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@google.com";
                    const string adminPassword = "admin12";

                    var user = new IdentityUser
                    {
                        Email = adminEmail,
                        UserName = adminEmail,

                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);

                    var roleUser = new IdentityRole { Name = "User" };

                    await roleManager.CreateAsync(roleUser);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
