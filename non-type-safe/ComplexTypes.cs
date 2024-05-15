using System.Text.Json.Serialization;

namespace non_type_safe;

public class ComplexTypeSampleClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("otherParameter")]
    public OtherParameterComplexType? OtherParameter { get; set; }
}
public class SimpleStringTypeSampleClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("otherParameter")]
    public string? OtherParameter { get; set; }
}

public class SimpleIntTypeSampleClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("otherParameter")]
    public int? OtherParameter { get; set; }
}

public class SimpleListStringTypeSampleClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("otherParameter")]
    public List<string>? OtherParameter { get; set; }
}

public class SimpleObjectSampleClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("otherParameter")]
    public OtherParameterInnerClass? OtherParameter { get; set; }
}

[JsonConverter(typeof(ComplexTypeConverter))]
public class OtherParameterComplexType
{

    [JsonIgnore]
    public string? OtherParameter1 { get; set; }

    [JsonIgnore]
    public List<string>? OtherParameter2 { get; set; }

    //[JsonIgnore]
    //public List<int>? OtherParameter3 { get; set; }

    //[JsonIgnore]
    //public List<List<int>>? OtherParameter4 { get; set; }

    [JsonIgnore]
    public int? OtherParameter5 { get; set; }
    
    [JsonIgnore]
    public OtherParameterInnerClass? OtherParameter6 { get; set; }
}

public class OtherParameterInnerClass
{
    public string Parameter1 { get; set; }
    public int Parameter2 { get; set; }
}
