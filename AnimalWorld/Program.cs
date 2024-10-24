using System;
using System.Collections.Generic;

abstract class Continent { }

internal class Africa : Continent { }
internal class NA : Continent { }
internal class Australia : Continent { }

abstract class HerbivoreAfrica
{
    public uint Weight { get; protected set; } = 0;
    public bool IsAlive { get; private set; } = true;

    public void EatGrass() => Weight += 10;
    public void Die() => IsAlive = false;
}

abstract class HerbivoreNA
{
    public uint Weight { get; protected set; } = 0;
    public bool IsAlive { get; private set; } = true;

    public void EatGrass() => Weight += 10;
    public void Die() => IsAlive = false;
}

abstract class HerbivoreAustralia
{
    public uint Weight { get; protected set; } = 0;
    public bool IsAlive { get; private set; } = true;

    public void EatGrass() => Weight += 10;
    public void Die() => IsAlive = false;
}

abstract class CarnivoreAfrica
{
    public uint Power { get; protected set; } = 0;

    public void Eat(HerbivoreAfrica herb)
    {
        if (!herb.IsAlive) return;

        if (herb.Weight < Power)
        {
            Power += 10;
            herb.Die();
        }
        else
        {
            Power -= 10;
        }
    }
}

abstract class CarnivoreNA
{
    public uint Power { get; protected set; } = 0;

    public void Eat(HerbivoreNA herb)
    {
        if (!herb.IsAlive) return;

        if (herb.Weight < Power)
        {
            Power += 10;
            herb.Die();
        }
        else
        {
            Power -= 10;
        }
    }
}

abstract class CarnivoreAustralia
{
    public uint Power { get; protected set; } = 0;

    public void Eat(HerbivoreAustralia herb)
    {
        if (!herb.IsAlive) return;

        if (herb.Weight < Power)
        {
            Power += 10;
            herb.Die();
        }
        else
        {
            Power -= 10;
        }
    }
}

sealed class Wildebeest : HerbivoreAfrica
{
    public Wildebeest()=>
        Weight = 50;
}
sealed class Bison : HerbivoreNA
{
    public Bison() =>
        Weight = 90;
}
sealed class Kangaroo : HerbivoreAustralia
{
    public Kangaroo() =>
        Weight = 40;
}
sealed class Lion : CarnivoreAfrica
{
    public Lion() =>
        Power = 55;
}
sealed class Grizzly : CarnivoreNA
{
    public Grizzly() =>
        Power = 85;
}
sealed class TasmanianDiabol : CarnivoreAustralia
{
    public TasmanianDiabol() =>
        Power = 45;
}


internal class AnimalWorld
{
    private List<HerbivoreAfrica> africanHerbivores = new() { new Wildebeest() };
    private List<HerbivoreNA> naHerbivores = new() { new Bison() };
    private List<HerbivoreAustralia> australianHerbivores = new() { new Kangaroo() };

    private List<CarnivoreAfrica> africanCarnivores = new() { new Lion() };
    private List<CarnivoreNA> naCarnivores = new() { new Grizzly() };
    private List<CarnivoreAustralia> australianCarnivores = new() { new TasmanianDiabol() };

    public void MealHerbivores()
    {
        Console.WriteLine("All herbivores are eating grass...");
        foreach (var herb in africanHerbivores) herb.EatGrass();
        foreach (var herb in naHerbivores) herb.EatGrass();
        foreach (var herb in australianHerbivores) herb.EatGrass();
    }


    public void MealCarnivores()
    {
        Console.WriteLine("All carnivores are hunting...");
        africanCarnivores[0].Eat(africanHerbivores[0]);
        naCarnivores[0].Eat(naHerbivores[0]);
        australianCarnivores[0].Eat(australianHerbivores[0]);
    }

    public void ShowStatus()
    {
        Console.WriteLine("\nCurrent Animal Status:");

        Console.WriteLine($"Wildebeest - Weight: {africanHerbivores[0].Weight}, Alive: {africanHerbivores[0].IsAlive}");
        Console.WriteLine($"Bison - Weight: {naHerbivores[0].Weight}, Alive: {naHerbivores[0].IsAlive}");
        Console.WriteLine($"Kangaroo - Weight: {australianHerbivores[0].Weight}, Alive: {australianHerbivores[0].IsAlive}");

        Console.WriteLine($"Lion - Power: {africanCarnivores[0].Power}");
        Console.WriteLine($"Grizzly - Power: {naCarnivores[0].Power}");
        Console.WriteLine($"Tasmanian Devil - Power: {australianCarnivores[0].Power}");
    }

}

class Program
{
    static void Main()
    {
        AnimalWorld animalWorld = new AnimalWorld();

        animalWorld.ShowStatus();

        animalWorld.MealCarnivores();
        animalWorld.MealHerbivores();
        animalWorld.ShowStatus();
    }
}
