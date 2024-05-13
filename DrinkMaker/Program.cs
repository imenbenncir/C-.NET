Soda soda = new Soda("Cola", "Brown", 4.0, 150, true );
Coffee coffee = new Coffee("Espresso", "Black", 75 , 5  ,"Dark",  "Arabica");
Wine wine = new Wine("Merlot", "Red", 18.0, 120, "Bordeaux", 2019);

List<Drink> AllBeverages = new List<Drink> { soda, coffee, wine};
foreach (var drink in AllBeverages)
        {
            drink.ShowDrink();
            Console.WriteLine();
        }

