namespace projeodev.Models
{
    public static class SessionHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static ISession Session => _httpContextAccessor.HttpContext.Session;
    }

}
