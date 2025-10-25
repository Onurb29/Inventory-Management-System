using System;
using System.Collections.Generic;

class InventoryManagementSystem
{
    static List<string> inventory = new List<string>();
    // false representing pinning tasks and true representing completed tasks.
    static List<bool> availability = new List<bool>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. View Inventory");
            Console.WriteLine("4. Update Availability");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddItem();
                    break;
                case "2":
                    RemoveItem();
                    break;
                case "3":
                    ViewInventory();
                    break;
                case "4":
                    UpdateAvailability();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to add new product to inventory
    static void AddItem()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();
        Console.Write("Enter item price: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Enter item quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        inventory.Add($"{name} - Price: {price} - Quantity: {quantity}");
        availability.Add(true); // Item is available
        Console.WriteLine("Item added successfully.");
    }

    // Method to remove product from inventory
    static void RemoveItem()
    {
        Console.Write("Enter the item name to remove: ");
        string name = Console.ReadLine();
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].StartsWith(name))
            {
                inventory.RemoveAt(i);
                availability.RemoveAt(i);
                Console.WriteLine("Item removed successfully.");
                return;
            }
        }
        Console.WriteLine("Item not found.");
    }

    // Method to view current inventory
    static void ViewInventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            string status = availability[i] ? "Available" : "Out of Stock";
            Console.WriteLine($"{i + 1}. {inventory[i]} - Status: {status}");
        }
    }

    // Method to update item availability
    static void UpdateAvailability()
    {
        Console.Write("Enter the item number to update availability: ");
        int itemNumber = int.Parse(Console.ReadLine());
        if (itemNumber > 0 && itemNumber <= availability.Count)
        {
            availability[itemNumber - 1] = !availability[itemNumber - 1];
            Console.WriteLine("Item availability updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid item number.");
        }
    }
}

