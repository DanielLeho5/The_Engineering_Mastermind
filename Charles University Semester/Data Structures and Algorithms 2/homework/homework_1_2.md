# Homework 2 - Gap Character string search

Suppose we allow the pattern $P$ to contain occurrences of a *gap character* $\ast$ that can match an arbitrary string of characters (including the empty string).

For example, the pattern $P = \texttt{ab}\ast\texttt{ba}\ast\texttt{c}$ occurs in the text $T = \texttt{cabccbacbacab}$ as `ab[cc]ba[cba]c` and as `ab[ccbac]ba[]c` (the square brackets contain the string corresponding to the gap character $\ast$).

Note that the gap character may occur an arbitrary number of times in the pattern but not at all in the text.

Give a linear-time algorythm to determine whether such a pattern $P$ occurs in a given text $T$.

There are at least three different approaches to solve this problem. Describe two of them and justify their asymptotic running times.

## Task 1:  Describe an algorithm to determine whether such a pattern $P$ occurs in a given text $T$ and prove that it terminates in linear time.

Plan: split the pattern into blocks at the gap characters. Use KMP to find the first occurrence of each block in the original text, starting immediately after the previous matched block.

## The LPS table

For every position `i` in the pattern, `lps[i]` is the length of the longest proper suffix of `pattern[:i + 1]` that is also a prefix of that substring.

### Examples

1. `abcd`

| Index | 0 | 1 | 2 | 3 |
|---|---|---|---|---|
| Character | a | b | c | d |
| LPS | 0 | 0 | 0 | 0 |

2. `aaaa`

| Index | 0 | 1 | 2 | 3 |
|---|---|---|---|---|
| Character | a | a | a | a |
| LPS | 0 | 1 | 2 | 3 |

3. `ababa`

| Index | 0 | 1 | 2 | 3 | 4 |
|---|---|---|---|---|---|
| Character | a | b | a | b | a |
| LPS | 0 | 0 | 1 | 2 | 3 |

4. `abcab`

| Index | 0 | 1 | 2 | 3 | 4 |
|---|---|---|---|---|---|
| Character | a | b | c | a | b |
| LPS | 0 | 0 | 0 | 1 | 2 |

5. `aabaaab`

| Index | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|---|---|---|---|---|---|---|---|
| Character | a | a | b | a | a | a | b |
| LPS | 0 | 1 | 0 | 1 | 2 | 2 | 3 |

6. `ababaca`

| Index | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|---|---|---|---|---|---|---|---|
| Character | a | b | a | b | a | c | a |
| LPS | 0 | 0 | 1 | 2 | 3 | 0 | 1 |

## algorythm for building the LPS table

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
```

1. Initialize `lps` with zeros.
2. Set `length` to 0. It stores the length of the current matching prefix and suffix.
3. Start at `i = 1`, because `lps[0]` is always 0: a single character has no nonempty proper suffix.
4. If `pattern[i] == pattern[length]`, increment `length`, store it in `lps[i]`, and advance `i`.
5. If the characters dont match and `length > 0`, set `length = lps[length - 1]` and retry the same character with the next shorter possible matching prefix.
6. Otherwise, set `lps[i]` to 0 and increment `i`.
7. Return `lps` when all positions have been processed.

## Using the LPS table to search for a block

```python
def kmp_find(text, pattern, start):
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
                # Return the starting index of the matched block.
        elif j > 0: 
            # If the characters do not match, 
            # keep the text index unchanged and 
            # use the LPS table to shorten the current match.
            j = lps[j - 1]
        else:
            i += 1
    return -1 # No occurrence was found.
```

1. If `pattern` is empty, return `start`.
2. Build the LPS table and initialize the text index `i` to `start` and the pattern index `j` to 0.
3. Compare `text[i]` with `pattern[j]`. If they match, advance both indices.
4. If `j == len(pattern)`, the entire block has matched. Return its starting index, `i - j`.
5. If the characters dont match and `j > 0`, set `j = lps[j - 1]` and retry the same text character.
6. Otherwise, advance `i`.
7. If no occurrence is found, return `-1`.

## Using this function to identify our blocks

```python
def gap_pattern_occurs(text, pattern):
    position = 0
    for block in pattern.split("∗"):
        if not block:
            continue
        match_start = kmp_find(text, block, position)
        if match_start == -1:
            return False
        position = match_start + len(block)
    return True
