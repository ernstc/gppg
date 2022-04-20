using System.IO;
#if !NET20
using System.Reflection;
#endif

namespace QUT.Gppg.IncludeResources
{
    internal class Content
    {
        internal const string ShiftReduceParserCode_FileName = "ShiftReduceParserCode.cs";

        internal static string ShiftReduceParserCode
        {
            get
            {
                return GetResourceString(ShiftReduceParserCode_FileName);
            }
        }

        //internal static string GplexxFrame
        //{
        //    get
        //    {
        //        return GetResourceString("gplexx.frame");
        //    }
        //}

        internal static string ResourceHeader
        {
            get
            {
                return GetResourceString("ResourceHeader.txt");
            }
        }

        static string GetResourceString(string resourceName)
        {
#if NET20
            var assembly = typeof(Content).Assembly;
#else
            var assembly = typeof(Content).GetTypeInfo().Assembly;
#endif
            using (var stream = assembly.GetManifestResourceStream("QUT.Gppg.ParserGenerator.SpecFiles." + resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
