using System;
using System.Collections.Generic;

namespace CarSharing
{
    public class User
    {
        protected int userId;
        protected string name;
        protected string licenseNumber;
        protected double rating;

        public User(int userId, string name, string licenseNumber)
        {
            this.userId = userId;
            this.name = name;
            this.licenseNumber = licenseNumber;
            this.rating = 5.0;
        }

        public int UserId { get { return userId; } }
        public string Name { get { return name; } }
        public string LicenseNumber { get { return licenseNumber; } }
        public double Rating { get { return rating; } }

        public virtual string GetUserInfo()
        {
            return $"ID: {userId}, Имя: {name}, Лицензия: {licenseNumber}, Рейтинг: {rating:F1}";
        }

        public void UpdateRating(double newRating)
        {
            if (newRating >= 1.0 && newRating <= 5.0)
            {
                rating = (rating + newRating) / 2;
            }
        }
    }

    public class PremiumUser : User
    {
        private decimal discount;
        private int bonusPoints;

        public PremiumUser(int userId, string name, string licenseNumber, decimal discount)
            : base(userId, name, licenseNumber)
        {
            this.discount = discount;
            this.bonusPoints = 0;
        }

        public decimal Discount { get { return discount; } }
        public int BonusPoints { get { return bonusPoints; } }

        public override string GetUserInfo()
        {
            return base.GetUserInfo() + $", Скидка: {discount:P0}, Бонусы: {bonusPoints}";
        }

        public void AddBonus(int points)
        {
            bonusPoints += points;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount * (1 - discount);
        }
    }

    public class Vehicle
    {
        protected int vehicleId;
        protected string brand;
        protected string model;
        protected int year;
        protected decimal pricePerHour;
        protected bool isAvailable;

        public Vehicle(int vehicleId, string brand, string model, int year, decimal pricePerHour)
        {
            this.vehicleId = vehicleId;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.pricePerHour = pricePerHour;
            this.isAvailable = true;
        }

        public int VehicleId { get { return vehicleId; } }
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }
        public int Year { get { return year; } }
        public decimal PricePerHour { get { return pricePerHour; } }
        public bool IsAvailable { get { return isAvailable; } }

        public virtual string GetVehicleInfo()
        {
            string status = isAvailable ? "Доступен" : "Занят";
            return $"ID: {vehicleId}, {brand} {model} ({year}), Цена: {pricePerHour} руб/час, Статус: {status}";
        }