```

Putting it all together:

1. `position` stores the position immediately after the previous matched block. Initially, it is 0.
2. Split the pattern into blocks at the gaps.
3. Skip empty blocks.
4. Find the first occurrence of each block starting at `position`.
5. If no occurrence exists, return `False`.
6. Otherwise, update `position` to immediately after the matched block.
7. If all blocks are found, return `True`.

## Why it is linear

Let $n = |T|$ and $m = |P|$.

Splitting the pattern into blocks takes $O(m)$ time. Building an LPS table takes time proportional to the block's length. Since the total length of all blocks is at most $m$, building all LPS tables takes $O(m)$ time.

Each KMP search starts immediately after the previous matched block, so different searches scan disjoint portions of the text. If a search fails, the algorythm stops. Therefore, the text index advances at most $n$ times across all searches.

KMP's fallback steps also take $O(n)$ time altogether: each fallback decreases the number of matched characters, and that number can increase only when the text index advances.

So, the total time is:

$$

O(m) + O(m) + O(n) = O(n+m).

$$
## Task 2: Propose a second approach.

Plan: split the pattern into blocks at the gap characters. Use a modified Z-algorythm to find the first occurrence of each block, starting immediately after the previous matched block.

We stop each search as soon as the first occurrence is found.

## The Z-array

For a string $S$, the value $Z[i]$ is the length of the longest substring starting at position $i$ that matches a prefix of $S$.

We use the convention $Z[0] = 0$.

### Example

For $S = \texttt{abacaba}$:

| Index | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|---|---|---|---|---|---|---|---|
| Character | a | b | a | c | a | b | a |
| Z | 0 | 0 | 1 | 0 | 3 | 0 | 1 |

For example, $Z[4] = 3$ because the substring starting at index 4 is `aba`, which matches the first three characters of the string.

## Using the Z-array to search for a block

To search for a block $B$ in the remaining text, we conceptually construct:

$$
S = B + \$ + T[\text{start}:],
$$

where $\$$ is a separator that does not appear in either string.

If a position $i$ in the text part satisfies

$$
Z[i] = |B|,
$$

then the entire block matches there.

Its starting index in the original text is:

$$
\text{match\_start} = \text{start} + i - |B| - 1.
$$

We process positions from left to right, so the first such position gives the first occurrence.

To keep the total running time linear, we do not copy the remaining text or allocate the entire Z-array in advance. Instead, we access the conceptual string through indices and build only the part of the array needed before finding a match.

## Modified Z-algorythm for finding the first occurrence

The algorythm maintains an interval `[left, right)`, called a Z-box. The substring inside this interval matches a prefix of the conceptual string.

If the current position is inside this interval, we reuse an earlier Z-value to avoid repeating comparisons. We then extend the match if possible.

```python
def z_find(text, pattern, start):
    if not pattern:
        return start

    block_length = len(pattern)
    total_length = block_length + 1 + len(text) - start

    def char_at(index):
        if index < block_length:
            return pattern[index]
        if index == block_length:
            return "$"
        return text[start + index - block_length - 1]

    z = [0]
    left = 0
    right = 0

    for i in range(1, total_length):
        match_length = 0

        if i < right:
            match_length = min(right - i, z[i - left])

        while (
            i + match_length < total_length
            and char_at(match_length) == char_at(i + match_length)
        ):
            match_length += 1

        z.append(match_length)

        if i + match_length > right:
            left = i
            right = i + match_length

        if i > block_length and match_length == block_length:
            return start + i - block_length - 1

    return -1
```

1. If the pattern is empty, return the starting position.
2. Treat the block, separator, and remaining text as one string without copying them.
3. Process its positions from left to right.
4. If a position is inside the current Z-box, reuse an earlier Z-value.
5. Compare characters to extend the match where necessary.
6. Update the Z-box if the new match extends farther.
7. If the entire block matches at a text position, immediately return its starting index.
8. If no occurrence is found, return `-1`.

## Using this function to identify our blocks

```python
def gap_pattern_occurs(text, pattern):
    position = 0

    for block in pattern.split("∗"):
        if not block:
            continue

        match_start = z_find(text, block, position)

        if match_start == -1:
            return False

        position = match_start + len(block)

    return True
```

Putting it all together:

1. `position` stores the position immediately after the previous matched block. Initially, it is 0.
2. Split the pattern into blocks at the gaps.
3. Skip empty blocks.
4. Find the first occurrence of each block starting at `position`.
5. If no occurrence exists, return `False`.
6. Otherwise, update `position` to immediately after the matched block.
7. If all blocks are found, return `True`.

## Why it is linear

Let $n = |T|$ and $m = |P|$.

Splitting the pattern into blocks takes $O(m)$ time.

The Z-algorythm avoids repeatedly comparing characters inside an already known matching interval. Comparisons that extend that interval move its right boundary forward. Since the boundary never moves backward, the total work is linear in the portion of the conceptual string examined.

For a block of length $b$, suppose its first occurrence ends $q$ characters after the search's starting position. The search examines at most $O(b+q)$ characters of the conceptual string, so it takes $O(b+q)$ time.

The next block's search starts immediately after that occurrence. Therefore, the text portions consumed by successful searches are disjoint, and their lengths sum to at most $n$. If a search fails, it examines the remaining text and the algorythm stops.

The total length of all blocks is at most $m$. So, the total running time is:

$$
{O(n+m)}.
$$



