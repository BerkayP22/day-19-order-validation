var products = new Dictionary<int, (string Name, int Stock, decimal Price)>
{
    [1] = ("Defter", 5, 40m),
    [2] = ("Kalem", 10, 12m)
};

try
{
    Console.Write("Ürün kodu: ");
    if (!int.TryParse(Console.ReadLine(), out int id)) throw new ArgumentException("Ürün kodu sayı olmalı.");
    if (!products.TryGetValue(id, out var product)) throw new KeyNotFoundException("Ürün bulunamadı.");
    Console.Write("Adet: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        throw new ArgumentException("Adet pozitif bir tam sayı olmalı.");
    if (quantity > product.Stock) throw new InvalidOperationException("Yeterli stok yok.");
    products[id] = (product.Name, product.Stock - quantity, product.Price);
    Console.WriteLine($"{product.Name}: {quantity} adet, toplam {quantity * product.Price:C}. Kalan stok: {products[id].Stock}");
}
catch (ArgumentException error) { Console.WriteLine(error.Message); }
catch (KeyNotFoundException error) { Console.WriteLine(error.Message); }
catch (InvalidOperationException error) { Console.WriteLine(error.Message); }
finally { Console.WriteLine("Sipariş denemesi tamamlandı."); }
