using System;
using System.Collections.Generic;

namespace MoreClasses
{
    /*Interface: ICat
     * Author: Jonathan Karcher
     * Purpose: Create an interface for the Cat class
     */
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
        void GoToVet();
    }
    /* Class: Cat
     * Author: Jonathan Karcher
     * Purpose: Generate cat responces
     */
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine(this.Name + " Meow. Nom Nom. Meow.");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + " Jingle Jingle Jingle.");
        }
        public override void GoToVet()
        {
            Console.WriteLine(this.Name + " Hiss!!! Evil...EVIL!!!");
        }
        public void Purr()
        {
            Console.WriteLine(this.Name + " Purrrr.");
        }
        public void Scratch()
        {
            Console.WriteLine(this.Name + " Ok thats enough... actually dont stop.");
        }
        /* Constructor: Cat
         * Purpose: Create a cat based on the Pet constructor
         * Restrictions: None
         */
        public Cat(string nameIn, int ageIn) : base(nameIn, ageIn)
        {
            
        }
    }
    /*Interface: IDog
     * Author: Jonathan Karcher
     * Purpose: Create an interface for the Dog class
     */
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GoToVet();
    }
    /* Class: Dog
     * Author: Jonathan Karcher
     * Purpose: Generate dog responces
     */
    public class Dog : Pet, IDog
    {
        public string license;
        public override void Eat()
        {
            Console.WriteLine(this.Name + " FOOD!!! I dont know what your eating but i want it too.");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + " See my ball, see it isnt it awesome, it squeeks too. Squeek Squeek.");
        }
        public override void GoToVet()
        {
            Console.WriteLine(this.Name + " I remember this place... this is a place of EVIL!");
        }
        public void Bark()
        {
            Console.WriteLine(this.Name + " Woof Woof!");
        }
        public void NeedWalk()
        {
            Console.WriteLine(this.Name + " Out, did you say OUT. WOOF, Lets go... COME ON!!!");
        }
        /* Constructor: Dog
         * Purpose: Create a dog based on the Pet constructor with a lisence added
         * Restrictions: None
         */
        public Dog(string LicenseIn, string nameIn, int ageIn) : base(nameIn,ageIn)
        {
            license = LicenseIn;
        }
    }
    /* Class: Pet
     * Author: Jonathan Karcher
     * Purpose: create a base class to store general pet data
     */
    public abstract class Pet
    {
        public string name;
        public int age;
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
        public abstract void Eat();
        public abstract void Play();
        public abstract void GoToVet();
        /* Constructor: Pet
         * Purpose: Create a basic pet with a name and age
         * Restrictions: None
         */
        public Pet(string nameIn, int ageIn)
        {
            name = nameIn;
            age = ageIn;
        }
    }
    /* Class: Pets
     * Purpose: build a list of Pet and manage its contents
     * Restrictions: None
     */
    public class Pets
    {
        // list of all available pets
        public List<Pet> petList = new List<Pet>();
        /* Indexer: Pet
         * Purpose: Get and Set a pet at the index of PetEl
         * Restrictions: None
         */
        public Pet this[int petEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[petEl];
                }
                catch
                {
                    returnVal = null;
                }
                // get a pet from the petList at index petEl
                return returnVal;
            }
            set
            {
                if(petEl < petList.Count)
                {
                    // set the pet at index petEl to the pet being entered
                    petList[petEl] = value;
                }
                else
                {
                    // add a pet at the end of petList
                    petList.Add(value);
                }
            }
        }
        /* Method: Count
         * Purpose: Give the total number of pets in the petList
         * Restrictions: None
         */
        public int Count
        {
            get { return petList.Count; }
        }
        /* Method: AddPet
         * Purpose: Add a pet to the list
         * Restrictions: None
         */
        public void AddPet(Pet pet)
        {
            petList.Add(pet);
        }
        /* Method: Remove
         * Purpose: Remove a pet from the list
         * Restrictions: None
         */
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        /* Method: RemoveAt
         * Purpose: Remove a pet at a specific index
         * Restrictions: None
         */
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
    }
    /* Class: Program
     * Purpose: Add and interact with both dogs and cats
     * Restrictions: None
     */
    class Program
    {
        /* Method: Main
         * Purpose: Entery point for the program
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            // general input
            // Note: because dog requiers two string inputs for construction input will be a 2D array
            string[] input = new string[2];
            // store the current animals age
            // Note: should be used for input only
            int age;
            // the curent pet being referenced
            Pet thisPet = null;
            // the current dog being referenced
            Dog dog = null;
            // the current cat being referenced
            Cat cat = null;
            // the interface of the dog being referenced
            IDog iDog = null;
            // the interface of the cat beiong referenced
            ICat iCat = null;
            // create a new random
            Random rand = new Random();
            // create a new list of pets
            Pets pets = new Pets();
            // the program will run for 50 cycles
            for(int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    // 1 in 2 chance that the animal will be a dog otherwise its a cat
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                        Console.Write("Dog's Name => ");
                        // store the animals name
                        input[0] = Console.ReadLine();
                        // make sure they enter an int
                        do
                        {
                            Console.Write("Age => ");
                            input[1] = Console.ReadLine();
                            // store the animals age
                        } while (!int.TryParse(input[1], out age));
                        Console.Write("License => ");
                        // store the animals lisence
                        input[1] = Console.ReadLine();
                        // create a dog
                        dog = new Dog(input[1], input[0], age);
                        // add the dog to petList
                        pets.AddPet(dog);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        Console.Write("Cat's Name => ");
                        // store the animals name
                        input[0] = Console.ReadLine();
                        // make sure they enter an int
                        do
                        {
                            Console.Write("Age => ");
                            input[1] = Console.ReadLine();
                            // store the animals age
                        } while (!int.TryParse(input[1], out age));
                        // create a cat
                        cat = new Cat(input[0], age);
                        // add the cat to petList
                        pets.AddPet(cat);
                    }
                }
                // if you did not add a new animal
                else
                {
                    // if there are no animals try adding an animal again
                    if(pets.Count==0)
                    {
                        continue;
                    }
                    // select a random pet from our list
                    thisPet = pets[rand.Next(0, pets.Count)];
                    // if the pet is a dog
                    if (thisPet.GetType() == typeof(Dog))
                    {
                        // assign the dog reference to thisPet
                        dog = (Dog)thisPet;
                        // select a random method from the dog class
                        switch (rand.Next(0, 5))
                        {
                            case 0:
                                {
                                    dog.Eat();
                                    break;
                                }
                            case 1:
                                {
                                    dog.Play();
                                    break;
                                }
                            case 2:
                                {
                                    dog.Bark();
                                    break;
                                }
                            case 3:
                                {
                                    dog.NeedWalk();
                                    break;
                                }
                            case 4:
                                {
                                    dog.GoToVet();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Method not found");
                                    break;
                                }
                        }
                    }
                    // if the pet is a cat
                    if (thisPet.GetType() == typeof(Cat))
                    {
                        // assign the cat reference to thisPet
                        cat = (Cat)thisPet;
                        // select a random method from the cat class
                        switch (rand.Next(0, 5))
                        {
                            case 0:
                                {
                                    cat.Eat();
                                    break;
                                }
                            case 1:
                                {
                                    cat.Play();
                                    break;
                                }
                            case 2:
                                {
                                    cat.Scratch();
                                    break;
                                }
                            case 3:
                                {
                                    cat.Purr();
                                    break;
                                }
                            case 4:
                                {
                                    cat.GoToVet();
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Method not found");
                                    break;
                                }
                        }
                    }
                }

            }
        }
    }
}
