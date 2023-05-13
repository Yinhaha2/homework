using System;
using System.Collections.Generic;
using System.Linq;
namespace OrderApplication
{

    public class Program
    {
        static void Main(string[] args)
        {
            OrderService orders = new OrderService();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Input 1 to add order, Input 2 to remove order, " +
                    "Input 3 to search order, Input 4 to show order, Input 5 to quit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        orders.addOrder();
                        break;
                    case "2":
                        orders.removeOrder();
                        break;
                    case "3":
                        Console.WriteLine("Input 1 to search orders in money " +
                            "Input 2 to search orders in customer");
                        break;
                    case "4":
                        orders.showOrders();
                        break;
                    case "5":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Input error! Please input the choose again!");
                        break;


                }
            }
        }
    }


    public interface IOrderService
    {
        void addOrder();
        void removeOrder();
        void searchOrder(int i);
        void showOrders();
    }
    public class OrderDetails
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int number;
        public int Number { get { return number; } set { number = value; } }
        private double price;
        public double Price { get { return price; } set { price = value; } }

        public OrderDetails()
        {
            this.Name = string.Empty;
            this.Number = 0;
            this.Price = 0;
        }

        public OrderDetails(string name, int number, double price)
        {
            this.Name = name;
            this.Number = number;
            this.Price = price;
        }

        public double getAllPrice()
        {
            return this.price * this.number;
        }

    }

    public class Order : IComparable
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Date { get; set; }
        public double Money { get; set; }

        public List<OrderDetails> orderDetails = new List<OrderDetails>();


        public Order()
        {
            this.Id = 0;
            this.Customer = string.Empty;
            this.Date = string.Empty;
            this.Money = 0;
        }

        public Order(int id, string customer, string date)
        {
            this.Id = id;
            this.Customer = customer;
            this.Date = date;
            this.Money = 0;
        }

        public void setMoney()
        {
            double money = 0;
            foreach (OrderDetails details in orderDetails)
            {
                money += details.getAllPrice();
            }
            this.Money = money;
        }

        public void addOrderDetails(string name, int number, double price)
        {
            OrderDetails details = new OrderDetails(name, number, price);
            this.orderDetails.Add(details);
        }

        public void removeOrderDetails()
        {
            Console.WriteLine("Please intput the id of the orderdetails to remove:");
            int id = Convert.ToInt32(Console.ReadLine());
            this.orderDetails.RemoveAt(id);
            Console.WriteLine("Remove successfully");
        }

        public void showOrderDetails()
        {
            foreach (OrderDetails details in this.orderDetails)
            {
                Console.WriteLine("Id Name Number Price");
                Console.WriteLine("{0} {1} {2} {3}",
                    this.orderDetails.IndexOf(details), details.Name, details.Number, details.Price);
            }
        }

        #region IComparable Members
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Order order = obj as Order;
                return this.Id.CompareTo(order?.Id);
            }
            else
                return -1;
        }

        public override bool Equals(object obj)
        {
            Order order = (obj as Order);
            return this.Id.Equals(order?.Id);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Id);
        }


    }



    public class OrderService : IOrderService
    {
        public List<Order> orders = new List<Order>();

        public OrderService() { }



        public void addOrder()
        {
            try
            {
                Console.WriteLine("Please input the id of the order:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please input the customer of the order:");
                string customer = Console.ReadLine();
                Console.WriteLine("Please input the date of the order:");
                string date = Console.ReadLine();
                Order order = new Order(id, customer, date);

                bool judge = true;
                bool same = false;
                foreach (Order o in orders)
                {
                    if (o.Equals(order))
                        same = true;
                }
                if (same)
                {
                    Console.WriteLine("Input error!");
                }
                else
                {
                    Console.WriteLine("Please follow the steps to add the item of the order:");
                    while (judge && !same)
                    {
                        Console.WriteLine("Please input the name of the item:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please input the number of the item:");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please input the price of the item:");
                        double price = Convert.ToDouble(Console.ReadLine());
                        order.addOrderDetails(name, number, price);
                        Console.WriteLine("Continue to add the item or not?");
                        string x = Console.ReadLine();
                        if (x == "yes" || x == "Yes")
                            judge = true;
                        else
                            judge = false;
                    }
                    orders.Add(order);
                    order.setMoney();
                    Console.WriteLine("Buile the new order successfully!");
                }

            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }

        public void removeOrder()
        {
            try
            {
                Console.WriteLine("Input the id of the order to remove:");
                int id = Convert.ToInt32(Console.ReadLine());
                int index = 0;
                foreach (Order order in orders)
                {
                    if (order.Id == id)
                        index = this.orders.IndexOf(order);
                }
                this.orders[index].showOrderDetails();
                this.orders[index].removeOrderDetails();
                this.orders.RemoveAt(index);
                Console.WriteLine("Remove successfully!");
            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }

        public void searchOrder(int i)
        {
            try
            {
                switch (i)
                {
                    case 1:
                        int min, max;
                        Console.WriteLine("Input the mininum money to query:");
                        min = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input the maxinum money to query:");
                        max = Convert.ToInt32(Console.ReadLine());

                        var queryInMoney = from order in this.orders
                                           where order.Money >= min && order.Money <= max
                                           orderby order.Money descending
                                           select order;
                        List<Order> orderQueryInMoney = queryInMoney.ToList();
                        foreach (Order order in orderQueryInMoney)
                        {
                            Console.WriteLine("Id Customer Date Money");
                            Console.WriteLine("{0} {1} {2} {3}",
                                order.Id, order.Customer, order.Date, order.Money);
                            order.showOrderDetails();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Input the customer to query");
                        string customer = Console.ReadLine();

                        var queryInCustomer = from order in this.orders
                                              where order.Customer == customer
                                              orderby order.Money
                                              select order;
                        List<Order> orderQueryInCustomer = queryInCustomer.ToList();
                        foreach (Order order in orderQueryInCustomer)
                        {
                            Console.WriteLine("Id Customer Date Money");
                            Console.WriteLine("{0} {1} {2} {3}",
                                order.Id, order.Customer, order.Date, order.Money);
                            order.showOrderDetails();
                        }
                        break;
                    default:
                        Console.WriteLine("Input error!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Input error!");
            }
        }

        public void showOrders()
        {
            foreach (var order in orders)
            {
                Console.WriteLine("Id Customer Date Money");
                Console.WriteLine("{0} {1} {2} {3}",
                    order.Id, order.Customer, order.Date, order.Money);
                order.showOrderDetails();
            }
        }
    }


}
#endregion