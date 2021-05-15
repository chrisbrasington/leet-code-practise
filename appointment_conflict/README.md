https://stackoverflow.com/questions/65580609/given-a-list-of-appointments-find-all-the-conflicting-appointments

Given appointment ranges of days, find conflicts.

I saw this exercise a few places, and I wanted to go a bit extra and add an optional visualization peice.

```
input:
[[3, 7], [2, 6], [10, 15], [5, 6]]

calendar:
2  3  4  5  6  7  8  9  10 11 12 13 14 15
   3-----------7
2-----------6
                        10-------------15
         5--6
         
output:
[3, 7] conficts with [2, 6]
[3, 7] conficts with [5, 6]
[2, 6] conficts with [5, 6]
```

```
input:
[[4, 5], [2, 3], [3, 6], [5, 7], [7, 8]]

calendar:
2  3  4  5  6  7  8
      4--5
2--3
   3--------6
         5-----7
               7--8

output:
[4, 5] conficts with [3, 6]
[3, 6] conficts with [5, 7]
```
```
input:
[[1, 5], [3, 7], [2, 6], [10, 15], [5, 6]]

calendar:
1  2  3  4  5  6  7  8  9  10 11 12 13 14 15
1-----------5
      3-----------7
   2-----------6
                           10-------------15
            5--6

output:
[1, 5] conficts with [3, 7]
[1, 5] conficts with [2, 6]
[3, 7] conficts with [2, 6]
[3, 7] conficts with [5, 6]
[2, 6] conficts with [5, 6]
```