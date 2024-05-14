using Part2_POE;

class poe
{

    static public void Main(String[] args)
    {
        String item = "null";// place holder for arraylist
        double quant = 1;
        String units = "a";
        double unit_number = 1;
        String prep_step = "a";
        int step_number = 1;
        String name_of_recipee = "a";
        double calo = 1;
        String food = "a";
        Class1 cl = new Class1(item, quant, units, unit_number, prep_step, step_number, name_of_recipee, calo, food);
        cl.menu();
    }
}