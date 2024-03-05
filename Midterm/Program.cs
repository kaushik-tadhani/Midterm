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
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        if (QuantityInStock >= quantitySold)
        {
            QuantityInStock -= quantitySold;
        }
        else
        {
            Console.WriteLine("Not enough stock available for {0}.", ItemName);
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Print item details
    public void PrintDetails()
    {
        Console.WriteLine(string.Format("{0, -20} {1, -10} {2, -10} {3, -5}", ItemName, ItemId, Price, QuantityInStock));
    }
}

public class InventoryManager 
{
    private InventoryItem[] items = new InventoryItem[10];
    private int itemCount = 0;

    public void AddItems(InventoryItem inventoryItem)
    {
        items[itemCount++] = inventoryItem;
    }

    public void PrintAllItems()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine(string.Format("{0, -20} {1, -10} {2, -10} {3, -5}", "ItemName", "ItemId", "Price", "QuantityInStock"));
        Console.WriteLine("----------------------------------------------------------");
        for (int i = 0; i < itemCount; i++)
        {
            items[i].PrintDetails();
        }
        Console.WriteLine("----------------------------------------------------------");
    }

    public void UpdateItemPrice(int itemId, double newPrice)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].ItemId == itemId)
            {
                items[i].UpdatePrice(newPrice);
                break;
            }
        }
    }

    public void SellItem(int itemId, int quantity)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].ItemId == itemId)
            {
                items[i].SellItem(quantity);
                break;
            }
        }
    }

    public void RestockItem(int itemId, int quantity)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].ItemId == itemId)
            {
                items[i].RestockItem(quantity);
                break;
            }
        }
    }

    public void CheckStockAvailability(int itemId)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (items[i].ItemId == itemId)
            {
                if (items[i].IsInStock())
                {
                    Console.WriteLine("{0} is in stock.", items[i].ItemName);
                }
                else
                {
                    Console.WriteLine("{0} is out of stock.", items[i].ItemName);
                }
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        InventoryManager inventoryManager = new InventoryManager();

        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        
        inventoryManager.AddItems(item1);
        inventoryManager.AddItems(item2);

        // TODO: Implement logic to interact with these objects.
        // Example tasks:
        // 1. Print details of all items.
        Console.WriteLine("Initial inventory details: ");
        inventoryManager.PrintAllItems();

        
        inventoryManager.UpdateItemPrice(101, 1400.25);
        Console.WriteLine("\n\nInventory details after price update for laptop: ");
        inventoryManager.PrintAllItems();

        // 2. Sell some items and then print the updated details.
        Console.WriteLine("\n\nInventory details after 3 laptops sold and try to sell 16 smartphones: \n");

        inventoryManager.SellItem(101, 3);
        inventoryManager.SellItem(102, 16);
        inventoryManager.PrintAllItems();

        Console.WriteLine("\n\nInventory details after 15 smartphones sold: ");
        inventoryManager.SellItem(102, 15);
        inventoryManager.PrintAllItems();

        // 3. Restock an item and print the updated details.
        Console.WriteLine("\n\nInventory details after restock for laptop: ");
        inventoryManager.RestockItem(101, 3);
        inventoryManager.PrintAllItems();

        // 4. Check if an item is in stock and print a message accordingly.
        Console.WriteLine("\n\nStock availability checking for the laptop and smartphone: ");
        inventoryManager.CheckStockAvailability(101);
        inventoryManager.CheckStockAvailability(102);
    }
}
