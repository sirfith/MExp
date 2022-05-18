// See https://aka.ms/new-console-template for more information
int maxlvl = 21; // Top lvl
int maxmulti = 8;
int maxep = 1000; // Number of exp additions.
int expstep = 1000; // XP added MMC
//int maxmulti = 1; // Codex of Constantine
//int maxep = 110; // Number of exp additions CoC.
//int expstep = 500; // XP added CoC
int lvlexp;
int[] explvl = {0, 650, 1300, 3300, 6000, 10000, 15000, 23000, 34000, 50000, 71000, 105000, 145000, 210000, 295000, 425000, 600000, 850000,
    1200000, 1700000, 2400000, 3450000, 4800000 };
int[] exp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
int[] lvl = { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
// int lvllth = lvl.Length;
//  1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19   20   21   22   23
//  1.5 3   3.5 6.5 9   12  18  24  38  45  75  95  145 190 290 395 550 800 1150 1500 3000 6000 12000
//  1   2   3   4   6   8   12  16  24  30  50  65  85  130 190 255 410 500 750  1050 2100 4200 8400 
//  .65 1.3 2   2.7 4   5   8   11  16  21  34  40  65  85  130 175 250 350 500  700  1400 2800 5600
for (int i = 1; i <= maxep; i++)
{
    lvl[0] = 0;
    for (int j = 1; j <= maxmulti; j++)
    {
        if (lvl[j] == 0)
        {
            // Console.WriteLine("break {0}", j);
            break;
        }
        lvl[0] += lvl[j];
    }
    // lvlexp = (expstep * lvl[1]);  // CoC
    // exp[0] += lvlexp;   // CoC
    lvlexp = (expstep / lvl[0]);
    exp[0] += expstep;
    for (int k = 1; k <= maxmulti; k++)
    {
        if (lvl[k] > 0)
        {
            exp[k] += (lvlexp * lvl[k]);
            //        exp[k] += lvlexp;   // CoC
            for (int l = 1; l <= maxlvl; l++) // check xp of lvl
            {
                if (exp[k] >= explvl[l])
                {
                    lvl[k] = l;
                }
            }
            if ((lvl[k] > 4) && (lvl[k + 1] == 0))
            {
                lvl[k + 1] = 1;
                exp[k + 1] = explvl[1];
                exp[1] -= explvl[1];
            }
        }
    }
    Console.Write("{0} ", i);
    Console.Write("Add: {0} ", lvlexp);
    for (int j = 0; j <= maxmulti; j++)
    {
        Console.Write(" #{0} ", j);
        Console.Write("{0} ", exp[j]);
        Console.Write("{0} ", lvl[j]);
        if (lvl[j + 1] == 0)
        {
            break;
        }
    }
    Console.WriteLine();
}