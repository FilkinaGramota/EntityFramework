using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestEFCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime OrderEnd { get; set; }
        public DateTime OrderFactEnd { get; set; }
        public int Surcharge { get; set; }

        public Client Client { get; set; }
        public IList<OrderCassette> OrderCassettes { get; set; }

        public Order()
        {
            OrderCassettes = new List<OrderCassette>();
        }

        //saving data for many-to-many
        public void AddCassette(Cassette cassette)
        {
            // можно это всё и в конструкторе OrderCassette прописать
            var orderCassettes = new OrderCassette();
            orderCassettes.Cassette = cassette;
            orderCassettes.Order = this;
            OrderCassettes.Add(orderCassettes);
        }

        // close order and compute surcharge
        public void Close(DateTime orderFactEnd)
        {
            OrderFactEnd = orderFactEnd;
            int days = (int)OrderEnd.Subtract(orderFactEnd).TotalDays;
            if (days > 0)
                Surcharge = days * 50;
        }

        public Order ReadData(TextReader reader, TextWriter writer)
        {
            if (reader == null)
                reader = Console.In;
            if (writer == null)
                writer = Console.Out;

            writer.WriteLine("\t Введите данные о заказе");
            writer.Write("Введите дату начала заказа (дд.мм.гггг): ");
            DateTime orderStart = new DateTime();
            string orderDate = reader.ReadLine();
            bool fail = true;
            
            while(!DateTime.TryParse(orderDate, out orderStart))
            {
                writer.Write("Что-то пошло не так... Попробуйте еще раз ввести дату начала заказа");
                reader.ReadLine();
                writer.Write("Введите дату начала заказа (дд.мм.гггг): ");
                orderDate = reader.ReadLine();
            }

            writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
            DateTime orderEnd = new DateTime();
            orderDate = reader.ReadLine();
            fail = true;
            while (fail)
            {
                if (DateTime.TryParse(orderDate, out orderEnd))
                {
                    if (orderEnd < orderStart)
                    {
                        writer.Write("Дата окончания должна быть больше, чем дата начала");
                        reader.ReadLine();
                        writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
                        orderDate = reader.ReadLine();
                    }
                    else
                        fail = false;
                }
                else
                {
                    writer.Write("Что-то пошло не так... Попробуйте еще раз ввести дату планируемого окончания заказа");
                    reader.ReadLine();
                    writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
                    orderDate = reader.ReadLine();

                }
            }
            
            int days = (int)orderEnd.Subtract(orderStart).TotalDays;
            int cost = days * 100;

            return new Order { Cost = cost, OrderStart = orderStart, OrderEnd = orderEnd};
        }
    }
}
