// See https://aka.ms/new-console-template for more information
using Products.Core;

Console.WriteLine("Hello, World!");

var prodService = new ProductService(5);

Add(true);
Add(false);
Add(true);
Add(false);
Add(false);
Add(true);
Add(true);
Add(true);
Add(true);
Add(false);
Add(true);


Remove();
Remove();
Remove();
Remove();

Add(false);
Add(true);
Add(true);

Remove();
Remove();
Remove();
Remove();
Remove();
Remove();
Remove();

void Add(bool isGood)
{
	if (prodService.TryAdd(isGood))
		Console.WriteLine($"Add {isGood}. Count: {prodService.Count}");
	else Console.WriteLine($"Not added. Count: {prodService.Count}");
}

void Remove()
{
	if (prodService.TryRemove())
		Console.WriteLine($"Remove one. Count: {prodService.Count}");
	else Console.WriteLine($"Not Remove. Count: {prodService.Count}");
}