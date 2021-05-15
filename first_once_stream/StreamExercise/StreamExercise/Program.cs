using System;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;

namespace StreamExercise
{
   public class OrderedFrequency
   {
      /// <summary>
      /// index representing order
      /// </summary>
      public int Index { get; set; }

      /// <summary>
      /// if sinlge is false, value occurred multiple times
      /// </summary>
      public bool Single { get; set; } 

      public OrderedFrequency(int index)
      {
         this.Index = index;
         Single = true;
      }
   }

   class Program
   {
      public static void Print(string input, char? first)
      {
         Console.WriteLine($"Input: {input}");

         if (first == null)
         {
            Console.WriteLine("No character occurs once in the stream");
         }
         else
         {
            Console.WriteLine($"{first} character is the first character to appear once in the stream");
         }
         Console.WriteLine();
      }
      public static char? FindFirstUnique(string input)
      {
         byte[] byteArray = Encoding.UTF8.GetBytes(input);
         MemoryStream stream = new MemoryStream(byteArray);
         return FindFirstUnique(new StreamReader(stream));
      }
      public static char? FindFirstUnique(StreamReader input)
      {
         Dictionary<char, OrderedFrequency> frequency = new Dictionary<char, OrderedFrequency>();

         int index = 0;

         while (!input.EndOfStream)
         {
            // casting int to char, using string as dictionary key
            char c = (char)input.Read();

            if(frequency.ContainsKey(c) && frequency[c].Single)
            {
               // occurred more than once
               frequency[c].Single = false;
            }
            else
            {
               frequency[c] = new OrderedFrequency(index);
               index++;
            }
         }

         foreach(KeyValuePair<char, OrderedFrequency> f in frequency.OrderBy(i => i.Value.Index))
         {
            if((f.Value as OrderedFrequency).Single)
            {
               return f.Key;
            }
         }

         return null;
      } 

      static void Main(string[] args)
      {
         string input = "ACBA";
         char? first = FindFirstUnique(input);
         Print(input, first);

         string input2 = "aaaaaaaaaaaaaaabbbbbbaaaaaaaaaaaaaccccccccccccccccccdeeeeeeeeeeeeef";
         Print(input2, FindFirstUnique(input2));

         string input3 = "1122";
         Print(input3, FindFirstUnique(input3));
      }
   }
}
