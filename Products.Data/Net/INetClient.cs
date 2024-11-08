namespace Products.Data.Net;

public interface INetClient
{
    Task<byte[]> SendAsync(byte[] message);
    Task SendVoidAsync(byte[] message);
}
