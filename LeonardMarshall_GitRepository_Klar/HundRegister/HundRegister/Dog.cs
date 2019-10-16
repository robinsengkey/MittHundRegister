using System;
using System.Collections.Generic;
using System.Linq;

abstract class Dog : IComparable<Dog>
{
    protected string name; // skapar variablerna
    protected int age;
    protected int length;
    protected int withers;
    protected int weight;
    protected string gender;



    public Dog(string name, int age, int length, int withers, int weight, string gender) // konstruktor
    {
        Name = name;
        Age = age;
        Length = length;
        Withers = withers;
        Weight = weight;
        Gender = gender;

    }

    public abstract double GetTailLength();

    public abstract string GetAsString();

    public string Name
    {
        get { return name; }            // gettar o settar
        set { name = value; }  
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public int Withers
    {
        get { return withers; }
        set { withers = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public string FormatName(string name) // formaterar namnet så det är versal först och sen gemener
    {
        name = name.ToLower();
        string[] names = name.Split(' ');
        string newName = "";
        foreach (string s in names)
        {
            newName += s.First().ToString().ToUpper() + s.Substring(1);
        }
        return newName;
    }

    public int CompareTo(Dog d)
    {
        return this.Name.CompareTo(d.Name);
    }

    public bool Compare(Dog d)
    {
        if(Name != d.Name)
        {
            return false;
        }
        if (Age != d.Age)
        {
            return false;
        }
        if (Length != d.Length)
        {
            return false;
        }
        if (Withers != d.Withers)
        {
            return false;
        }
        if (Weight != d.Weight)
        {
            return false;
        }
        if (GetType() != d.GetType())   /**/
            return false;
        return true;
    }
}