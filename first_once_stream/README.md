# first character appearing once in stream

Exercise:
```
Find the first character appearing only once in a stream, *e.g.*: "ACBA
```

The character needs to be a unique key, so a dictionary is apt. The order needs to be maintained, but you can assume the stream is gigantic and you can't store the stream. You can use an Ordered-Dictionary or in my case the order index is part of the value. Frequency needs to be known in regards to did it occur once or more, so this can be a value of boolean.

Starting psuedo-code:
```
public static char findFirstUnique (Reader input)

int input.read() < 0: end; >= 0: can cast to char

input.read() = 65 = 'A';
input.read() = 67 = 'C';
input.read() = 66 = 'B';
input.read() = 65 = 'A';
input.read() -1
```

Dictionary Value Representation:
```
Dictionary<char, OrderedFrequency> [...]

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

```

Output:
```
Input: ACBA
C character is the first character to appear once in the stream

Input: aaaaaaaaaaaabbbbbbaaaaaaaaccccccccccccccccccdeeeeeeeeeeeeef
d character is the first character to appear once in the stream

Input: 1122
No character occurs once in the stream
```