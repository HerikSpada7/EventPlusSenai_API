namespace EventPlus_API.Utils
{
    /// <summary>
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// </summary>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// </summary>
        public static bool CompararHash(string senhaInformada, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaBanco);
        }
    }
}
