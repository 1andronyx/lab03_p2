using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Car car)
        {
            return Equals(car);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (Name, Engine, MaxSpeed).GetHashCode();
    }
}

public class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    // Индексатор
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                throw new IndexOutOfRangeException("Invalid index");

            return $"{cars[index].Name} (Engine: {cars[index].Engine})";
        }
    }

    public int Count => cars.Count;
}

class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();

        catalog.AddCar(new Car("Toyota Camry", "V6", 240));
        catalog.AddCar(new Car("Audi A8", "W12", 220));
        catalog.AddCar(new Car("Toyota Land Cruiser", "V8", 260));

        for (int i = 0; i < catalog.Count; i++)
        {
            Console.WriteLine(catalog[i]);
        }

        Car car1 = new Car("Toyota Camry", "V6", 240);
        Car car2 = new Car("Toyota Camry", "V6", 240);
        Console.WriteLine($"Are cars equal? {car1.Equals(car2)}");
    }
}
