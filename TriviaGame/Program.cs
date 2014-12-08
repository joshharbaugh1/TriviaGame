using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //The logic for your trivia game happens here
            int answersCorrect = 0;
            int answersWrong = 0;
            List<Trivia> AllQuestions = GetTriviaList();
            Random rng = new Random();
            Console.WriteLine("TRIVIA GAME \n\n\n");
            Console.WriteLine("Well hello there... Welcome to the worst trivia game you will ever play.");
            Console.WriteLine("Seriously though.. it's reallyyyy awful.");
            Console.WriteLine("But give it a whirl if you feel up to the challenge.. \n");
            Console.WriteLine("You have 10 trivia questions to answer.");
            Console.WriteLine("<Press any key to continue>");
            Console.ReadKey(true);
            Console.Clear();
            for (int i = 0; i < 10; i++ )
            {
                Trivia Question = AllQuestions[rng.Next(0, AllQuestions.Count())];
                Console.WriteLine(Question.Question);
                if (Console.ReadLine() == Question.Answer)
                {
                    Console.WriteLine("You got it right, you must have looked up the answer...");
                    answersCorrect++;
                    Console.WriteLine("<Press any key to continue>");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("You got it wrong, but this is really hard. So its goood.");
                    answersWrong++;
                    Console.WriteLine("<Press any key to continue>");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            Console.WriteLine("Answers Right: " + answersCorrect);
            Console.WriteLine("Answers Wrong: " + answersWrong);
            Console.WriteLine();
            Console.WriteLine("You have completed the hardest game ever created!");
            Console.WriteLine("I'm very sorry if this was a horrible experience for you.");
            Console.ReadKey();
        }


        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.
            
            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.

            for (int i = 0; i < contents.Count; i++)
            {
                Trivia newTrivia = new Trivia(contents[i]);
                returnList.Add(newTrivia);
            }
            
            // Example: Trivia newTrivia = new Trivia("what is my name?*question");
            //Return the full list of trivia questions
            return returnList;
        }
    }

    public class Trivia
    {
        private string _question;
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        //TODO: Fill out the Trivia Object

        //The Trivia Object will have 2 properties
        // at a minimum, Question and Answer

        //The Constructor for the Trivia object will
        // accept only 1 string parameter.  You will
        // split the question from the answer in your
        // constructor and assign them to the Question
        // and Answer properties

        public Trivia(string superDankQuestions)
        {
            this.Question = superDankQuestions.Split('*')[0];
            this.Answer = superDankQuestions.Split('*')[1];
        }
    }
}
