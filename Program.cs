using System;
using System.Collections.Generic;
using System.Linq;

namespace Jurassic
{
  class Program
  {

    static List<Dinosaurs> DinosaurInventory = new List<Dinosaurs>();

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


      DinosaurInventory.Add(dino);
    }

    static void QuitProgramMessage()
    {
      Console.WriteLine("Good Bye! Hope to see you again at Jurassic Park");
    }

    static void ViewAll()
    {
      DisplayListOfDinosaurs(DinosaurInventory);
    }

    static void UnknownCommand()
    {
      Console.WriteLine("I don't understand that, try again");
    }

    static void DisplayTopThree(IEnumerable<Dinosaurs> dinos)
    {
      var dinoList = DinosaurInventory.OrderByDescending(dino => dino.Weight);
      Console.WriteLine($"The Biggest Dinosaurs are {dino.Name} at {dino.Weight}");
    }


    static void DisplayListOfDinosaurs(IEnumerable<Dinosaurs> dinos)
    {
      Console.WriteLine("Here is a list of all Dinosaurs at Jurassic Park");
      Console.WriteLine("--------------------------------------------------");
      foreach (var dino in dinos)
      {
        Console.WriteLine($"{dino.Name} has been a {dino.DietType} since arrival on {dino.DateAcquired} weighing in at {dino.Weight} lbs. and can be seen in enclosure {dino.EnclosureNumber}");
      }
    }

    static void UpdateDinoEnclosure()
    {
      Console.WriteLine("Who would you like to move?");
      var dinoName = Console.ReadLine();
      Console.WriteLine($"Where would you like to move {dinoName} to?");
      var dinoEnclosureNumber = Console.ReadLine();
      var moveDino = DinosaurInventory
        .FirstOrDefault(dino => dino.Name.ToLower() == dinoName.ToLower());
      moveDino.EnclosureNumber = int.Parse(dinoEnclosureNumber);
    }

    static void DietSummary()
    {
      Console.WriteLine("Who do you want a summary for carnivores or herbivores?");
      var dinoDietType = Console.ReadLine();
      var dinoDiet = DinosaurInventory.Count(dino => dino.DietType == dinoDietType);
      Console.WriteLine($"There are {dinoDiet} of {dinoDietType}");
    }





    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park");
      var input = "";
      while (input != "quit")
      {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("Available commands are: view, add, remove, transfer, diet, 3 heaviest, or quit");
        input = Console.ReadLine().ToLower();
        if (input == "add")
        {
          AddDinosaur();
        }

        else if (input == "transfer")
        {
          UpdateDinoEnclosure();
        }
        else if (input == "diet")
        {
          DietSummary();
        }
        else if (input == "quit")
        {
          QuitProgramMessage();
        }
        else if (input == "view")
        {
          ViewAll();
        }
        else
        {
          UnknownCommand();
        }

        //       }
      }
    }
  }
}
