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
            while(fail)
            {
                try
                {
                    orderStart = Convert.ToDateTime(orderDate);
                    fail = false;
                }
                catch (InvalidCastException)
                {
                    fail = true;
                    writer.Write("Что-то пошло не так... Попробуйте еще раз ввести дату начала заказа");
                    reader.ReadLine();
                    writer.Write("Введите дату начала заказа (дд.мм.гггг): ");
                    orderDate = reader.ReadLine();
                }
            }

            writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
            DateTime orderEnd = new DateTime();
            orderDate = reader.ReadLine();
            fail = true;
            while (fail)
            {
                try
                {
                    fail = false;
                    orderEnd = Convert.ToDateTime(orderDate);
                    if (orderEnd < orderStart)
                        throw new InvalidDataException();
                }
                catch (InvalidCastException)
                {
                    fail = true;
                    writer.Write("Что-то пошло не так... Попробуйте еще раз ввести дату планируемого окончания заказа");
                    reader.ReadLine();
                    writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
                    orderDate = reader.ReadLine();
                }
                catch(InvalidDataException)
                {
                    fail = true;
                    writer.Write("Дата окончания должна быть больше, чем дата начала");
                    reader.ReadLine();
                    writer.Write("Введите дату планируемого окончания заказа (дд.мм.гггг): ");
                    orderDate = reader.ReadLine();
                }
            }
            

            int days = (int)orderEnd.Subtract(orderStart).TotalDays;
            int cost = days * 100;

            writer.Write("Введите дату фактического окончания заказа (дд.мм.гггг или ничего): ");
            DateTime orderFact = new DateTime();
            orderDate = reader.ReadLine();
            bool isOrderEnd = false;
            int surcharge = 0;
            if (!string.IsNullOrWhiteSpace(orderDate))
            {
                fail = true;
                isOrderEnd = true;
                while (fail)
                {
                    try
                    {
                        fail = false;
                        orderFact = Convert.ToDateTime(orderDate);
                        if (orderFact < orderStart)
                            throw new InvalidDataException();
                    }
                    catch (InvalidCastException)
                    {
                        fail = true;
                        writer.Write("Что-то пошло не так... Попробуйте еще раз ввести дату фактического окончания заказа");
                        reader.ReadLine();
                        writer.Write("Введите дату фактического окончания заказа (дд.мм.гггг): ");
                        orderDate = reader.ReadLine();
                    }
                    catch (InvalidDataException)
                    {
                        fail = true;
                        writer.Write("Дата окончания должна быть больше, чем дата начала");
                        reader.ReadLine();
                        writer.Write("Введите дату фактического окончания заказа (дд.мм.гггг): ");
                        orderDate = reader.ReadLine();
                    }
                }

                days = (int)orderEnd.Subtract(orderFact).TotalDays;
                if (days > 0)
                    surcharge = days * 50;
            }

            if (isOrderEnd)
                return new Order { Cost = cost, OrderStart = orderStart, OrderEnd = orderEnd, OrderFactEnd = orderFact, Surcharge = surcharge };

            return new Order { Cost = cost, OrderStart = orderStart, OrderEnd = orderEnd, Surcharge = surcharge };
        }
    }
}
