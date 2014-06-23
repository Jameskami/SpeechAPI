using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using SpeechAPI;

namespace voices
{
    class Program
    {
           
        static void Main(string[] args)
        {
            Predicate<string> check = (s) => s.ToUpper().IndexOf("YES") != -1 || s.ToUpper().IndexOf("YEAH") != -1 || s.ToUpper().IndexOf("YEP") != -1;
            "Have you ever traveled by plane?".Aloud();
            //use error handling with the Listen method because it can throw an error
            string question = "";
            try 
            {
                question = SpeechSynthRecognition.Listen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (check(question))
            {
                "I'm glad to hear that".Aloud();
                Console.WriteLine("Your answer: " + question);
            }
            else
            {
                "I'm sorry. I hear flying is fantastic".Aloud();
                Console.WriteLine("Your answer: " + question);
            }
            "I am a machine and not very smart, and may not have heard you correctly, so if you want to try again, say 'try again'".Aloud();
            string choice = "";
            try
            {
                choice = SpeechSynthRecognition.Listen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (choice.ToUpper().IndexOf("AGAIN") != -1)
            {
                Main(new string[0]); 
            }
        }
    }
}