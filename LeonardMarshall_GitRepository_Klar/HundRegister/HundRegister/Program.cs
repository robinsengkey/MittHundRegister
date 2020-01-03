using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    List<Dog> doglist = new List<Dog>();

    private void ProgramLoop() // switch sats med olika val
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Enter Command: ");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "help":
                    Console.WriteLine("Commands:");                           //när man skriver in "help" så skriver den ut alla kommandon som finns
                    Console.WriteLine("add = add a dog");
                    Console.WriteLine("print = print all dogs");
                    Console.WriteLine("exit = exit program");
                    Console.WriteLine("search = search for a dog by name");
                    Console.WriteLine("");
                    break;

                case "add":
                    AddDog();                   //kallar på metod för att lägg till hundar
                    break;

                case "search":
                    Dog dog = Search();         //kallar på search och senare om användaren skriver in rätt kommando så körs EditDog(dog)
                    if (dog != null)
                    {
                        EditDog(dog);
                    }
                    break;
                case "print":
                    Printdoglist();             //kallar på Printdoglist metoden
                    break;

                case "exit":
                    System.Environment.Exit(1);     // stänger ner programmet
                    return;

                default:                                //om du skriver in något annat än de kommandon som finns så...
                    Console.WriteLine("WrongCommand");      //skrivs detta ut
                    Console.WriteLine("");
                    break;
            }
        }
    }

    private void Printdoglist()                     // printar alla hundar
    {
        doglist.Sort();
        foreach (Dog dog in doglist)
        {
            Console.WriteLine(dog.GetAsString());
        }
    }

    static void Main(string[] args)         // main, kallar på programloop
    {
        Program p = new Program();

        p.ProgramLoop();

    }

    void Remove(Dog dog)                // tar bort hundar
    {
        for (int i = 0; i < doglist.Count; i++)
        {
            if (dog == doglist[i])
            {
                doglist.RemoveAt(i);
                Console.WriteLine("Dog successfully removed");
            }
        }
    }

    /*
     * Robin:
     * Snygg metod! Ett problem är dock att det inte finns några begränsningar 
     * för vad man skriva in som kön. Detta kan leda till problem när man beräknar
     * svanslängden.
     */
    private void AddDog()
    {
        HandleInput("Enter breed", out string breed);                                     //låter användaren skriva in en input som går igenom "HandelInput"

        if (breed.ToLower() == "poodle" || breed.ToLower() == "labrador" || breed.ToLower() == "weinerdog")  // om användaren skriver in någon av de 3 olika raserna så händer de under
        {
            HandleInput("Enter name", out string name);
            HandleInput("Enter age", out int age);
            HandleInput("Enter length", out int length);
            HandleInput("Enter withers", out int withers);
            HandleInput("Enter weight", out int weight);
            HandleInput("Enter gender", out string gender);

            Dog dog = null; // nollställer dog

            /*
             * Robin:
             * Hade blivit en liten optimering om du användt if följt av elseif. 
             */

            if (breed.ToLower() == "poodle") //om användaren skrev in pudel
            {
                dog = new Poodle(name, age, length, withers, weight, gender); // då blir dog satt till Pudel och hela strängen
            }

            if (breed.ToLower() == "labrador")  //om användaren skrev in labrador
            {
                dog = new Labrador(name, age, length, withers, weight, gender);
            }

            if (breed.ToLower() == "weinerdog") // om användaren skrev in weinerdog
            {
                dog = new WeinerDog(name, age, length, withers, weight, gender);
            }

            /*
             * Robin:
             * Det hade nog räckt att istället för att sätta count++ bara skriva
             * ut att hunden redan finns och sedan sätta en return. Då slipper du
             * if-else satsen under for-loopen.
             */

            int count = 0; // sätter variabeln count till 0
            foreach (Dog d in doglist) // för varje hund i listan...
            {
                if (d.Compare(dog))  // jämför den med dog
                {
                    count++; // lägger på +1 på count
                }
            }
            if (count == 0) // om count fortfarande är 0 , alltså att det inte fanns någon likadan hund så händer de under, alltså inom {}
            {
                doglist.Add(dog); // lägger till hund
            }
            else // om count inte är 0 så händer...
                Console.WriteLine("The dog you tried to add already exist");
        }
        else // om man skrev något annat än de 3 raserna så...
        {

            Console.WriteLine("Breed does not exist");
            return; // retunerar

        }
    }

    void EditDog(Dog dog) //metod som kallar på metoder eller skriver ut saker
    {
        bool running = true; // running sätts till true, bool kan bara vara false eller true
        while (running == true) // så länge running är true så körs det under
        {
            Console.WriteLine("Enter search command(help for commands):");
            string userinput = Console.ReadLine(); //användaren matar in ett kommando inom sök metoden och det som väljs kör de som är under inom  {}
            if (userinput == "edit")
            {
                Edit(dog);
            }
            else if (userinput == "exit")
            {
                running = false;
            }
            else if (userinput == "help")
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("remove = remove a dog");
                Console.WriteLine("edit = edit a dogs");
            }

            else if (userinput == "remove")
            {
                Remove(dog);

            }
        }
    }


    void Edit(Dog dog) // redigera hunden som har blivit sökt på, körs när användaren matat in kommandot edit efter att ha gått in i sök
    {
        Console.WriteLine(dog.GetAsString());
        bool running = true;
        while (running == true)
        {
            int index = 0;
            for (int i = 0; i < doglist.Count; i++)
            {
                if (doglist[i] == dog)
                {
                    index = i;
                }
            }
            Console.WriteLine("What do you want to edit about the dog? (exit to stop edit");

            string choice = Console.ReadLine();

            /*
             * Robin:
             * Jag gillar lösningen här. Dock suhade du kunnat göra det något lättare för dig själv
             * genom att direkt göra ändrningar på variabeln dog som du skickar in.
             * Den enda gången du igentligen behöver veta hundens index är när du
             * ändrar hundens ras. Jag rekommenderar att du läser på om referens och value
             * types.
             * 
             * t.ex. 
             * doglist[index].Age = name; 
             * är samma sak som 
             * dog.name = name;
             * 
             */

            switch (choice.ToLower()) // switch sats som låter en välja vad man ska redigera och sätter alla bokstäver till gemener.
            {
                case "exit":
                    running = false;
                    break;
                case "name":
                    HandleInput("What do you want to change it to?", out string name);
                    doglist[index].Name = name;                             //ändrar bara namnet i strängen
                    break;
                case "age":
                    HandleInput("What do you want to change it to?", out int age);
                    doglist[index].Age = age;
                    break;
                case "withers":
                    HandleInput("What do you want to change it to?", out int withers);
                    doglist[index].Withers = withers;
                    break;
                case "length":
                    HandleInput("What do you want to change it to?", out int length);
                    doglist[index].Length = length;
                    break;
                case "gender":
                    HandleInput("What do you want to change it to?", out string gender);
                    doglist[index].Gender = gender;
                    break;
                case "weight":
                    HandleInput("What do you want to change it to?", out int weight);
                    doglist[index].Weight = weight;
                    break;
                case "breed":
                    /*
                     * Robin:
                     * Snyggt! Dock så ändrar du inte vad som finns i variabeln dog
                     * i EditDog() -metoden. Detta leder till att den fortfarande pekar på 
                     * den gamla hunden. En snabb lösning hade varit att låta den här metoden
                     * sätta doglist[index] = dog = new Labrador(...); och sedan returnera 
                     * dog igen i slutet på denna metod. Du kan du lätt fånga upp det i 
                     * EditDog med:
                     * 
                     *  if (userinput == "edit")
                     *    dog = Edit(dog);
                     *    
                     * som det är nu så skriver den här metoden ut den gamla
                     * hunden om man ändrar hundens ras, backar ut ett steg med "exit", och sedan
                     * skriver "edit" igen. Inte ett stort problem, men värt att tänka på.
                     */

                    HandleInput("What do you want to change it to?", out string breed);
                    if (breed.ToLower() == "labrador") //om rasen (i gemener) är labrador så läggs den ändringen till
                    {
                        doglist[index] = new Labrador(dog.Name, dog.Age, dog.Length, dog.Withers, dog.Weight, dog.Gender);
                    }

                    if (breed.ToLower() == "weinerdog")
                    {
                        doglist[index] = new WeinerDog(dog.Name, dog.Age, dog.Length, dog.Withers, dog.Weight, dog.Gender);
                    }

                    if (breed.ToLower() == "poodle")
                    {
                        doglist[index] = new Poodle(dog.Name, dog.Age, dog.Length, dog.Withers, dog.Weight, dog.Gender);
                    }
                    break;
            }
        }
    }

    public Dog Search()
    {
        Console.WriteLine("Enter Name");
        string input = Console.ReadLine().ToLower();
        List<Dog> foundInstance = new List<Dog>();
        foreach (Dog m in doglist) // den tittar igenom hela listan
        {
            if (m.Name == input) //  och jämför varje hund med namnet användaren skrivit in
            {
                foundInstance.Add(m); // om det fanns en sån hund läggs den till i den temporära listan
                Console.WriteLine("Found " + m.Name + " dog");          // feedback

            }
        }
        if (foundInstance.Count == 1)  // om det har lagts till en hund
            return foundInstance[0]; // returnar den 

        if (foundInstance.Count == 0) //om det inte lagts till någon hund i den temporära listan så..
        {
            Console.WriteLine("Could not find a dog named " + input);
            return null;
        }

        HandleInput("Enter Age", out int AgeInput); // hanterar input för ålder

        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].Age != AgeInput)
            {
                foundInstance.RemoveAt(i);
            }
        }
        if (foundInstance.Count == 1)
            return foundInstance[0];

        HandleInput("Enter Length", out int LengthInput);

        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].Length != LengthInput)
            {
                foundInstance.RemoveAt(i);
            }
        }
        if (foundInstance.Count == 1)
            return foundInstance[0];


        HandleInput("Enter Withers", out int WithersInput);

        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].Withers != WithersInput)
            {
                foundInstance.RemoveAt(i);
            }
        }
        if (foundInstance.Count == 1)
            return foundInstance[0];

        HandleInput("Enter Weight", out int WeightInput);

        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].Weight != WeightInput)
            {
                foundInstance.RemoveAt(i);
            }
        }
        if (foundInstance.Count == 1)
            return foundInstance[0];

        HandleInput("Enter Gender", out string GenderInput);

        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].Gender != GenderInput)
            {
                foundInstance.RemoveAt(i);
            }
        }
        if (foundInstance.Count == 1)
            return foundInstance[0];

        HandleInput("Enter breed", out string BreedInput);
        for (int i = foundInstance.Count - 1; i >= 0; i--)
        {
            if (foundInstance[i].GetType().ToString() != BreedInput)
            {
                foundInstance.RemoveAt(i);
            }
        }

        return null;
    }

    #region HandleInput                                                             
    private bool HandleInput(string message, out int input)
    {
        while (true) // medans HandleInput är true så
        {
            try // prova
            {
                Console.WriteLine(message);
                input = int.Parse(Console.ReadLine());
                return true;
            }
            catch (Exception e) // annars "fångar" den upp den, och skriver ut...
            {
                Console.WriteLine("{0}: Wrong format.", e.GetType().Name);
                Console.WriteLine("");
            }
        }
    }

    private bool HandleInput(string message, out string input) //overload
    {
        while (true)
        {
            try
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToLower();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: Wrong format.", e.GetType().Name);
                Console.WriteLine("");
            }
        }
    }

    #endregion
}

/*
 * Robin:
 * 
 * Ledsen att rättningen tog lite extra tid! 
 * 
 * Mycket bra Leonard! Snyggt strukturerat och god läsbarhet/namngivning med enstaka undantag. 
 * Finns några små missar som kan leda till mindre problem, men inget stort vad
 * jag kan hitta som skulle få programmet att krascha. Lite extra testning medan
 * du skriver koden hade nog fått ut de små buggarna.
 * 
 * Jag gillar att du verkligen börjat arbeta bra på lektionerna, och tar för dig mer
 * och ställer frågor! Fortsätt så!
 */
