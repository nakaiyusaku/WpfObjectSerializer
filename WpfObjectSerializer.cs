using System;
using System.Text;
using System.Windows.Markup;
using System.Xml;

namespace WpfObjectSerializer
{
    public static class WpfObjectSerializer
    {
        public static string Serialize( object obj )
        {
            // Prepare setting.
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = false;
            settings.ConformanceLevel = ConformanceLevel.Fragment;

            // Start serialization.
            var output = new StringBuilder();
            using( XmlWriter writer = XmlWriter.Create( output, settings ) )
            {
                try
                {
                    // Serialize.
                    var manager = new XamlDesignerSerializationManager( writer );
                    manager.XamlWriterMode = XamlWriterMode.Expression;
                    XamlWriter.Save( obj, manager );
                }
                catch( Exception ) { throw; }
            }

            // Output.
            return output.ToString();
        }

        public static object Deserialize( string xamlText )
        {
            // Deserialize.
            object obj = null;
            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml( xamlText );
                obj = XamlReader.Load( new XmlNodeReader( xmlDocument ) );
            }
            catch( Exception ) { throw; }

            // Output.
            return obj;
        }
    }
}
