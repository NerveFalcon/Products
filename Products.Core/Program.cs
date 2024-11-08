﻿// See https://aka.ms/new-console-template for more information
using Products.Core;
using Products.Data.Net;

using System.Text;

Console.WriteLine("Hello, World!");
var prodService = new ProductService(5);
var server = new NetService();

server.AddHandler(Commands.AddProductGood, AddGood);
server.AddHandler(Commands.AddProductBad, AddBad);
server.AddHandler(Commands.RemoveProduct, Remove);
server.AddHandler(Commands.GetProducts, GetProducts);

#region Arrange
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
#endregion

var serverTask = server.StartListenAsync();


#region Funcs
byte[] AddGood() => Add(true);
byte[] AddBad() => Add(false);

byte[] Add(bool isGood)
{
	var res = prodService.TryAdd(isGood);

	return Encoding.UTF8.GetBytes(res ? Results.Added : Results.NotAdded);
}

byte[] Remove()
{
	var res = prodService.TryRemove();

	return Encoding.UTF8.GetBytes(res ? Results.Removed : Results.NotRemoved);
}

byte[] GetProducts()
{
	var prods = prodService.GetSnapshot();

	var res = string.Join(",", prods.Select(p => p.IsGood ? "Good" : "Bad").Prepend(Results.List));

	return Encoding.UTF8.GetBytes(res);
}
#endregion