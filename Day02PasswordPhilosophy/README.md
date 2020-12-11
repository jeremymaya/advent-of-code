# Day 2: Password Philosophy

[Advent of Code - Day 2: Password Philosophy](https://adventofcode.com/2020/day/2)

Author: Kyungrae Kim

---

## Problem Domain

Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via `toboggan`.

The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day. "Something's wrong with our computers; we can't log in!" You ask if you can take a look.

Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the Official Toboggan Corporate Policy that was in effect when they were chosen.

To try to debug the problem, they have created a list (your puzzle input) of `passwords` (according to the corrupted database) and `the corporate policy when that password was set`.

For example, suppose you have the following list:

```text
1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc
```

Each line gives the password policy and then the password. The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid. For example, `1-3 a` means that the password must contain `a` at least `1` time and at most 3 times.

In the above example, `2` passwords are valid. The middle password, `cdefg`, is not; it contains no instances of b, but needs at least 1. The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

`How many passwords are valid` according to their policies?

---

## Approach

1. Import the text file containing passwords
2. Going a line by line, parse each line using Split()
3. Compare the given letter char against the password and count the occurrence
4. Check if the occurrence is within the lowest and highest
5. If the password is valid, increment the valid password count
6. Return the valid password count

---

## Efficiency

|  | Time | Space |
|:-|:-|:-|
| PasswordPhilosophy() | O(n * m) | O(1) |

* Time Complexity: O(n * m) where m is the longest length of the password
* Space Complexity: O(1), string arrays were used to hold fixed number of strings at a time

---

## Solution

```c#
static int PasswordPhilosophy(string path)
{
    int valid = 0;

    try
    {
        using var sr = new StreamReader(path);
        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(' ');
            string[] range = line[0].Split('-');

            int appear = CountLetter(line[1][0], line[2]);

            if (appear >= Int32.Parse(range[0]) && appear <= Int32.Parse(range[1]))
                valid++;
        }
    }
    catch (Exception)
    {

        throw;
    }

    return valid;
}

static int CountLetter(char letter, string password)
{
    int appear = 0;

    for (int i = 0; i < password.Length; i++)
        if (letter == password[i])
            appear++;

    return appear;
}
```

---

## Link to Code

[Day02PasswordPhilosophy](./Day02PasswordPhilosophy/Program.cs)

---

## References

* [Advent of Code - Day 2: Password Philosophy](https://adventofcode.com/2020/day/2)
* [Microsoft - How to separate strings using String.Split in C#](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split)
