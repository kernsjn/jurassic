using System;

namespace Jurassic
{
  public class Dinosaurs
  {
    // ID
    public int Id { get; set; }

    // Name
    public string Name { get; set; }

    // DietType - This will be carnivore or herbivore
    public string DietType { get; set; }

    //  DateAcquired - This will be defaulted when the dinosaur is created
    public DateTime DateAcquired { get; set; }

    // Weight - In pounds, how heavy the dinosaur is
    public int Weight { get; set; }
    // EnclosureNumber - the Pen that the dinosaur is currently on
    public int EnclosureNumber { get; set; }

    internal static object Take(int v)
    {
      throw new NotImplementedException();
    }
  }
}