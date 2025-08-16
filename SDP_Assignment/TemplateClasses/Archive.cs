using ConsoleApp1;
using System;
using System.Collections.Generic;

public class Archive
{
    protected List<Order> orders;

    public Archive() { }

    public Archive(List<Order> initialOrders)
    {
        orders = initialOrders;
    }

    public void addOrder(Order order)
    {
        orders.Add(order);
    }

    // Template method
    public void ProcessArchive(DateTime d)
    {
        DeleteOldOrders(d);
        DisplayArchived();
    }

    // Hook method: can be overridden
    public virtual void DisplayArchived()
    {
        int x = 1;
        foreach (var order in orders)
        {
            if (order.status == "archived")
            {
                Console.WriteLine($" {x}.[Archived] {order.OrderCreationDate}");
            }
            else
            {
                Console.WriteLine($"{x}. {order.OrderCreationDate}");
            }
            x++;
        }
    }

    // Hook method: can be overridden
    public virtual void DeleteOldOrders(DateTime d)
    {
        DateTime threshold = d.AddYears(-1);
        foreach (var order in orders)
        {
            if (order.OrderCreationDate < threshold)
            {
                order.status = "archived";
            }
        }
    }
}
