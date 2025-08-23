namespace Settings
{
    public static class NumberFormatter
    {
        public static string FormatNumber(double number, string floatFormat = "0.#")
        {
            if (number >= 1_000_000_000)
                return (number / 1_000_000_000d).ToString(floatFormat) + "B"; 
            if (number >= 1_000_000)
                return (number / 1_000_000d).ToString(floatFormat) + "M";     
            if (number >= 1_000)
                return (number / 1_000d).ToString(floatFormat) + "k";        

            return number.ToString(floatFormat);
        }
    }
}