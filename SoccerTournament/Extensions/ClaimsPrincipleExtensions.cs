namespace SoccerTournament.Extensions
{
    using System.Security.Claims;

    public static class ClaimsPrincipleExtensions
    {
        public static string Id(this ClaimsPrincipal user)
           => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole("Admin");
    }
}
