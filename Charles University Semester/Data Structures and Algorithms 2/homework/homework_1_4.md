# Homework 4 - String Rotation

A *rotation* of a string $\alpha$ is the string $\alpha[k:]\alpha[:k]$ (the last $|\alpha|-k$ characters of $\alpha$ preceding its last $k$) for some index $k$.

## TASK 1 - Propose a linear-time algorithm which, given two strings $\alpha$ and $\beta$, decides whether $\alpha$ is a rotation of $\beta$ for some $k$.

Example: $cdeab$ is a rotation of $abcde$, because it's $cde | ab$ and $ab$ is $a[:2]$ and $cde$ is $a[2:]$.

### The algorythm:

Step 1: $|\alpha| = |\beta|$, otherwise they can't be rotations of eachother, as rotation does not add or remove a character, it only changes the order of them.

Step 2: We concatenate $\beta$ with itself.
Example: $\beta = abcde; \beta + \beta = abcdeabcde$
In the concatenated string every 5 ($len(\beta)$) long substring is a rotaion of $\beta$.

starting posittion | 5-length substring
--- | ---
0 | abcde
1 | bcdea
2 | cdeab
3 | deabc
4 | eabcd
(5) | (abcde)

These are all the rotations of $\beta$.
So the concatenated string contains all the possible rotations.

Step 3: Now we can use KMP to find $\alpha$ in $\beta + \beta$.

In our previous example, $\alpha = cdeab$, our algorythm will find it returning True or the cut index.

```python
def is_rotation(alpha, beta):
    if len(alpha) != len(beta):
        return False

    return kmp_find(beta + beta, alpha) != -1
```
```python
def build_lps(pattern):
    lps = [0] * len(pattern)
    length = 0
    i = 1

    while i < len(pattern):
        if pattern[i] == pattern[length]:
            length += 1
            lps[i] = length
            i += 1
        elif length > 0:
            length = lps[length - 1]
        else:
            lps[i] = 0
            i += 1

    return lps


def kmp_find(text, pattern, start=0):
    if not pattern:
        return start

    lps = build_lps(pattern)
    i = start
    j = 0

    while i < len(text):
        if text[i] == pattern[j]:
            i += 1
            j += 1

            if j == len(pattern):
                return i - j

        elif j > 0:
            j = lps[j - 1]
        else:
            i += 1

    return -1
```

### Why it is linear
check the lengths - $O(1)$
construct $\beta$ + $\beta$ - $O(n)$
build the LPS table for $\alpha$ - $O(n)$
KMP search through $2n$ characters - $O(n)$

So in total it's:
$$O(1) + O(n) + O(n) + O(n) = O(n)$$

## TASK 2 - It should be relatively clear that a `True` response implies that $\alpha$ is a rotation of $\beta$. Prove the following: **Proposition:** If my process returns `False`, then $\alpha$ is not a rotation of $\beta$.

The equivalent statement: If $\alpha$ is a rotation of $\beta$, our algorithm finds it.

The doubled string contains all possible substrains created by concatenating a suffix and a prefix of $\alpha$.
So using the KMP on the doubled string will definitely find it and return `True`, if it exists.
If the algorythm return `False`, then it must not be a rotation.

## TASK 3 - Why does your process fail when looking for a rotation of $\beta$ *contained in* $\alpha$? Give an example.

The task was to decide if the entire string $\alpha$ is a rotation of $\beta$, not wether it is a smaller substring of it.
If $\beta$ contained $\alpha$ as a smaller substring, it would need to be at least 1 character longer, which would immediately return `False`.
Otherwise the problem would emerge from the concatenation, as $\beta + \beta$ would not contain all rotations of $\alpha$.