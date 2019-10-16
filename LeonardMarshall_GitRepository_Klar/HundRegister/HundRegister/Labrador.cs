using System;
using System.Collections.Generic;

class Labrador : Dog
{
    public Labrador(string name, int age, int length, int withers, int weight, string gender) : base(name, age, length, withers, weight, gender)
    {

    }

    public override double GetTailLength()
    {
        double tailLength = length - withers;

        if (gender == "male")
        {
            tailLength = length - withers + 2;
            return tailLength;
        }
        else
        {
            tailLength = length - withers;
            return tailLength;
        }
    }
    public override string GetAsString()
    {
        return "Name: " + FormatName(name) + ", " + "Age: " + age + ", " + "Length: " + length + ", " + "Withers: "
            + withers + ", " + "Weight: " + weight + ", " + "Gender: " + gender + ", " + "Breed: " + "Labrador, " + "Taillength: " + GetTailLength() + ".";
    }
}

