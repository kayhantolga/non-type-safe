using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using non_type_safe;

internal class Program
{
    private static void Main(string[] args)
    {
        var config = new ManualConfig().AddDiagnoser(MemoryDiagnoser.Default)
            .AddJob(Job.Default
                .WithIterationCount(10)
                .WithWarmupCount(5))
            .AddLogger(ConsoleLogger.Default)
            .AddColumnProvider(DefaultColumnProviders.Instance)
            .AddExporter(MarkdownExporter.Default);

        var summary = BenchmarkRunner.Run<ComplexTypeBenchmark>(config);
    }
}

public class ComplexTypeBenchmark
{
    private readonly ComplexTypeSampleClass _complexTypeWithInt;
    private readonly ComplexTypeSampleClass _complexTypeWithListInt;
    private readonly ComplexTypeSampleClass _complexTypeWithListListInt;
    private readonly ComplexTypeSampleClass _complexTypeWithListString;
    private readonly ComplexTypeSampleClass _complexTypeWithObject;
    private readonly ComplexTypeSampleClass _complexTypeWithString;
    private readonly SimpleIntTypeSampleClass _simpleIntTypeSample;
    private readonly SimpleListStringTypeSampleClass _simpleListStringTypeSample;
    private readonly SimpleObjectSampleClass _simpleObjectSample;
    private readonly SimpleStringTypeSampleClass _simpleStringTypeSample;

    private readonly string _complexTypeWithIntJson;
    private readonly string _complexTypeWithListIntJson;
    private readonly string _complexTypeWithListListIntJson;
    private readonly string _complexTypeWithListStringJson;
    private readonly string _complexTypeWithObjectJson;
    private readonly string _complexTypeWithStringJson;
    private readonly string _simpleIntTypeSampleJson;
    private readonly string _simpleListStringTypeSampleJson;
    private readonly string _simpleObjectSampleJson;
    private readonly string _simpleStringTypeSampleJson;

    public ComplexTypeBenchmark()
    {
        _complexTypeWithString = new()
        {
            Id = "1",
            OtherParameter = new()
            {
                OtherParameter1 = "Hello, how are you?"
            }
        };

        _complexTypeWithListString = new()
        {
            Id = "2",
            OtherParameter = new()
            {
                OtherParameter2 = new List<string> { "One", "Two", "Three" }
            }
        };

        //_complexTypeWithListInt = new()
        //{
        //    Id = "3",
        //    OtherParameter = new()
        //    {
        //        OtherParameter3 = new List<int> { 1, 2, 3 }
        //    }
        //};

        //_complexTypeWithListListInt = new()
        //{
        //    Id = "4",
        //    OtherParameter = new()
        //    {
        //        OtherParameter4 = new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3, 4 } }
        //    }
        //};

        _complexTypeWithInt = new()
        {
            Id = "5",
            OtherParameter = new()
            {
                OtherParameter5 = 42
            }
        };

        _complexTypeWithObject = new()
        {
            Id = "6",
            OtherParameter = new()
            {
                OtherParameter6 = new()
                {
                    Parameter1 = "Nested parameter",
                    Parameter2 = 12345
                }
            }
        };

        _simpleStringTypeSample = new()
        {
            Id = "7",
            OtherParameter = "Simple string parameter"
        };

        _simpleIntTypeSample = new()
        {
            Id = "8",
            OtherParameter = 123
        };

        _simpleListStringTypeSample = new()
        {
            Id = "9",
            OtherParameter = new List<string> { "One", "Two", "Three" }
        };

        _simpleObjectSample = new()
        {
            Id = "10",
            OtherParameter = new()
            {
                Parameter1 = "Nested parameter",
                Parameter2 = 12345
            }
        };

        _complexTypeWithStringJson = JsonSerializer.Serialize(_complexTypeWithString);
        _complexTypeWithListStringJson = JsonSerializer.Serialize(_complexTypeWithListString);
        _complexTypeWithListIntJson = JsonSerializer.Serialize(_complexTypeWithListInt);
        _complexTypeWithListListIntJson = JsonSerializer.Serialize(_complexTypeWithListListInt);
        _complexTypeWithIntJson = JsonSerializer.Serialize(_complexTypeWithInt);
        _complexTypeWithObjectJson = JsonSerializer.Serialize(_complexTypeWithObject);
        _simpleStringTypeSampleJson = JsonSerializer.Serialize(_simpleStringTypeSample);
        _simpleIntTypeSampleJson = JsonSerializer.Serialize(_simpleIntTypeSample);
        _simpleListStringTypeSampleJson = JsonSerializer.Serialize(_simpleListStringTypeSample);
        _simpleObjectSampleJson = JsonSerializer.Serialize(_simpleObjectSample);
    }

