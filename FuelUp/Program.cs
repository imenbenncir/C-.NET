Car car = new Car("Tesla");
        Horse horse = new Horse("Black Beauty");
        Bicycle bicycle = new Bicycle("Mountain Bike");

        // Attempt to create an instance of Vehicle
        // Vehicle vehicle = new Vehicle(); // This will result in a compile-time error

        List<Vehicle> vehicles = new List<Vehicle> { car, horse, bicycle };
        List<INeedFuel> vehiclesWithFuel = new List<INeedFuel>();

        foreach (var vehicle in vehicles)
        {
            if (vehicle is INeedFuel fuelVehicle)
            {
                vehiclesWithFuel.Add(fuelVehicle);
            }
        }

        foreach (var vehicle in vehiclesWithFuel)
        {
            vehicle.GiveFuel(10);
        }

        foreach (var vehicle in vehiclesWithFuel)
        {
            Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.FuelTotal} units of {vehicle.FuelType}");
        }
    