# Homework 1 — Interleaving Strings

We say that a string $w$ is an *interleaving* of strings $u$ and $v$ if $u$ occurs as a subsequence of $w$ (not necessarily contiguously) and removing that subsequence leaves $v$. In other words:

- $w$ contains every character occurrence in $u$ and $v$ exactly once;
- $w$ contains no additional characters;
- the characters from each of $u$ and $v$ appear in $w$ in their original order.

For example, if $u = \texttt{abcba}$ and $v = \texttt{babcca}$, then the following strings are interleavings of them:

$$
\texttt{abcbababcca}, \qquad \texttt{ababcbcbcaa}.
$$

The subsequence associated with $u$ or $v$ need not be unique: the second example admits more than one assignment of characters to the two source strings.

## Task 1: Give an example input which would take exponential time to solve naively.

### The naive algorythm:

```python
def interleave(u, v, w):
    # if the lengths of the 2 strings dont add up to the third, there is no way they can interlieve by our definition
    # since if there are fewer characters than the sum, there must be an extra character somewhere
    # if the sum is bigger, then there is no way all characters are used
    if len(u) + len(v) != len(w):
        return False

    # this function uses two pointers, one for each string
    # for every step/increment it calls itself creating a recursion
    # until either both substrings have ended, returning True
    # or if they havent ended but the next character is not a part of any of the substrings, then returns False
    def check(i, j):
        if i == len(u) and j == len(v):
            return True

        if i < len(u) and u[i] == w[i + j]:
            if check(i + 1, j):
                return True

        if j < len(v) and v[j] == w[i + j]:
            if check(i, j + 1):
                return True

        return False

    # we call the function for (0, 0) to start from the first character of w
    return check(0, 0)
```

## The exponential example:

For an integer $k \ge 1$, let

$$
u = aaa...ab = a^k b, \qquad 
$$
$$
v = aaa...ac = a^k c, \qquad
$$
$$
w = aaa...abca = a^{2k-1}bca.
$$

## The binary recursion tree

Our previous naive algorythm would create a binary recursion tree. The nodes are function calls.

The call at node $(i,j)$ can create two children:

- $(i+1,j)$, taking the next character from $u$;
- $(i,j+1)$, taking the next character from $v$.

In our example a full binary tree is created through $k$ levels, since for $k$ copies of $a$, both function calls match:

| Depth | States represented by the calls | Number of calls |
| --- | --- | --- |
| $0$ | $(0,0)$ | $1$ |
| $1$ | $(0,1),\ (1,0)$ | $2$ |
| $2$ | $(0,2),\ (1,1),\ (1,1),\ (2,0)$ | $4$ |
| $\vdots$ | $\vdots$ | $\vdots$ |
| $k$ | ... | $2^k$ |

## How many calls?

$S$ = the sum

$$
S = 1 + 2 + 4 + \cdots + 2^k.
$$

Multiplying by $2$ gives

$$
2S = 2 + 4 + 8 + \cdots + 2^k + 2^{k+1}.
$$

Subtracting the first equation from the second cancels the middle part:

$$
S = 2S-S = 2^{k+1}-1.
$$

This counts only calls through depth $k$. There may be additional calls below that depth, so the total number of calls is at least: ($2^{k+1}-1$).

So, the time it takes to compute the output is exponentially depended on the input lengths.

## Task 2: Describe an algorithm which is guaranteed to terminate in polynomial time.

The idea: Use dynamic programming to store whether each pair of remaining suffixes can form the remaining suffix of $w$.

$m=|u|$ and $n=|v|$. 

Define $\text{table}[i][j]$ to be true exactly when the suffixes $u[i:]$ and $v[j:]$ can interleave to form $w[i+j:]$.

## Python implementation

```python
def interleave(u, v, w):
    # same as Task 1
    if len(u) + len(v) != len(w):
        return False

    # initialize all cells of the table to be False
    table = [[False] * (len(v) + 1) for _ in range(len(u) + 1)]
    # except: the bottom right corner is True, we'll start from there
    table[len(u)][len(v)] = True

    # starting at the bottom right cells
    for i in range(len(u), -1, -1):
        # moving right to left, then bottom-up
        for j in range(len(v), -1, -1):
            if (
                i < len(u) # havent reached the end (really teh beginning) of u
                and u[i] == w[i + j] # current char of u matches the next in w
                and table[i + 1][j] # and the cell below is True, inidicating the suffix is ok
            ):
                table[i][j] = True # then it works -> True

            if (
                j < len(v) # havent reached the end of v
                and v[j] == w[i + j] # the char matches
                and table[i][j + 1] # and the cell to the right is True, indicating the suffix is ok
            ):
                table[i][j] = True # then it works -> True

    # if we "managed to make it through a path of True-s to [0][0], and got True for that one aswell, they are interleaving
    return table[0][0]
```
## Full explanation:

### Initialization

If $|u|+|v|\ne |w|$, return False.

Else, create a table with $(m+1)$ rows and $(n+1)$ columns, initially filled with `False`. Set

$$
\text{table}[m][n]=\mathrm{True}.
$$

This represents that two empty suffixes interleave to form the empty suffix of $w$.

## Filling the table

Process rows and columns backward. At the cell $(i,j)$, the next required character is $w[i+j]$. Either of the following makes the state true:

- Take the character from $u$: $i<m$, $u[i]=w[i+j]$, and $\text{table}[i+1][j]$ is true.
- Take the character from $v$: $j<n$, $v[j]=w[i+j]$, and $\text{table}[i][j+1]$ is true.

Because the loops run backward, the neighboring states needed for each decision have already been computed. The final answer is $\text{table}[0][0]$.

## Example:
$u = aabcc$

$v = dbbca$

$w = aadbbcbcac$

The table:

| $u \backslash v$ | $0$: d | $1$: b | $2$: b | $3$: c | $4$: a | $5$: ∅ |
|---|---|---|---|---|---|---|
| $0$: a | **T**| F| F| F| F| F|
| $1$: a | T| F| F| F| F| F|
| $2$: b | T| T| T| F| F| F|
| $3$: c | F| T| T| F| T| F|
| $4$: c | F| F| T| T| T| T|
| $5$: ∅ | F| F| F| F| F| T|

# Task 3: Prove the polynomial time complexity of your algorithm.

The table contains $(m+1)(n+1)$ cells. Initializing the table takes $O((m+1)(n+1))$ time. The nested loops visit each cell exactly once, performing a constant number of comparisons, lookups, and assignments per cell. Therefore, the total running time is $O((m+1)(n+1))$. If $N$ is the total input length, then $m,n\le N$, so this is $O(N^2)$, which is polynomial.