# Benchmark Analysis

## Benchmark Environment

The benchmark was run on my own machine using BenchmarkDotNet.

* **BenchmarkDotNet:** 0.15.8
* **Operating System:** Windows 11
* **CPU:** AMD Ryzen 7 4800H
* **.NET SDK:** 10.0.400
* **Runtime:** .NET 10.0.11

## Benchmark Results

| Method                     | Iterations |       Mean |     Allocated |
| -------------------------- | ---------: | ---------: | ------------: |
| StringConcatenation        |        100 |   3.929 us |      71.45 KB |
| StringBuilderConcatenation |        100 |   456.2 ns |       3.88 KB |
| StringConcatenation        |      1,000 | 289.987 us |    6867.15 KB |
| StringBuilderConcatenation |      1,000 |   3.180 us |       30.4 KB |
| StringConcatenation        |     10,000 |  40.751 ms |  683951.49 KB |
| StringBuilderConcatenation |     10,000 |  83.565 us |     279.02 KB |
| StringConcatenation        |    100,000 |   11.284 s | 68367278.7 KB |
| StringBuilderConcatenation |    100,000 | 881.325 us |    2749.87 KB |

## Analysis

### 1. Which approach was faster with 100 iterations?

`StringBuilderConcatenation` was faster.

At 100 iterations:

* String concatenation: **3.929 us**
* StringBuilder: **456.2 ns**

Since 3.929 us is approximately 3929 ns, StringBuilder was about **8.6 times faster** in this benchmark.

### 2. Which approach was faster with 100,000 iterations?

`StringBuilderConcatenation` was much faster.

At 100,000 iterations:

* String concatenation: **11.284 seconds**
* StringBuilder: **881.325 us**

This shows that StringBuilder had a very large performance advantage when the number of iterations became large.

### 3. Which approach allocated more memory?

`StringConcatenation` allocated significantly more memory.

At 100,000 iterations:

* String concatenation: **68,367,278.7 KB**
* StringBuilder: **2,749.87 KB**

Therefore, normal string concatenation created far more memory allocations than StringBuilder.

### 4. What happened to string concatenation performance as the loop size increased?

String concatenation became significantly slower as the loop size increased.

The measured results were:

* 100 iterations: **3.929 us**
* 1,000 iterations: **289.987 us**
* 10,000 iterations: **40.751 ms**
* 100,000 iterations: **11.284 seconds**

The increase becomes especially noticeable at larger loop sizes. At 100,000 iterations, normal string concatenation took more than 11 seconds, while StringBuilder took less than 1 millisecond according to the benchmark.

This shows that repeated string concatenation does not scale well when the number of operations becomes very large.

### 5. Why does repeated string concatenation create additional allocations?

Strings in C# are immutable. This means that after a string object is created, its contents cannot be changed.

For example:

```csharp
text += "Hello";
```

does not modify the existing string object directly. A new string may need to be created containing the previous contents plus the new text.

When this operation is repeated many times, many intermediate string objects can be created.

For example:

```text
"Hello"
"Hello World"
"Hello World!"
"Hello World! More"
...
```

Each new string requires memory, and the existing contents may need to be copied into the new string.

As the string becomes larger, these repeated allocations and copying operations become increasingly expensive.

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` is designed for scenarios where text is modified repeatedly.

Instead of creating a completely new string for every append, StringBuilder maintains an internal buffer that can grow when necessary.

For example:

```csharp
StringBuilder builder = new StringBuilder();

builder.Append("Hello");
builder.Append(" World");
builder.Append("!");
```

The text can be appended to the builder's buffer without creating a new immutable string for every individual append.

This reduces the number of intermediate allocations and the amount of copying required.

The benchmark results demonstrate this clearly. At 100,000 iterations:

* String concatenation: **11.284 s**
* StringBuilder: **881.325 us**

StringBuilder also allocated much less memory.

### 7. Is StringBuilder always better than normal string operations?

No. `StringBuilder` is **not always better**.

For a small number of concatenations, normal string operations can be simpler, more readable, and perfectly fast enough.

For example:

```csharp
string fullName = firstName + " " + lastName;
```

Using StringBuilder for only two or three simple concatenations would add unnecessary complexity.

StringBuilder becomes more useful when:

* Text is appended repeatedly.
* The operation occurs inside a large loop.
* The resulting string becomes large.
* Many modifications are performed.
* Reducing allocations is important.

Therefore, the best choice depends on the situation.

For a small amount of string manipulation, normal string operations are usually appropriate. For repeated and large-scale text construction, `StringBuilder` is generally a better choice.

## Conclusion

The benchmark performed on my own machine shows a clear difference between normal string concatenation and StringBuilder as the number of iterations increases.

StringBuilder was faster at both 100 and 100,000 iterations and allocated significantly less memory.

The difference became especially large at 100,000 iterations, where normal string concatenation took **11.284 seconds** and allocated approximately **68 GB**, while StringBuilder took **881.325 us** and allocated approximately **2.75 MB**.

The main reason is that C# strings are immutable, so repeated concatenation can require additional string objects and copying. StringBuilder reduces these repeated allocations by using a resizable internal buffer.

However, StringBuilder is not automatically the best choice for every situation. For simple or small string operations, normal string concatenation is often clearer and sufficient. StringBuilder is most beneficial when text is repeatedly appended, especially in large loops.
