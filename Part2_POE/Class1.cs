using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Part2_POE
{
    internal class Class1
    {
        public delegate void NotificationHandler(string message);
        public event NotificationHandler Notify;
        // private variables
        private String item;
        private double quant;
        private String units;
        private double unit_number;
        private String prep_step;
        private int step_number;
        private String name_of_recipee;
        public Boolean item_check;
        private double calo;
        private String food;
        // global lists
        public List<String> ingredient = new List<String>();
        public List<double> Quantity = new List<double>();
        public List<String> unit = new List<String>();
        public List<double> unit_num = new List<double>();
        public List<List<String>> prep_steps = new List<List<String>>();
        public List<int> step_num = new List<int>();
        public List<String> name_of_recipe = new List<String>();
        public List<double> reset = new List<double>();
        public List<double> calories = new List<double>();
        public List<String> foodgroup = new List<String>();
        // get methods
        public String Item
        {
            get { return item; }
        }
        public double Quant
        {
            get { return quant; }
        }
        public String Units
        {
            get { return units; }
        }
        public double Unit_number
        {
            get { return unit_number; }
        }
        public String Prep_step
        {
            get { return prep_step; }
        }
        public int Step_number
        {
            get { return step_number; }
        }
        public String Name_of_recipee
        {
            get { return name_of_recipee; }
        }
        public double Calo
        {
            get { return calo; }
        }
        public String Food
        {
            get { return food; }
        }
        //constractor with parameters
        public Class1(String item, double quant, String units, double unit_number, String prep_step, int step_number, String name_of_recipee, double calo, String food)
        {
            this.item = item;
            this.quant = quant;
            this.units = units;
            this.unit_number = unit_number;
            this.prep_step = prep_step;
            this.step_number = step_number;
            this.name_of_recipee = name_of_recipee;
            this.calo = calo;
            this.food = food;
        }

        public void menu()// first method that runs when code starts
        {
            //variables
            int option;
            Boolean con = false;// do while loop condition
            // checks if the system is empty or has a recipe 
            Console.WriteLine("*****************************************************************************" + "\n" +
            "                               Welcome to DELISH " + "\n" +
            "*****************************************************************************");

            do
            {
                Console.WriteLine("*********************************RECIPE MENU*********************************" +
                    "\nUse the numbers shown below to navigate the system" + "\n" +
                    "1.Create new Recipe \n" +
                    "2.Edit Recipe \n" +
                    "3.Delete Recipe \n" +
                    "4.Display Recipees \n" +
                    "5.Scale recipe \n" +
                    "6.Close Application");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option) // takes input and calls appropriate method corresponding to the input
                {
                    case 1: item_check = true; input(ingredient, Quantity, unit, unit_num, prep_steps, step_num, name_of_recipe, calories, foodgroup); break;// item_check is assigned true since the item is being added.input method is called with parameters
                    case 2:
                        if (item_check)
                        {
                            edit(ingredient, Quantity, unit, unit_num, prep_steps, step_num, name_of_recipe, calories, foodgroup); break;// edit method is called with parameters
                        }
                        else
                        {
                            Console.WriteLine("You can't edit a recipe that does not exist, add a recipe first"); menu();// appears when the system is empty
                        }; break;
                    case 3:
                        if (item_check)
                        {
                            delete(ingredient, Quantity, unit, unit_num, prep_steps, step_num, name_of_recipe, calories, foodgroup); break;
                        }
                        else
                        {
                            Console.WriteLine("You can not delete a recipe! The app recipe list is empty, add a recipe first"); menu();// appears when the system is empty
                        }; break;
                    case 4:
                        if (item_check)
                        {
                            display(ingredient, Quantity, unit, unit_num, prep_steps, step_num, name_of_recipe, calories, foodgroup); break;
                        }; break;
                    default: Console.WriteLine("thank you for using our app!"); break; //closes the app
                }

            } while (con); // loops while con is true

        }
        public void input(List<String> ingredient, List<double> Quantity, List<String> unit, List<double> unit_num, List<List<String>> prep_steps, List<int> step_num, List<String> name_of_recipe, List<double> calories, List<String> foodgroup) //takes the arraylist as parameters
        {
            Class1 cl = new Class1(item, quant, units, unit_number, prep_step, step_number, name_of_recipee, calo, food); //object linked with Class1 class
            List<String> temp_step_list = new List<String>();
            List<double> temp_calories = new List<double>();
            List<String> temp_list_food = new List<string>();
            double totalcalories = 0;
            Boolean addRecipe = true;
            Boolean con = true;
            int count = 0;
            if (cl.ingredient.Contains("a"))
            {

                ingredient.RemoveAt(0);
                Quantity.RemoveAt(0);
                unit.RemoveAt(0);
                unit_num.RemoveAt(0);
                prep_steps.RemoveAt(0);
                step_num.RemoveAt(0);
                name_of_recipe.RemoveAt(0);

            }
            temp_list_food.Add("Fats");
            temp_list_food.Add("Veggies and Fruits");
            temp_list_food.Add("Meat");
            temp_list_food.Add("dairy");
            temp_list_food.Add("Wholegrain");
            temp_list_food.Add("Oil");
            while (addRecipe)
            {
                Console.WriteLine("Enter the name of the recipe: ");
                this.name_of_recipee = Console.ReadLine();
                cl.name_of_recipe.Add(this.name_of_recipee);
                Console.WriteLine("How many ingredients does this recipe have? ");
                int num_ingredient = Convert.ToInt32(Console.ReadLine());// number of times the for loop should loop

                for (int i = 0; i < num_ingredient; i++)
                {
                    List<String> temp_list = new List<String>();
                    Console.WriteLine("Enter the name of ingredient no." + (i + 1));
                    this.item = Console.ReadLine();
                    ingredient.Add(this.item);

                    Console.WriteLine("Enter the food group of : " + this.item);
                    foreach (String item in temp_list_food)
                    {
                        Console.WriteLine(item);
                    }
                    this.food = Console.ReadLine();
                    foodgroup.Add(this.food);


                    Console.WriteLine("how many " + this.item + "(s) should i add: ");
                    this.quant = Convert.ToDouble(Console.ReadLine());
                    Quantity.Add(this.quant);

                    Console.WriteLine("What unit should be used to measure the ingredient: ");
                    this.units = Console.ReadLine();
                    unit.Add(this.units);

                    Console.WriteLine("What's the unit of ingredient: " + this.units);
                    this.unit_number = Convert.ToDouble(Console.ReadLine());
                    unit_num.Add(this.unit_number);

                    Console.WriteLine("How many steps does this recipe have?:  ");
                    this.step_number = Convert.ToInt32(Console.ReadLine());
                    step_num.Add(this.step_number);
                    for (int j = 0; j < this.step_number; j++)
                    {
                        Console.WriteLine("Enter step number. " + (count + 1) + " or 'cancel' to finish: ");
                        this.prep_step = Console.ReadLine();
                        if (this.prep_step.Equals("cancel", StringComparison.OrdinalIgnoreCase) || this.prep_step.Equals(null))// checks if it's empty or equals to cancel
                        {
                            break;
                        }
                        temp_step_list.Insert(i, this.prep_step);
                        count++;
                    }
                    prep_steps.Add(temp_step_list);
                    Console.WriteLine("Enter the calories for " + ingredient[i]);
                    this.calo = Convert.ToDouble(Console.ReadLine());
                    totalcalories += this.calo; // adds the number of calories as the method runs 
                    temp_calories.Insert(i, totalcalories); // adds the temporary list on the main list

                    if (totalcalories > 300)
                    {
                        // Notify the user if the total calories are above 300
                        OnNotify("Total calories are above 300.");
                    }
                }
                Console.WriteLine("Recipe added \n add another recipe? \n yes or no ?");
                String item_add = Console.ReadLine();

                if (item_add.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    addRecipe = true;

                }
                else
                {
                    addRecipe = false;
                    menu();

                }

            }



        }


        public void display(List<String> ingredient, List<double> Quantity, List<String> unit, List<double> unit_num, List<List<String>> prep_steps, List<int> step_num, List<String> name_of_recipe, List<double> calories, List<String> foodgroup)
        {
            Class1 cl = new Class1(item, quant, units, unit_number, prep_step, step_number, name_of_recipee, calo, food);
            int option;
            Console.WriteLine("1.Custom search \n" +
                "2.show all");
            option = Convert.ToInt32(Console.ReadLine());
            name_of_recipe.Sort();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the recipe name: ");
                    String search = Console.ReadLine();
                    for (int i = 0; i < ingredient.Count; i++)
                    {
                        if (search.Equals(name_of_recipe[i]))
                        {
                            Console.WriteLine("Ingredients:" + ingredient[i]);
                        }
                    }
                    break;
                case 2:
                    foreach (String item in ingredient)
                    {
                        Console.WriteLine("Ingredients:" + item);

                    }
                    Console.WriteLine("\n");
                    foreach (double item in Quantity)
                    {
                        Console.WriteLine("Quantity: " + item);
                    }
                    Console.WriteLine("\n");
                    foreach (String item in unit)
                    {
                        Console.WriteLine("Unit of measurement:" + item);

                    }
                    Console.WriteLine("\n");
                    foreach (double item in unit_num)
                    {
                        Console.WriteLine("Units:" + item);

                    }
                    Console.WriteLine("\n");
                    foreach (String item in foodgroup)
                    {
                        Console.Write("Foodgroup: " + item);
                    }
                    Console.WriteLine("\n");

                    foreach (double item in calories)
                    {
                        Console.WriteLine("total calories: " + item);
                    }
                    Console.WriteLine("\n");
                    for (int i = 0; i < prep_steps.Count; i++)
                    {
                        Console.WriteLine("How to prepare: ");
                        for (int j = 0; j < prep_steps[i].Count; j++)
                        {
                            Console.WriteLine(prep_steps[i][j]);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Enter a valid option"); display(ingredient, Quantity, unit, unit_num, prep_steps, step_num, name_of_recipe, calories, foodgroup);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------"); break;
            }


        }

        public void edit(List<String> ingredient, List<double> Quantity, List<String> unit, List<double> unit_num, List<List<String>> prep_steps, List<int> step_num, List<String> name_of_recipe, List<double> calories, List<String> foodgroup)
        {
            int count = 1;
            int option;
            Boolean case1 = false;
            Boolean case2 = false;
            Boolean case3 = false;
            Class1 cl = new Class1(item, quant, units, unit_number, prep_step, step_number, name_of_recipee, calo, food);

            foreach (String item in name_of_recipe)
            {
                Console.WriteLine(count + ". " + item);
                count++;
            }
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("what scale should the recipe be scaled to: \n" +
                "1. 0.5 scale (halved)\n" +
                "2. 2 scale (doubled)\n" +
                "3. 3 scale (tripled)\n" +
                "4. Reset values\n" +
                "5. Cancel and go to menu");
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    case1 = true;
                    reset.Add(Quantity[count]);
                    reset.Add(unit_num[count]);
                    reset.Add(calories[count]);
                    Quantity[count] = Quantity[count] * 0.5;
                    unit_num[count] = unit_num[count] * 0.5;
                    calories[count] = calories[count] * 0.5; break;
                case 2:
                    case2 = true;
                    reset.Add(Quantity[count]);
                    reset.Add(unit_num[count]);
                    reset.Add(calories[count]);
                    Quantity[count] = Quantity[count] * 2;
                    unit_num[count] = unit_num[count] * 2;
                    calories[count] = calories[count] * 2; break;
                case 3:
                    case3 = true;
                    reset.Add(Quantity[count]);
                    reset.Add(unit_num[count]);
                    reset.Add(calories[count]);
                    Quantity[count] = Quantity[count] * 3;
                    unit_num[count] = unit_num[count] * 3;
                    calories[count] = calories[count] * 3; break;
                case 4:
                    if (case1)
                    {
                        Quantity[count] = reset[0];
                        unit_num[count] = reset[1];
                        calories[count] = reset[2];
                    }
                    if (case2)
                    {
                        Quantity[count] = reset[0];
                        unit_num[count] = reset[1];
                        calories[count] = reset[2];
                    }
                    if (case3)
                    {
                        Quantity[count] = reset[0];
                        unit_num[count] = reset[1];
                        calories[count] = reset[2];
                    }

                    break;
                    Console.WriteLine("scaled");
            }
            menu();
        }
        public void delete(List<String> ingredient, List<double> Quantity, List<String> unit, List<double> unit_num, List<List<String>> prep_steps, List<int> step_num, List<String> name_of_recipe, List<double> calories, List<String> foodgroup)
        {
            int count = 0;
            foreach (String item in name_of_recipe)
            {
                Console.WriteLine(count + ". " + item);
                count++;
            }
            Console.WriteLine((count += 1) + ". Clear all?");
            int confirm = Convert.ToInt32(Console.ReadLine());
            if (confirm < count)
            {
                ingredient.RemoveAt(0);
                Quantity.RemoveAt(0);
                unit.RemoveAt(0);
                unit_num.RemoveAt(0);
                prep_steps.RemoveAt(0);
                step_num.RemoveAt(0);
                name_of_recipe.RemoveAt(0);
                Console.WriteLine("Removed");
            }
            else
            {
                ingredient.Clear();
                Quantity.Clear();
                unit.Clear();
                unit_num.Clear();
                prep_steps.Clear();
                step_num.Clear();
                name_of_recipe.Clear();
                Console.WriteLine("Cleared");

            }
            menu();
        }
        protected virtual void OnNotify(string message)
        {
            if (Notify != null)
            {

                Notify(message);
            }
        }
    }
}
