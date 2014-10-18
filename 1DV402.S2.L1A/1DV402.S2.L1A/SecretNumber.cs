using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7; //max antal gissningar

        private int _count;
        private int _number;
        
        public SecretNumber() //Hämtar det hemliga numret
        {
            Initialize();
        }

        public void Initialize() //skapar det hemliga nummret. Sätter start värde på count.
        {
            Random myRandom = new Random();
            _number = myRandom.Next(1, 101);

            _count = 0;
        }

        public bool MakeGuess(int number) //Skapar det som skrivs ut
        {   
            if(_count >= MaxNumberOfGuesses) // Kommer avbrytas när count är 7
            {
                throw new ApplicationException();
            }
            if (number < 1 || number > 100) // Talet måste vara mellan 1 och 100
            {
                throw new ArgumentOutOfRangeException();
            }

            _count++; 

            if(number == _number) //När det är skrivna talet är lika med det hemliga
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count); 
                return true;
            }
            else if(number > _number) //om den första satsen inte är sann, körs dessa. Inskrivna nummret är högre än det hemliga
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);
            }
            else//Inskrivna nummret är lägre än det hemliga
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);
            }
            
            if(_count == MaxNumberOfGuesses) //När man gissat 7 ggr avslöjas det hemliga talet.
            {
                Console.WriteLine("Det hemliga talet är {0}.", _number);
            }
            
            return false;
        }

        
    }
}
