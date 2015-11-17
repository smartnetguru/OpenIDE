using Ionic.Zip;
using System.IO;

namespace OpenIDE.Core.Extensibility
{
    public class RessourceReader
    {
        private ZipFile zip;

        public RessourceReader(Plugin p)
        {
            zip = p.Archive;
        }

        public Stream Read(string name)
        {
            return zip[name].OpenReader();
        }
    }
}