namespace FlyObject.Lib
{
    public static class StringExtensions
    {
        /// <summary>
        /// Split string with spaces to int values.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int[] ToIntArray(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException($"'{nameof(source)}' cannot be null or whitespace.", nameof(source));

            return source.Split(' ').Select(int.Parse).ToArray();
        }
    }
}
