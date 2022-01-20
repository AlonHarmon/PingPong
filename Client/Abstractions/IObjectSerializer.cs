using System;

namespace Client.Abstractions
{
    public interface IObjectSerializer
    {
         string Serialize(Type objectType, Object objectToSerialize);
         Object Deserialize(Type objectType, string objectToDeserialize);
    }
}