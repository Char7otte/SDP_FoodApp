using ConsoleApp1;
using System;
using System.Collections.Generic;

public class Archive
{
    protected List<Order> orders;

    public Archive(List<Order> initialOrders)
    {
        orders = initialOrders;
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
        foreach (var order in orders)
        {
            if (order.Status == Order.State.Archived)
            {
                Console.WriteLine($"[Archived] {order.Date}");
            }
        }
    }

    // Hook method: can be overridden
    public virtual void DeleteOldOrders(DateTime d)
    {
        DateTime threshold = d.AddYears(-1);
        foreach (var order in orders)
        {
            if (order.Date < threshold)
            {
                order.Status = Order.State.Deleted;
            }
        }
    }
}
