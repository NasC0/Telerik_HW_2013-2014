using System;

class BitTowerOfDoom
{
    static int ZeroBit(int value, int position)
    {
        return value & ~(1 << position);
    }

    static int OneBit(int value, int position)
    {
        return value | (1 << position);
    }
    static bool CheckBit(int value, int position)
    {
        return ((value >> position) & 1) == 1;
    }
    static int Reverse(int x)
    {
        int y = 0;
        for (int i = 0; i < 8; ++i)
        {
            y <<= 1;
            y |= (x & 1);
            x >>= 1;
        }
        return y;
    }
    static void Main()
    {
        int[] car = new int[8];
        int knights = 0;
        for (int i = 0; i < 8; i++)
        {
            car[i] = int.Parse(Console.ReadLine());
            car[i] = Reverse(car[i]);
            for (int j = 0; j < 8; j++)
            {
                if (CheckBit(car[i], j))
                {
                    knights++;
                }
            }
        }
        int survivingKnights = knights;
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
            {
                break;
            }
            int selectCar = int.Parse(Console.ReadLine());
            int selectPosition = int.Parse(Console.ReadLine());
            string order = Console.ReadLine();
            int orderCar = int.Parse(Console.ReadLine());
            int orderPosition = int.Parse(Console.ReadLine());
            if (CheckBit(car[selectCar], selectPosition))
            {
                if (orderPosition > 7 || orderPosition < 0)
                {
                    if (orderCar >= 2)
                    {
                        survivingKnights--;
                        car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                    }
                    else
                    {
                        car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                    }
                }
                else
                {
                    if (order == "kill")
                    {
                        if (CheckBit(car[orderCar], orderPosition))
                        {
                            survivingKnights--;
                            car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                            continue;
                        }
                        if (CheckBit(car[orderCar], orderPosition + 1) && CheckBit(car[orderCar], orderPosition - 1))
                        {
                            if (selectCar == orderCar)
                            {
                                car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                                if (CheckBit(car[orderCar], orderPosition + 1) && CheckBit(car[orderCar], orderPosition - 1))
                                {
                                    survivingKnights--;
                                    continue;
                                }
                            }
                            else
                            {
                                survivingKnights--;
                                car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                                continue;
                            }
                        }
                        if (CheckBit(car[orderCar], orderPosition + 1))
                        {
                            survivingKnights -= 2;
                            car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                            car[orderCar] = ZeroBit(car[orderCar], orderPosition + 1);
                            continue;
                        }
                        if (CheckBit(car[orderCar], orderPosition - 1))
                        {
                            survivingKnights -= 2;
                            car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                            car[orderCar] = ZeroBit(car[orderCar], orderPosition - 1);
                            continue;
                        }
                        car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                        car[orderCar] = OneBit(car[orderCar], orderPosition);
                    }
                    else if (order == "move")
                    {
                        if (CheckBit(car[orderCar], orderPosition) || CheckBit(car[orderCar], orderPosition + 1) || CheckBit(car[orderCar], orderPosition - 1))
                        {
                            survivingKnights--;
                            car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                        }
                        else
                        {
                            car[selectCar] = ZeroBit(car[selectCar], selectPosition);
                            car[orderCar] = OneBit(car[orderCar], orderPosition);
                        }
                    }
                }
            }
        }
        int finalCount = 0;
        for (int i = 0; i < 8; i++)
        {
            car[i] = Reverse(car[i]);
            finalCount += car[i];
        }
        Console.WriteLine(knights);
        Console.WriteLine(survivingKnights);
        Console.WriteLine(finalCount);
    }
}
