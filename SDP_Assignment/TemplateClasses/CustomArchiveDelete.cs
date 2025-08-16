// using ConsoleApp1;
// using System;
// using System.Collections.Generic;

// public class CustomArchiveDelete : Archive
// {
//     public CustomArchiveDelete(List<Order> initialOrders) : base(initialOrders) { }

//     public override void DeleteOldOrders(DateTime d)
//     {
//         DateTime threshold = d.AddMonths(-12); // Custom logic
//         foreach (var order in orders)
//         {
//             if (order.Date < threshold)
//             {
//                 order.Status = Order.State.Deleted;
//             }
//         }
//     }

//     public override void DisplayArchived()
//     {
//         base.DisplayArchived();
//     }
// }
