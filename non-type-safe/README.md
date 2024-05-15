
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3527/23H2/2023Update/SunValley3)
11th Gen Intel Core i9-11980HK 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  Job-SSQRSI : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

IterationCount=10  WarmupCount=5  

 Method                                | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
-------------------------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
 SerializeSimpleStringType             | 196.66 ns | 7.932 ns | 5.247 ns |  1.00 |    0.00 | 0.0100 |     128 B |        1.00 |
 SerializeComplexTypeWithString        | 367.96 ns | 4.759 ns | 3.148 ns |  1.87 |    0.06 | 0.0234 |     296 B |        2.31 |
 SerializeSimpleIntType                | 170.28 ns | 4.103 ns | 2.714 ns |  0.87 |    0.03 | 0.0069 |      88 B |        0.69 |
 SerializeComplexTypeWithInt           | 489.84 ns | 6.610 ns | 4.372 ns |  2.49 |    0.06 | 0.0248 |     312 B |        2.44 |
 SerializeSimpleListStringType         | 306.52 ns | 5.586 ns | 3.695 ns |  1.56 |    0.05 | 0.0343 |     432 B |        3.38 |
 SerializeComplexTypeWithListString    | 430.24 ns | 9.566 ns | 6.328 ns |  2.19 |    0.07 | 0.0234 |     296 B |        2.31 |
 SerializeSimpleObjectType             | 301.81 ns | 3.993 ns | 2.641 ns |  1.54 |    0.04 | 0.0391 |     496 B |        3.88 |
 SerializeComplexTypeWithObject        | 478.11 ns | 7.115 ns | 4.706 ns |  2.43 |    0.07 | 0.0286 |     360 B |        2.81 |
 SerializeComplexTypeWithListInt       |  76.36 ns | 1.683 ns | 1.001 ns |  0.39 |    0.01 | 0.0025 |      32 B |        0.25 |
 SerializeComplexTypeWithListListInt   |  73.47 ns | 1.591 ns | 1.052 ns |  0.37 |    0.01 | 0.0025 |      32 B |        0.25 |
 DeserializeSimpleStringType           | 245.41 ns | 4.019 ns | 2.659 ns |  1.25 |    0.03 | 0.0100 |     128 B |        1.00 |
 DeserializeComplexTypeWithString      | 256.41 ns | 2.221 ns | 1.469 ns |  1.30 |    0.04 | 0.0134 |     168 B |        1.31 |
 DeserializeSimpleIntType              | 218.74 ns | 3.775 ns | 2.247 ns |  1.11 |    0.03 | 0.0043 |      56 B |        0.44 |
 DeserializeComplexTypeWithInt         | 236.48 ns | 2.697 ns | 1.784 ns |  1.20 |    0.03 | 0.0081 |     104 B |        0.81 |
 DeserializeSimpleListStringType       | 455.82 ns | 7.463 ns | 4.936 ns |  2.32 |    0.08 | 0.0539 |     680 B |        5.31 |
 DeserializeComplexTypeWithListString  | 602.67 ns | 6.596 ns | 4.363 ns |  3.07 |    0.10 | 0.0229 |     288 B |        2.25 |
 DeserializeSimpleObjectType           | 462.85 ns | 5.491 ns | 3.632 ns |  2.35 |    0.06 | 0.0467 |     592 B |        4.62 |
 DeserializeComplexTypeWithObject      | 617.62 ns | 5.274 ns | 3.138 ns |  3.13 |    0.09 | 0.0153 |     192 B |        1.50 |
 DeserializeComplexTypeWithListInt     |  67.90 ns | 1.013 ns | 0.670 ns |  0.35 |    0.01 |      - |         - |        0.00 |
 DeserializeComplexTypeWithListListInt |  69.53 ns | 0.851 ns | 0.506 ns |  0.35 |    0.01 |      - |         - |        0.00 |
