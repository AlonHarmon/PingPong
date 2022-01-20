namespace Client.Abstractions
{
    public interface IObjectInput<T>
    {
        T Receive();
    }
}