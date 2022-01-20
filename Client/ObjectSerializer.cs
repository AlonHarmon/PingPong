using System.Net.Http;
using System.Security.AccessControl;
using System;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Client.Abstractions;

namespace Client
{
    public class ObjectSerializer : IObjectSerializer
    {
        public string Serialize<T>(T objectToSerialize)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            StringWriter stringWriter = new StringWriter();

            ser.Serialize(stringWriter, objectToSerialize);

            return stringWriter.ToString();
        }

        public T Deserialize<T>(string objectToDeserialize)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(objectToDeserialize);

            return (T) ser.Deserialize(reader);
        }

    }
}