    // Serialize Simple Types
    [Benchmark(Baseline = true)]
    public string SerializeSimpleStringType()
    {
        return JsonSerializer.Serialize(_simpleStringTypeSample);
    }

    // Serialize Complex Types
    [Benchmark]
    public string SerializeComplexTypeWithString()
    {
        return JsonSerializer.Serialize(_complexTypeWithString);
    }

    // Serialize Simple Types
    [Benchmark]
    public string SerializeSimpleIntType()
    {
        return JsonSerializer.Serialize(_simpleIntTypeSample);
    }

    // Serialize Complex Types
    [Benchmark]
    public string SerializeComplexTypeWithInt()
    {
        return JsonSerializer.Serialize(_complexTypeWithInt);
    }

    // Serialize Simple Types
    [Benchmark]
    public string SerializeSimpleListStringType()
    {
        return JsonSerializer.Serialize(_simpleListStringTypeSample);
    }

    // Serialize Complex Types
    [Benchmark]
    public string SerializeComplexTypeWithListString()
    {
        return JsonSerializer.Serialize(_complexTypeWithListString);
    }

    // Serialize Simple Types
    [Benchmark]
    public string SerializeSimpleObjectType()
    {
        return JsonSerializer.Serialize(_simpleObjectSample);
    }

    // Serialize Complex Types
    [Benchmark]
    public string SerializeComplexTypeWithObject()
    {
        return JsonSerializer.Serialize(_complexTypeWithObject);
    }

    [Benchmark]
    public string SerializeComplexTypeWithListInt()
    {
        return JsonSerializer.Serialize(_complexTypeWithListInt);
    }

    [Benchmark]
    public string SerializeComplexTypeWithListListInt()
    {
        return JsonSerializer.Serialize(_complexTypeWithListListInt);
    }

    // Deserialize Simple Types
    [Benchmark]
    public SimpleStringTypeSampleClass DeserializeSimpleStringType()
    {
        return JsonSerializer.Deserialize<SimpleStringTypeSampleClass>(_simpleStringTypeSampleJson);
    }

    // Deserialize Complex Types
    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithString()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithStringJson);
    }

    // Deserialize Simple Types
    [Benchmark]
    public SimpleIntTypeSampleClass DeserializeSimpleIntType()
    {
        return JsonSerializer.Deserialize<SimpleIntTypeSampleClass>(_simpleIntTypeSampleJson);
    }

    // Deserialize Complex Types
    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithInt()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithIntJson);
    }

    // Deserialize Simple Types
    [Benchmark]
    public SimpleListStringTypeSampleClass DeserializeSimpleListStringType()
    {
        return JsonSerializer.Deserialize<SimpleListStringTypeSampleClass>(_simpleListStringTypeSampleJson);
    }

    // Deserialize Complex Types
    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithListString()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithListStringJson);
    }

    // Deserialize Simple Types
    [Benchmark]
    public SimpleObjectSampleClass DeserializeSimpleObjectType()
    {
        return JsonSerializer.Deserialize<SimpleObjectSampleClass>(_simpleObjectSampleJson);
    }

    // Deserialize Complex Types
    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithObject()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithObjectJson);
    }

    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithListInt()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithListIntJson);
    }

    [Benchmark]
    public ComplexTypeSampleClass DeserializeComplexTypeWithListListInt()
    {
        return JsonSerializer.Deserialize<ComplexTypeSampleClass>(_complexTypeWithListListIntJson);
    }
}
