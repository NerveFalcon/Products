using Products.Data;

namespace Products.Core;

public class ProductService : IProductService
{
	public int Capacity { get; }
	public int Count { get; private set; }

	private Queue<Product> Conveyor { get; set; }

	public ProductService(int capacity)
	{
		ArgumentNullException.ThrowIfNull(capacity);
		ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(capacity, 0);

		Capacity = capacity;
		Conveyor = new (capacity);
	}

	public bool TryAdd(bool isGood)
	{
		if (Count == Capacity) return false;

		Conveyor.Enqueue(new(isGood));
		Count++;
		return true;
	}

	public bool TryRemove()
	{
		if (Count == 0) return false;

		_ = Conveyor.Peek();
		Count--;
		return true;
	}
}
