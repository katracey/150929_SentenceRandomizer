using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _150929_StreamReaderPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are to create a text file that includes 3 lines.The first line has nouns, the second has verbs, 
            //the third has prepositional phrases. Split each entry in a particular line with commas
            //(comma separated values).After creating this in your project, read lines 1, 2, and 3 into 3 separate arrays, splitting them on commas.

            WriteSentence(RandomizeSentence());
        }

        static void WriteSentence(string sentence)
        {

            //Write to console
            Console.WriteLine(sentence);
            //Write to text file
            StreamWriter writer = new StreamWriter("..\\..\\SentenceOutput.txt", true, Encoding.GetEncoding("Windows-1251"));
            using (writer)
            {
                writer.WriteLine(sentence);
            }           

        }

        static string RandomizeSentence()
        {
            // Create an instance of StreamReader to read from a file
            StreamReader reader = new StreamReader("..\\..\\NounsVerbsPreps.txt");

            //splitting line values into string arrays, assigning to correct part of sentence
            string line = reader.ReadLine();
            string[] nouns = line.Split(',');
            line = reader.ReadLine();
            string[] verbs = line.Split(',');
            line = reader.ReadLine();
            string[] prepositions = line.Split(',');
            reader.Close();

            //Generating random numbers for each argument in BuildSentence()
            Random ranNoun = new Random();
            int nounNum = ranNoun.Next(0, (nouns.Length - 1));
            Random ranVerb = new Random();
            int verbNum = ranVerb.Next(0, (verbs.Length - 1));
            Random ranPrep = new Random();
            int prepNum = ranPrep.Next(0, (prepositions.Length - 1));

            //Calling BuildSentence() to put it together                      
            string newSentence = BuildSentence(nouns[nounNum], verbs[verbNum], prepositions[prepNum]);

            return newSentence;
        }

        static string BuildSentence(string noun, string verb, string preposition)
        {
            //Use StringBuilder to combine the sentence parts.
            StringBuilder sentence = new StringBuilder();
            string sentenceResult = Convert.ToString(sentence.Append(noun + " " + verb + " " + preposition + "."));
            sentenceResult = sentenceResult.Trim(' ');
            return sentenceResult;
        }
    }
}
