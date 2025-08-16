// using System;

// namespace ConsoleApp1
// {
//     public class Order
//     {
//         public enum State
//         {
//             Ready,
//             Archived,
//             Deleted
//         }

//         public State Status { get; set; }
//         public DateTime Date { get; set; }

//         public Order(DateTime date)
//         {
//             Date = date;
//             Status = State.Ready;  // Orders start as 'Ready'
//         }
//         public void Collect()
//         { this.Status = State.Archived;}
//         }
//     }

