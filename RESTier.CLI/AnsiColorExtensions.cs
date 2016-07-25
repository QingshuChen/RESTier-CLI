namespace Microsoft.RESTier.Cli
{
    internal static class AnsiColorExtensions
    {
        public const string TEMPLATE = @"\x1b[{0}m";
        public static string START_BOLD = string.Format(TEMPLATE, 1);
        public static string END_BOLD = string.Format(TEMPLATE, 22);
        public static string BLACK = string.Format(TEMPLATE, 30);
        public static string RED = string.Format(TEMPLATE, 31);
        public static string GREEN = string.Format(TEMPLATE, 32);
        public static string YELLOW = string.Format(TEMPLATE, 33);
        public static string BLUE = string.Format(TEMPLATE, 34);
        public static string MAGENTA = string.Format(TEMPLATE, 35);
        public static string CYAN = string.Format(TEMPLATE, 36);
        public static string GREY = string.Format(TEMPLATE, 37);
        public static string RESET = string.Format(TEMPLATE, 39);

        public static string Black(this string text)
        {
            return BLACK + text + RESET;
        }

        public static string Red(this string text)
        {
            return RED + text + RESET;
        }

        public static string Green(this string text)
        {
            return GREEN + text + RESET;
        }

        public static string Yellow(this string text)
        {
            return YELLOW + text + RESET;
        }

        public static string Blue(this string text)
        {
            return BLUE + text + RESET;
        }

        public static string Magenta(this string text)
        {
            return MAGENTA + text + RESET;
        }

        public static string Cyan(this string text)
        {
            return CYAN + text + RESET;
        }

        public static string White(this string text)
        {
            return GREY + text + RESET;
        }

        public static string Bold(this string text)
        {
            return START_BOLD + text + END_BOLD;
        }
    }
}