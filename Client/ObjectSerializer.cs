using System.Security.AccessControl;
using System;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace Client
{
    public class ObjectSerializer
    {
        public string Serialize(Type objectType, Object objectToSerialize)
        {
            XmlSerializer ser = new XmlSerializer(objectType);
            TextWriter stringWriter = new StringWriter();

            ser.Serialize(stringWriter, objectToSerialize);

            return stringWriter.ToString();
        }

        public Object Deserialize(Type objectType, string objectToDeserialize)
        {
            XmlSerializer ser = new XmlSerializer(objectType);
            Stream stream = new MemoryStream();

            stream.Write(Encoding.ASCII.GetBytes(objectToDeserialize), 0, objectToDeserialize.Length);

            return ser.Deserialize(stream);
        }

    }
}