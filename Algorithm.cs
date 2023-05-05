using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigMovies
{
    public class Algorithm
    {
        public string analysis;
        public string Alg1(int value3)
        {
            if (value3 <= 5)
            {
                return "Certified Banger";
            }
            else if (value3 <= 10)
            {
                return "Very good movie";
            }
            else if (value3 <= 20)
            {
                return "Pretty good movie";
            }
            else if (value3 <= 30)
            {
                return "Leaning towards artsy";
            }
            else
            {
                return "This movie is either extremely artsy or it's been review bombed";
            }
        }

        public string Alg2(int value3)
        {
            if (value3 <= 5)
            {
                return "Really good movie";
            }
            else if (value3 <= 10)
            {
                return "An unbelievably mid movie or cult classic";
            }
            else if (value3 <= 20)
            {
                return "It's a coin toss. This movie is either the greatest film of all time or the biggest snooze fest your ever likely to experience";
            }
            else if (value3 <= 30)
            {
                return "TRUST ME THIS MOVIE IS AMAZING";
            }
            else 
            {
                return "This movie is highly likely to be terrible don't watch";
            }
        }

        public string Alg3(int value3)
        {
            if (value3 <= 5)
            {
                return "Average movie";
            }
            else if (value3 <= 10)
            {
                return "Some pleasure will be had watching this";
            }
            else if (value3 <= 20)
            {
                return "Masterpiece right here, watch it now";
            }
            else if (value3 <= 30)
            {
                return "Masterpiece or Terrible. It should be evident which one after looking at the trailer";
            }
            else
            {
                return "If you like fast and furious this shit gonna be fire";
            }
        }

        public string Alg4(int value3)
        {
            if (value3 <= 5)
            {
                return "Bad movie, don't watch";
            }
            else if (value3 <= 10)
            {
                return "This movie is definitley not good in any possible way";
            }
            else if (value3 <= 20)
            {
                return "This movie will be a 10/10 trust me";
            }
            else if (value3 <= 30)
            {
                return "A dumb movie that could be alot of fun";
            }
            else
            {
                return "If the audience score is higher this movie is for sure alot of dumb fun";
            }
        }

        public string Alg5(int value3)
        {
            if (value3 <= 5)
            {
                return "Terrible movie";
            }
            else if (value3 <= 10)
            {
                return "Awful movie";
            }
            else if (value3 <= 20)
            {
                return "Most Likely an abhorrent viewing experience";
            }
            else if (value3 <= 30)
            {
                return "Terrible or average, don't watch either way";
            }
            else
            {
                return "Dumb box office movie that critics hate and audience love, if you like those kinda movies then go right ahead";
            }



        }
    }
}