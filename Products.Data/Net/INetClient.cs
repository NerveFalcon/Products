namespace Products.Data.Net;

public interface INetClient
{
    Task SendAsync(byte[] message);
}
