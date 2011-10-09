namespace Kolbalt.Core.Domain.Validations
{
    public static class ValidationMethods
    {

        public static bool BeLessThan4000(string synopsis)
        {
            if (synopsis != null)
                return synopsis.Length <= 4000;
            return true;
        }

        public static bool BeLessThan300(string title)
        {
            return title.Length <= 300;
        }

        public static bool BeEmptyOr7Digits(string imdbId)
        {
            var pass = false;
            if (string.IsNullOrEmpty(imdbId))
                pass = true;
            else if (imdbId.Length == 7)
            {
                int result;
                if (int.TryParse(imdbId, out result))
                    pass = true;
            }
            return pass;
        }
    }
}
