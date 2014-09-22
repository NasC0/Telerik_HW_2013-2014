using System;

class ShipDamage
{
    static void Main()
    {
        int Sy1 = int.Parse(Console.ReadLine());
        int Sx1 = int.Parse(Console.ReadLine());
        int Sy2 = int.Parse(Console.ReadLine());
        int Sx2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int Cy1 = int.Parse(Console.ReadLine());
        int Cx1 = int.Parse(Console.ReadLine());
        int Cy2 = int.Parse(Console.ReadLine());
        int Cx2 = int.Parse(Console.ReadLine());
        int Cy3 = int.Parse(Console.ReadLine());
        int Cx3 = int.Parse(Console.ReadLine());
        int shipDamage = 0;
        int C1Reach = (h - Cx1) * 2;
        int C2Reach = (h - Cx2) * 2;
        int C3Reach = (h - Cx3) * 2;
        int Sx1Reach = (Sx1 - h) * 2;
        int Sx2Reach = (Sx2 - h) * 2;

        if (Sy1 < Sy2)
        {
            if (Cy1 < Sy1 || Cy1 > Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy1 == Sy1 || Cy1 == Sy2)
            {
                if (C1Reach < Sx2Reach || C1Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C1Reach == Sx1Reach || C1Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C1Reach < Sx1Reach && C1Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy1 > Sy1 && Cy1 < Sy2)
            {
                if (C1Reach < Sx2Reach || C1Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C1Reach == Sx1Reach || C1Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C1Reach < Sx1Reach && C1Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }

            if (Cy2 < Sy1 || Cy2 > Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy2 == Sy1 || Cy2 == Sy2)
            {
                if (C2Reach < Sx2Reach || C2Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C2Reach == Sx1Reach || C2Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C2Reach < Sx1Reach && C2Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy2 > Sy1 && Cy2 < Sy2)
            {
                if (C2Reach < Sx1Reach || C2Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C2Reach == Sx1Reach || C2Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C2Reach < Sx1Reach && C2Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }

            if (Cy3 < Sy1 || Cy3 > Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy3 == Sy1 || Cy3 == Sy2)
            {
                if (C3Reach < Sx2Reach || C3Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C3Reach == Sx1Reach || C3Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C3Reach < Sx1Reach && C3Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy3 > Sy1 && Cy3 < Sy2)
            {
                if (C3Reach < Sx2Reach || C3Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C3Reach == Sx1Reach || C3Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C3Reach < Sx1Reach && C3Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }
        }
        else
        {
            if (Cy1 > Sy1 || Cy1 < Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy1 == Sy1 || Cy1 == Sy2)
            {
                if (C1Reach < Sx2Reach || C1Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C1Reach == Sx1Reach || C1Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C1Reach < Sx1Reach && C1Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy1 < Sy1 && Cy1 > Sy2)
            {
                if (C1Reach < Sx2Reach || C1Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C1Reach == Sx1Reach || C1Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C1Reach < Sx1Reach && C1Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }

            if (Cy2 > Sy1 || Cy2 < Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy2 == Sy1 || Cy2 == Sy2)
            {
                if (C2Reach < Sx2Reach || C2Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C2Reach == Sx1Reach || C2Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C2Reach < Sx1Reach && C2Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy2 < Sy1 && Cy2 > Sy2)
            {
                if (C2Reach < Sx1Reach || C2Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C2Reach == Sx1Reach || C2Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C2Reach < Sx1Reach && C2Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }

            if (Cy3 > Sy1 || Cy3 < Sy2)
            {
                shipDamage += 0;
            }
            else if (Cy3 == Sy1 || Cy3 == Sy2)
            {
                if (C3Reach < Sx2Reach || C3Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C3Reach == Sx1Reach || C3Reach == Sx2Reach)
                {
                    shipDamage += 25;
                }
                else if (C3Reach < Sx1Reach && C3Reach > Sx2Reach)
                {
                    shipDamage += 50;
                }
            }
            else if (Cy3 < Sy1 && Cy3 > Sy2)
            {
                if (C3Reach < Sx2Reach || C3Reach > Sx1Reach)
                {
                    shipDamage += 0;
                }
                else if (C3Reach == Sx1Reach || C3Reach == Sx2Reach)
                {
                    shipDamage += 50;
                }
                else if (C3Reach < Sx1Reach && C3Reach > Sx2Reach)
                {
                    shipDamage += 100;
                }
            }
        }
        Console.WriteLine("{0}%", shipDamage);
    }
}