        public void Rent()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"{brand} {model} арендован.");
            }
            else
            {
                Console.WriteLine($"{brand} {model} уже арендован.");
            }
        }

        public void Return()
        {
            isAvailable = true;
            Console.WriteLine($"{brand} {model} возвращен.");
        }
    }

    public class ElectricCar : Vehicle
    {
        private double batteryLevel;
        private int range;

        public ElectricCar(int vehicleId, string brand, string model, int year,
                          decimal pricePerHour, int range)
            : base(vehicleId, brand, model, year, pricePerHour)
        {
            this.batteryLevel = 100.0;
            this.range = range;
        }

        public double BatteryLevel { get { return batteryLevel; } }
        public int Range { get { return range; } }

        public override string GetVehicleInfo()
        {
            return base.GetVehicleInfo() + $", Батарея: {batteryLevel:F1}%, Запас хода: {range}км";
        }

        public void Charge(double amount)
        {
            if (amount > 0)
            {
                batteryLevel = Math.Min(100.0, batteryLevel + amount);
                Console.WriteLine($"{brand} {model} заряжен до {batteryLevel:F1}%");
            }
        }

        public string GetBatteryInfo()
        {
            if (batteryLevel > 80) return "Высокий уровень заряда";
            else if (batteryLevel > 30) return "Средний уровень заряда";
            else return "Низкий уровень заряда - требуется зарядка";
        }
    }

    public class Reservation
    {
        private static int nextId = 1;
        private int reservationId;
        private int userId;
        private int vehicleId;
        private DateTime startDate;
        private DateTime endDate;
        private decimal totalCost;

        public Reservation(int userId, int vehicleId, DateTime startDate, DateTime endDate)
        {
            this.reservationId = nextId++;
            this.userId = userId;
            this.vehicleId = vehicleId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalCost = 0;
        }

        public int ReservationId { get { return reservationId; } }
        public int UserId { get { return userId; } }
        public int VehicleId { get { return vehicleId; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }
        public decimal TotalCost { get { return totalCost; } }

        public decimal CalculateCost(decimal pricePerHour)
        {
            TimeSpan duration = endDate - startDate;
            double hours = duration.TotalHours;
            totalCost = pricePerHour * (decimal)hours;
            return totalCost;
        }

        public string GetReservationInfo()
        {
            return $"Бронирование #{reservationId}: Пользователь {userId}, ТС {vehicleId}, " +
                   $"С {startDate:dd.MM.yyyy HH:mm} по {endDate:dd.MM.yyyy HH:mm}, " +
                   $"Стоимость: {totalCost} руб";
        }
    }

    public class Payment
    {
        private static int nextId = 1;
        private int paymentId;
        private int reservationId;
        private decimal amount;
        private string status;

        public Payment(int reservationId, decimal amount)
        {
            this.paymentId = nextId++;
            this.reservationId = reservationId;
            this.amount = amount;
            this.status = "Ожидает оплаты";
        }

        public int PaymentId { get { return paymentId; } }
        public int ReservationId { get { return reservationId; } }
        public decimal Amount { get { return amount; } }
        public string Status { get { return status; } }

        public bool ProcessPayment()
        {
            if (amount > 0)
            {
                status = "Оплачено";
                Console.WriteLine($"Платеж #{paymentId} на сумму {amount} руб успешно обработан.");
                return true;
            }
            else
            {
                status = "Ошибка";
                Console.WriteLine("Ошибка: неверная сумма платежа.");
                return false;
            }
        }

        public string GetPaymentInfo()
        {
            return $"Платеж #{paymentId}: Бронирование {reservationId}, " +
                   $"Сумма: {amount} руб, Статус: {status}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("СИСТЕМА КАРШЕРИНГА\n");

            User user1 = new User(1, "Иван Петров", "AB123456");
            PremiumUser premiumUser = new PremiumUser(2, "Анна Сидорова", "CD789012", 0.1m);

            Vehicle car1 = new Vehicle(101, "Toyota", "Corolla", 2022, 250m);
            ElectricCar electricCar = new ElectricCar(102, "Tesla", "Model 3", 2023, 400m, 450);

            DateTime start = DateTime.Now;
            DateTime end = start.AddHours(3);
            Reservation reservation1 = new Reservation(user1.UserId, car1.VehicleId, start, end);

            decimal cost = reservation1.CalculateCost(car1.PricePerHour);
            Console.WriteLine($"Стоимость бронирования: {cost} руб");

            Payment payment = new Payment(reservation1.ReservationId, cost);
            payment.ProcessPayment();

            car1.Rent();

            Console.WriteLine("\nИНФОРМАЦИЯ О ПОЛЬЗОВАТЕЛЯХ");
            Console.WriteLine(user1.GetUserInfo());
            Console.WriteLine(premiumUser.GetUserInfo());

            Console.WriteLine("\nИНФОРМАЦИЯ О ТРАНСПОРТЕ");
            Console.WriteLine(car1.GetVehicleInfo());
            Console.WriteLine(electricCar.GetVehicleInfo());

            Console.WriteLine("\n ИНФОРМАЦИЯ О БРОНИРОВАНИИ ");
            Console.WriteLine(reservation1.GetReservationInfo());

            Console.WriteLine("\n ИНФОРМАЦИЯ О ПЛАТЕЖЕ ");
            Console.WriteLine(payment.GetPaymentInfo());

            Console.WriteLine("\n РАБОТА С ЭЛЕКТРОМОБИЛЕМ ");
            electricCar.Charge(25.5);
            Console.WriteLine(electricCar.GetBatteryInfo());

            Console.WriteLine("\n ВОЗВРАТ АВТОМОБИЛЯ ");
            car1.Return();

            Console.WriteLine("\nОБНОВЛЕНИЕ РЕЙТИНГА ");
            user1.UpdateRating(4.5);
            Console.WriteLine($"Новый рейтинг пользователя: {user1.Rating:F1}");

            Console.WriteLine("\n БОНУСЫ ПРЕМИУМ ПОЛЬЗОВАТЕЛЯ");
            premiumUser.AddBonus(100);
            decimal discountedPrice = premiumUser.ApplyDiscount(1000m);
            Console.WriteLine($"Цена со скидкой: {discountedPrice} руб");
            Console.WriteLine(premiumUser.GetUserInfo());

            Console.WriteLine("\nПрограмма завершена успешно!");
        }
    }
}