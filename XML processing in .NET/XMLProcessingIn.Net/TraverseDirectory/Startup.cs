using System;
using System.IO;
using System.Text;
using System.Xml;

namespace TraverseDirectory
{
    public class Startup
    {
        public static void Main()
        {
            const string fileName = "../../dir.xml";
            var encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.WriteStartDocument();
                writer.WriteStartElement("Desktop");
                Traverse(desktopPath, writer);
                writer.WriteEndDocument();
            }

            var currentDirectory = Directory.GetCurrentDirectory();
            var savedDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDirectory + "dir.xml");
        }

        static void Traverse(string dir, XmlTextWriter writer)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                Traverse(directory, writer);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                writer.WriteAttributeString("ext", Path.GetExtension(file));
                writer.WriteEndElement();
            }
        }
    }
}
