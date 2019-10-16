using System;
using System.Collections.Generic;


class Poodle : Dog
{
    public Poodle(string name, int age, int length, int withers, int weight, string gender) : base (name, age, length, withers, weight, gender)
    {

    }
    public override double GetTailLength()
    {
        double tailLength = age - length;

        if (tailLength < 8)
        {
            return 8;
        }
        else
        {
            tailLength = age - length;
            return tailLength;
        }
    }
    public override string GetAsString()
    {
        return "Name: " + FormatName(name) + ", " + "Age: " + age + ", " + "Length: " + length + ", " + "Withers: "
            + withers + ", " + "Weight: " + weight + ", " + "Gender: " + gender + ", " + "Breed: " + "Poodle, " + "Taillength: " + GetTailLength() + ".";
    }
}

