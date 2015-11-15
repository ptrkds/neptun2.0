using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Neptun_2._0
{
    class XmlHandler
    {
        internal void start()
        {
            using (XmlReader reader = XmlReader.Create("UserXML.xml"))
            {
                reader.ReadToFollowing("id");
                Console.WriteLine(reader.Value.Trim());


                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "users":
                                // Detect this element.
                                Console.WriteLine("Start <users> element.");
                                break;
                            case "user":
                                // Detect this article element.
                                Console.WriteLine("Start <user> element.");
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                if (attribute != null)
                                {
                                    Console.WriteLine("  Has attribute name: " + attribute);
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                            case "name":
                                Console.WriteLine("Start <name> element.");
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
