using System;
using System.Collections.Generic;

class WeinerDog : Dog
{
    public WeinerDog(string name, int age, int length, int withers, int weight, string gender) : base(name, age, length, withers, weight, gender)
    {

    }

    public override double GetTailLength() // räcknar ut svanslängd
    {
        double tailLength = length / 4;

        return tailLength;
    }
    public override string GetAsString()
    {

    return "Name: " + FormatName(name) + ", " + "Age: " + age + ", " + "Length: " + length + ", " + "Withers: " // hur allt ska skrivas ut för Weinerdog
            + withers + ", " + "Weight: " + weight + ", " + "Gender: " + gender + ", " + "Breed: " + "WeinerDog, " + "Taillength: " + GetTailLength() + ".";

    }
}

