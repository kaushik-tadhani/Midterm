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
        Console.WriteLine(string.Format("{0, -20} | {1, -10} | {2, -10} | {3, -15}", ItemName, ItemId, Price, QuantityInStock));
    }
}

/// <summary>
/// InventoryManager to manage inventory items.
/// </summary>
public class InventoryManager 
{
    // Private fields to store the array of InventoryItem objects and the count of items.
    private InventoryItem[] items = new InventoryItem[10];
    private int itemCount = 0;

    /// <summary>
    /// Method to add an inventory item to the inventory manager.
    /// </summary>
    /// <param name="inventoryItem">Inventory item class object</param>
    public void AddItems(InventoryItem inventoryItem)
    {
        items[itemCount++] = inventoryItem;
    }

    /// <summary>
    /// Method to print details of all items in the inventory.
    /// </summary>
    public void PrintAllItems()
    {
        // Print a header for the inventory details.
        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine(string.Format("{0, -20} | {1, -10} | {2, -10} | {3, -15}", "ItemName", "ItemId", "Price", "QuantityInStock"));
        Console.WriteLine("------------------------------------------------------------------");

        // Loop through each item and print its details.
        for (int i = 0; i < itemCount; i++)
        {
            items[i].PrintDetails();
        }

        // Print a footer for the inventory details.
        Console.WriteLine("------------------------------------------------------------------");
    }

    /// <summary>
    /// Method to update the price of an item given its ID.
    /// </summary>
    /// <param name="itemId">Inventory item id</param>
    /// <param name="newPrice">New price for the inventory item</param>
    public void UpdateItemPrice(int itemId, double newPrice)
    {
        // Loop through items to find the item with the given ID.
        for (int i = 0; i < itemCount; i++)
        {
            // If the item ID matches, update its price and exit the loop.
            if (items[i].ItemId == itemId)
            {
                items[i].UpdatePrice(newPrice);
                break;
            }
        }
    }

    /// <summary>
    /// Method to sell a quantity of an item given its ID.
    /// </summary>
    /// <param name="itemId">Inventory item id</param>
    /// <param name="quantity">Quantity for sell</param>
    public void SellItem(int itemId, int quantity)
    {
        // Loop through items to find the item with the given ID.
        for (int i = 0; i < itemCount; i++)
        {
            // If the item ID matches, sell the specified quantity of the item and exit the loop.
            if (items[i].ItemId == itemId)
            {
                items[i].SellItem(quantity);
                break;
            }
        }
    }

    /// <summary>
    /// Method to restock a quantity of an item given its ID.
    /// </summary>
    /// <param name="itemId">Inventory item id</param>
    /// <param name="quantity">Quantity for restock</param>
    public void RestockItem(int itemId, int quantity)
    {
        // Loop through items to find the item with the given ID.
        for (int i = 0; i < itemCount; i++)
        {
            // If the item ID matches, restock the specified quantity of the item and exit the loop.
            if (items[i].ItemId == itemId)
            {
                items[i].RestockItem(quantity);
                break;
            }
        }
    }

    /// <summary>
    /// Method to check the stock availability of an item given its ID.
    /// </summary>
    /// <param name="itemId">Inventory item id</param>
    public void CheckStockAvailability(int itemId)
    {
        // Loop through items to find the item with the given ID.
        for (int i = 0; i < itemCount; i++)
        {
            // If the item ID matches, check if it's in stock and print a message accordingly.
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
                break;
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
