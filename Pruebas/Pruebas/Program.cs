using System;
using System.Linq;

class BirdCount
    {
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
        {
        this.birdsPerDay = birdsPerDay;
        }

    public static int[] LastWeek() => new int[]{0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount()
        {
        birdsPerDay[birdsPerDay.Length - 1] = birdsPerDay.Last() + 1;
        }

    public bool HasDayWithoutBirds()// => birdsPerDay.Contains(0);
        {
        foreach(var bird in birdsPerDay)
            {
            if(bird == 0)
                {
                return true;
                }
            }
        return false;
        }

    public int CountForFirstDays(int numberOfDays)//=> birdsPerDay.Take(numberOfDays).Sum();
        {
        int count = 0;
        for(int i = 0; i < numberOfDays; i++)
            {
            count += birdsPerDay[i];
            }
        return count;
        }

    public int BusyDays()//=> birdsPerDay.Count(day => day >= 5);
        {
        int busyDays = 0;
        foreach(var day in birdsPerDay)
            {
            if(day >= 5)
                {
                busyDays += 1;
                }
            }
        return busyDays;
        }
    }
