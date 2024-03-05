using System.Diagnostics;

public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemId = itemId;
        ItemName = itemName;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // TODO: Update the item's price with the new price.
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // TODO: Increase the item's stock quantity by the additional quantity.
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // TODO: Decrease the item's stock quantity by the quantity sold.
        // Make sure the stock doesn't go negative.
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // TODO: Return true if the item is in stock (quantity > 0), otherwise false.

        return false;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine(string.Format("{0, -20} {1, -10} {2, -10} {3, -5}", ItemName, ItemId, Price, QuantityInStock));
    }
}
class Program
{
    static void Main(string[] args)
    {

        InventoryItem[] inventoryItems = new InventoryItem[] 
        {
            new InventoryItem("Laptop", 101, 1200.50, 10),
            new InventoryItem("Smartphone", 102, 800.30, 15)
        };

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 1. Print details of all items.

        Console.WriteLine(string.Format("{0, -20} {1, -10} {2, -10} {3, -5}", "ItemName", "ItemId", "Price", "QuantityInStock"));
        Console.WriteLine("----------------------------------------------------------");
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            inventoryItems[i].PrintDetails();
        }

        // 2. Sell some items and then print the updated details.
        // 3. Restock an item and print the updated details.
        // 4. Check if an item is in stock and print a message accordingly.


    }
}
