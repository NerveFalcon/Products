namespace Products.Data;

public interface IProductService
{
	bool TryAdd(bool isGood);
	bool TryRemove();
	Product[] GetSnapshot();
}
