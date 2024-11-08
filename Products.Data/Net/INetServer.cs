namespace Products.Data.Net;

public interface INetServer
{
    void AddHandler(string command, Func<byte[]> handler);
    void AddVoidHandler(string command, Action handler)
        => AddHandler(command, () => { handler.Invoke(); return [0]; });

    void RemoveHandler(string command);

    Task StartListenAsync();
}
