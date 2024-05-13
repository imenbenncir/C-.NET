Vehicle car = new Vehicle("Honda Accord", 5, "Blue", true);
Vehicle bike = new Vehicle("Mountain Bike", "Red");
Vehicle skateboard = new Vehicle("Rollerblades", "Black");
Vehicle newcar = new Vehicle("Toyota Camry", 4, "Silver", true);

List<Vehicle> vehicles = new List<Vehicle>();
vehicles.Add (car);
vehicles.Add(bike);
vehicles.Add(skateboard);
vehicles.Add(newcar);
foreach (Vehicle vehicle in vehicles)
        {
            vehicle.ShowInfo();
            Console.WriteLine();
        }
car.Travel(100);
car.ShowInfo();