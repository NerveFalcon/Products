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
		if (Count == Capacity)
		{
			Console.WriteLine($"Not added. Count: {Count}");
			return false;
		}
		var prod = new Product(isGood);
		Conveyor.Enqueue(prod);
		Count++;
		Console.WriteLine($"Add {prod.IsGood}. Count: {Count}");
		return true;
	}

	public bool TryRemove()
	{
		if (Count == 0)
		{
			Console.WriteLine($"Not Remove. Count: {Count}");
			return false;
		}

		var deleted = Conveyor.Dequeue();
		Count--;
		Console.WriteLine($"Remove {deleted.IsGood}. Count: {Count}");
		return true;
	}

	public Product[] GetSnapshot() => Conveyor.Reverse().ToArray();
}
