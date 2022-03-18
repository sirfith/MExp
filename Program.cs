// See https://aka.ms/new-console-template for more information
int maxlvl = 22; // Top lvl
int maxmulti = 10;
int maxep = 175; // Number of exp additions.
int expstep = 1000; // XP added
int[] explvl = {0, 650, 1300, 3300, 6000, 10000, 15000, 23000, 34000, 50000, 71000, 105000, 145000, 210000, 295000, 425000, 600000, 850000,
    1200000, 1700000, 2400000, 3450000, 4800000 };
int[] exp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
int[] lvl = { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
int[] truelvl = { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
int lvllth = lvl.Length;
//  1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19   20   21   22   23
//  1.5 3   3.5 6.5 9   12  18  24  38  45  75  95  145 190 290 395 550 800 1150 1500 3000 6000 12000
//  1   2   3   4   6   8   12  16  24  30  50  65  85  130 190 255 410 500 750  1050 2100 4200 8400 
//  .65 1.3 2   2.7 4   5   8   11  16  21  34  40  65  85  130 175 250 350 500  700  1400 2800 5600
for (int i = 0; i < maxep; i++)
{
    lvl[0] = 0;
    for (int j = 1; j < maxmulti; j++)
    {
        lvl[0] = lvl[0] + lvl[j];
    }
    //  Console.Write("Count {0} ", i);
    //  Console.Write("totlvl {0} ", totlvl);
    //  Console.WriteLine("expstep {0}", expstep);
    exp[0] = exp[0] + (expstep * lvl[0]);
    for (int k = 1; k < maxmulti; k++)
    {
        if (lvl[k] > 0)
        {

            exp[k] = exp[k] + (expstep * lvl[k]);
            for (int l = 1; l < maxlvl; l++) // check xp of lvl
            {
                if (exp[k] >= explvl[l])
                {
                    if ((k == 1) || lvl[k] < (lvl[k - 1] / 2) || (lvl[k - 1] == 20))
                    { lvl[k] = l; }
                }
                //            Console.Write("Loop {0} ", l);
                //            Console.Write("Exp {0} ", exp[l]);
                //            Console.Write("Lvl {0} ", lvl[l]);
                if (exp[k] >= explvl[l])
                {
                    { truelvl[k] = l; }
                }
            }
            if ((lvl[k] == 2) && (lvl[k + 1] == 0))
            {
                lvl[k + 1] = 1;
                break;
            }
        }
    }
    Console.Write("* {0} ", i);
    Console.Write("Xp: {0} ", exp[0]);
    Console.Write("TL: {0} ", lvl[0]);
    for (int j = 1; j < maxmulti; j++)
    {
        Console.Write("\t #{0} ", j);
        Console.Write("{0} ", exp[j]);
        Console.Write("{0}-", lvl[j]);
        Console.Write("{0} ", truelvl[j]);
        if (lvl[j + 1] == 0)
        {
            break;
        }
    }
    Console.WriteLine();
    //Console.Write("Exp {0} ", exp[0]);
    //Console.Write("{0} ", exp[1]);
    //Console.Write("{0} ", exp[2]);
    //Console.Write("{0} ", exp[3]);
    //Console.Write("{0} ", exp[4]);
    //Console.Write("{0} ", exp[5]);
    //Console.Write("{0} ", exp[6]);
    //Console.Write("{0} ", exp[7]);
    //Console.Write("{0} ", exp[8]);
    //Console.WriteLine("{0} ", exp[9]);
    //Console.Write("Lvl {0} ", lvl[0]);
    //Console.Write("{0} ", lvl[1]);
    //Console.Write("{0} ", lvl[2]);
    //Console.Write("{0} ", lvl[3]);
    //Console.Write("{0} ", lvl[4]);
    //Console.Write("{0} ", lvl[5]);
    //Console.Write("{0} ", lvl[6]);
    //Console.Write("{0} ", lvl[7]);
    //Console.Write("{0} ", lvl[8]);
    //Console.WriteLine("{0} ", lvl[9]);
    // Console.WriteLine("Hello, World!");
}