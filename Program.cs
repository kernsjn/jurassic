using System;
using System.Collections.Generic;
using System.Linq;

namespace Jurassic
{
  class Program
  {

    // static List<Dinosaurs> DinosaurInventory = new List<Dinosaurs>();
    static DatabaseContext Db = new DatabaseContext();

    static void AddDinosaur()
    {

      Console.WriteLine("What is the name of your Dinosaur?");
      var dinoName = Console.ReadLine();
      Console.WriteLine($"Is {dinoName} a carnivore or herbivore?");
      var dinoDietType = Console.ReadLine();
      Console.WriteLine($"How much does {dinoName} weigh?");
      var dinoWeight = Console.ReadLine();
      Console.WriteLine($"What enclosure will {dinoName} live in?");
      var dinoEnclosureNumber = Console.ReadLine();

      var dino = new Dinosaurs();
      dino.Name = dinoName;
      dino.DietType = dinoDietType;
      dino.DateAcquired = DateTime.Now;
      dino.Weight = int.Parse(dinoWeight);
      dino.EnclosureNumber = int.Parse(dinoEnclosureNumber);


      Db.Dinosaurs.Add(dino);
      Db.SaveChanges();
    }

    static void QuitProgramMessage()
    {
      Console.WriteLine("Good Bye! Hope to see you again at Jurassic Park");
    }

    static void ViewAll()
    {
      DisplayList(Db.Dinosaurs);
    }


    static void HatchDino()
    {
      string[] names = { "Rufus", "Bear", "Dakota", "Fido",
                          "Vanya", "Samuel", "Koani", "Volodya",
                          "Prince", "Yiska", "Billy Jean", "Summer", "Heather", "Celeste", "Nikki" };

      string[] diet = { "carnivore", "herbivore" };
      Console.WriteLine("The egg is hatching!");

      var dino = new Dinosaurs();
      Random random = new Random();
      dino.Name = names[random.Next(0, 20)];
      dino.DietType = diet[random.Next(0, 2)];
      dino.DateAcquired = DateTime.Now;
      dino.Weight = random.Next(0, 1500);
      dino.EnclosureNumber = 2;

      Console.WriteLine($"Your new dinosaur is named {dino.Name}, weighs {dino.Weight}lbs, and is a {dino.DietType}!");

      Db.Dinosaurs.Add(dino);
      Db.SaveChanges();

    }


    static void NeedsASheep()
    {

      DisplayList(Db.Dinosaurs.Where(dino => dino.DietType == "carnivore").OrderBy(dino => dino.Weight).Take(3), "Jurassic Park's 3 lightest carnivores by weight are:");
    }

    static void DisplayTopThree()
    {
      DisplayList(Db.Dinosaurs.OrderByDescending(dino => dino.Weight).Take(3), "Jurassic Park's top three dinosaurs by weight are:");
    }


    static void UnknownCommand()
    {
      Console.WriteLine("I don't understand that, try again");
    }


    static void DisplayList(IEnumerable<Dinosaurs> dinos, string header = "Here is a list of all Dinosaurs at Jurassic Park")
    {
      Console.WriteLine(header);
      Console.WriteLine("--------------------------------------------------");
      foreach (var dino in dinos)
      {
        Console.WriteLine($"{dino.Id}:  {dino.Name} has been a {dino.DietType} since arrival on {dino.DateAcquired} weighing in at {dino.Weight} lbs. and can be seen in enclosure {dino.EnclosureNumber}");
      }
      Console.WriteLine("---------------------------------------");


    }


    static void UpdateDinoEnclosure()
    {
      Console.WriteLine("Who would you like to move?");
      var dinoName = Console.ReadLine();
      Console.WriteLine($"Where would you like to move {dinoName} to?");
      var dinoEnclosureNumber = Console.ReadLine();
      var moveDino = Db.Dinosaurs
        .FirstOrDefault(dino => dino.Name.ToLower() == dinoName.ToLower());
      moveDino.EnclosureNumber = int.Parse(dinoEnclosureNumber);
      Db.SaveChanges();
    }

    static void ReleaseDinoEnclosure()
    {
      Console.WriteLine("What enclosure would you like to release?");
      var dinoEnclosureNumber = Console.ReadLine();
      var releaseDino = Db.Dinosaurs.FirstOrDefault(dino => dino.EnclosureNumber == int.Parse(dinoEnclosureNumber));
      releaseDino.EnclosureNumber = default;
      Db.SaveChanges();
    }




    static void DietSummary()
    {
      Console.WriteLine("Who do you want a summary for carnivores or herbivores?");
      var dinoDietType = Console.ReadLine();
      var dinoDiet = Db.Dinosaurs.Count(dino => dino.DietType == dinoDietType);
      Console.WriteLine($"There are {dinoDiet} {dinoDietType}");
    }

    static void DeleteDino()
    {
      Console.WriteLine("what is the name of the dinosaurs you want to remove");
      var dinoName = Console.ReadLine();
      var dinoToDelete = Db.Dinosaurs.FirstOrDefault(dino => dino.Name == dinoName);
      if (dinoToDelete != null)
      {
        Db.Dinosaurs.Remove(dinoToDelete);
        Db.SaveChanges();

      }
    }



    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park");
      var input = "";
      while (input != "quit")
      {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("Available commands are: view, add, remove, release, transfer, diet, heaviest, sheep, hatch, or quit");
        input = Console.ReadLine().ToLower();
        if (input == "add")
        {
          AddDinosaur();
        }

        else if (input == "transfer")
        {
          UpdateDinoEnclosure();
        }
        else if (input == "hatch")
        {
          HatchDino();
        }
        else if (input == "release")
        {
          ReleaseDinoEnclosure();
        }
        else if (input == "heaviest")
        {
          DisplayTopThree();
        }
        else if (input == "sheep")
        {
          NeedsASheep();
        }
        else if (input == "diet")
        {
          DietSummary();
        }
        else if (input == "quit")
        {
          QuitProgramMessage();
        }
        else if (input == "remove")
        {
          DeleteDino();
        }
        else if (input == "view")
        {
          ViewAll();
        }
        else
        {
          UnknownCommand();
        }

      }
    }
  }
}



