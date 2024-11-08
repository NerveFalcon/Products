namespace Products.Data.Net;

public interface INetClient
{
    Task SendAsync(byte[] message);
    Task SendAsync(string message);
}
