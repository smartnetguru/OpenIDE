namespace OpenIDE.Core.JSON
{
    using Framework;
    using System;

    public static class Json
    {
        public static object Parse(string json)
        {
            var result = new JsonParserFromString().All(json);

            if (result == null)
                return null;

            return result.Value;
        }

        public class ParseException : Exception
        {
            public ParseException(string message)
               : base(message)
            {

            }
        }
    }
}