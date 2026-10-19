# Homework 3 - Censorship

A censor receives a long text $t$ and a set of forbidden substrings $J$ which must be removed therefrom. While a forbidden substring exists in $t$, the censor repeatedly removes the first occurrence of a forbidden substring from the text. Here, the first occurrence is the one with the earliest final character; if there are multiple, the longest such occurrence is chosen.

We seek an algorithm which does this in at most linear time relative to the input size.

## TASK 1. - A naive procedure is to use the Aho–Corasick algorithm to find the first forbidden substring, remove it and repeat from the beginning. Provide an example on which this process takes longer than linear time.

Our forbidden pattern are: $J = {ab}$

And our text is: $t = aaa...bbb... = a^nb^n$

Example:
fund string | remaining string
--- | ---
(start) | aaaabbbb
ab | > aaabbb
ab | > aabb
ab | > ab
ab | > empty

At each step $ab$ is at the boundary of the $a$-s and $b$-s.

Because the algorythm restart after every find, it scans $n + 1$ characters to find the first $ab$, $n$ characters to find the next, and so on, until the last 2 characters.

So, the total scanning time is:
$$ (n+1) + n + ... + 2 = \Theta(n^2)$$

This means, the algorythm takes quadratic time depending on the input size.

## TASK 2. - What is the textbook time complexity of Aho–Corasick itself? Is it suitable for our goals?

The textbook time complexity of Aho-COrasick is:
$$O(n + L + z)$$
Where:
- $n$ is the text length
- $L$ is the total length of the forbidden strings
- $z$ is the number of reported occurences in the text

I think, that reporting every occurence is not suitable for our goals, because $z$ can be much larger than the input size.

Example: 

$t = aa...a = a^n$
$J = {a, aa, aaa, ... a^k}$

A forbidden string of length $j$ occurs in the text $n-j+1$ times. The total number of occurences:

$$z=n+(n-1)+\cdots+(n-k+1).$$

There are k terms, and if $n\ge 2k$, each term is between roughly $n/2$ and $n$, then:

$$
\frac{nk}{2}\le z\le nk
$$

Which means $z=\Theta(nk)$.

Comparing this to the input size:
- text has $n$ characters
- the forbidden string together have $1 + 2 + ... + k = k(k+1)/2$ characters

So the input size is $\Theta(n + k^2)$

Taking $n=k^2$ gives $\Theta(k^3)$ occurrences for an input of size $\Theta(k^2)$.

## TASK 3. - Describe an algorithm which censors the text in at most linear time *in the size of the input*.