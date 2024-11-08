namespace Products.Data.Net;

public interface INetServer
{
	public const int Port = 32234;
	void AddHandler(string command, Func<byte[]> handler);
    void AddVoidHandler(string command, Action handler)
        => AddHandler(command, () => { handler.Invoke(); return [0]; });

    void RemoveHandler(string command);

    Task StartListenAsync();
}
