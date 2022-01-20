using System;

namespace Client.Abstractions
{
    public interface IObjectSerializer
    {
         string Serialize<T>(T objectToSerialize);
         T Deserialize<T>(string objectToDeserialize);
    }
}