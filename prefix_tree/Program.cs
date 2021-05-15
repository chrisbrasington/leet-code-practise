using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace twilio_prefix
{
   class Program
   {
      private static void PrefixTreeApproach(string[] areaCodes, string[] numbers)
      {
         string result = "";
         Stopwatch sw = new Stopwatch();
         sw.Start();

         // create trie
         Trie prefixTree = new Trie();
         foreach (string prefix in areaCodes)
         {
            prefixTree.Insert(prefix);
         }
         sw.Stop();
         Console.WriteLine($"Trie Creation Time: {sw.ElapsedTicks} ticks");
         sw.Reset();

         // search
         sw.Start();
         foreach (string num in numbers)
         {
            string prefix = prefixTree.Search(num);

            result += $"{prefix.PadRight(areaCodes[0].Length+1)} is the longest prefix given {num}\n";
         }

         sw.Stop();
         Console.WriteLine($"Trie Search Time:   {sw.ElapsedTicks} ticks");
         Console.WriteLine(result);
      }

      private static void ScanApproach(string[] areaCodes, string[] numbers)
      {
         string result = "";
         Stopwatch sw = new Stopwatch();
         sw.Start();
         
         // sort prefix array from longest to shortest
         Array.Sort(areaCodes, (x, y) => y.Length.CompareTo(x.Length));

         foreach (string num in numbers)
         {
            bool hit = false;
            foreach (string prefix in areaCodes)
            {
               if (num.StartsWith(prefix))
               {
                  // found hit
                  result += $"{prefix.PadRight(areaCodes[0].Length+1)} is the longest prefix given {num}\n";
                  hit = true;
                  break;
               }
            }

            // found no matching prefix
            if (!hit)
            {
               result += $"{" ".PadRight(areaCodes[0].Length + 1)} is the longest prefix given {num}\n";
            }
         }
         

         sw.Stop();
         Console.WriteLine($"Scan Approach Time: {sw.ElapsedTicks} ticks");
         Console.WriteLine(result);
      }

      static void Main(string[] args)
      {
         string[] areaCodes = new string[] { "213", "21358", "1234", "12" };
         string[] numbers = new string[] { "21349049", "1204539492", "123490485904", "123", "1" };

         ScanApproach(areaCodes,numbers);
         PrefixTreeApproach(areaCodes, numbers);
      }
   }
}
