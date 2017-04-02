using System.Drawing;
using System.IO;
using Horizon.Framework;

namespace Protogame
{
    public class WorkbenchBrandingEngine : IBrandingEngine
    {
        public string ProductName
        {
            get { return "Protogame"; }
        }

        public string ProductStorageID
        {
            get { return "protogame"; }
        }

#if PLATFORM_WINDOWS
        public Icon WindowsIcon
        {
            get
            {
                //return new Icon(new MemoryStream());
                return null;
            }
        }
#elif PLATFORM_LINUX
        public Gdk.Pixbuf LinuxIcon
        {
            get
            {
                //return new Gdk.Pixbuf(GetBinaryStreamFromXmlReference("LinuxIcon"));
                return null;
            }
        }
#endif
    }
}
