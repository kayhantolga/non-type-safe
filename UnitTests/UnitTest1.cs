using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;
using System.Collections.Generic;

namespace non_type_safe.Tests
{
    public class SerializationTests
    {
        // 1. ComplexTypeSampleClass
        [Fact]
        public void Serialize_ComplexTypeSampleClass_WithOtherParameter1_ShouldWork()
        {
            var sample = new ComplexTypeSampleClass
            {
                Id = "123",
                OtherParameter = new OtherParameterComplexType { OtherParameter1 = "test" }
            };

            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
            string json = JsonSerializer.Serialize(sample, options);

            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":\"test\"", json);
        }

        [Fact]
        public void Serialize_ComplexTypeSampleClass_WithOtherParameter5_ShouldWork()
        {
            var sample = new ComplexTypeSampleClass
            {
                Id = "123",
                OtherParameter = new OtherParameterComplexType { OtherParameter5 = 42 }
            };

            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
            string json = JsonSerializer.Serialize(sample, options);

            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":42", json);
        }

        [Fact]
        public void Serialize_ComplexTypeSampleClass_WithOtherParameter2_ShouldWork()
        {
            var sample = new ComplexTypeSampleClass
            {
                Id = "123",
                OtherParameter = new OtherParameterComplexType { OtherParameter2 = new List<string> { "one", "two" } }
            };

            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
            string json = JsonSerializer.Serialize(sample, options);

            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":[\"one\",\"two\"]", json);
        }

        //[Fact]
        //public void Serialize_ComplexTypeSampleClass_WithOtherParameter3_ShouldWork()
        //{
        //    var sample = new ComplexTypeSampleClass
        //    {
        //        Id = "123",
        //        OtherParameter = new OtherParameterComplexType { OtherParameter3 = new List<int> { 1, 2 } }
        //    };

        //    var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
        //    string json = JsonSerializer.Serialize(sample, options);

        //    Assert.Contains("\"id\":\"123\"", json);
        //    Assert.Contains("\"otherParameter\":[1,2]", json);
        //}

        //[Fact]
        //public void Serialize_ComplexTypeSampleClass_WithOtherParameter4_ShouldWork()
        //{
        //    var sample = new ComplexTypeSampleClass
        //    {
        //        Id = "123",
        //        OtherParameter = new OtherParameterComplexType { OtherParameter4 = new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3, 4 } } }
        //    };

        //    var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
        //    string json = JsonSerializer.Serialize(sample, options);

        //    Assert.Contains("\"id\":\"123\"", json);
        //    Assert.Contains("\"otherParameter\":[[1,2],[3,4]]", json);
        //}

        [Fact]
        public void Serialize_ComplexTypeSampleClass_WithOtherParameter6_ShouldWork()
        {
            var sample = new ComplexTypeSampleClass
            {
                Id = "123",
                OtherParameter = new OtherParameterComplexType
                {
                    OtherParameter6 = new OtherParameterInnerClass { Parameter1 = "inner", Parameter2 = 99 }
                }
            };

            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
            string json = JsonSerializer.Serialize(sample, options);

            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":{\"Parameter1\":\"inner\",\"Parameter2\":99}", json);
        }

        [Fact]
        public void Serialize_ComplexTypeSampleClass_WithOtherParameter_Null_ShouldWork()
        {
            var sample = new ComplexTypeSampleClass
            {
                Id = "123",
                OtherParameter = null
            };

            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };
            string json = JsonSerializer.Serialize(sample, options);

            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":null", json);
        }

        [Fact]
        public void Deserialize_ComplexTypeSampleClass_WithOtherParameter1_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":\"test\"}";
            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

            var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Equal("test", result.OtherParameter.OtherParameter1);
        }

        [Fact]
        public void Deserialize_ComplexTypeSampleClass_WithOtherParameter5_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":42}";
            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

            var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Equal(42, result.OtherParameter.OtherParameter5);
        }

        [Fact]
        public void Deserialize_ComplexTypeSampleClass_WithOtherParameter2_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":[\"one\",\"two\"]}";
            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

            var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Contains("one", result.OtherParameter.OtherParameter2);
            Assert.Contains("two", result.OtherParameter.OtherParameter2);
        }

        //[Fact]
        //public void Deserialize_ComplexTypeSampleClass_WithOtherParameter3_ShouldWork()
        //{
        //    string json = "{\"id\":\"123\",\"otherParameter\":[1,2]}";
        //    var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

        //    var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

        //    Assert.NotNull(result);
        //    Assert.Equal("123", result.Id);
        //    Assert.NotNull(result.OtherParameter);
        //    Assert.Contains(1, result.OtherParameter.OtherParameter3);
        //    Assert.Contains(2, result.OtherParameter.OtherParameter3);
        //}

        //[Fact]
        //public void Deserialize_ComplexTypeSampleClass_WithOtherParameter4_ShouldWork()
        //{
        //    string json = "{\"id\":\"123\",\"otherParameter\":[[1,2],[3,4]]}";
        //    var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

        //    var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

        //    Assert.NotNull(result);
        //    Assert.Equal("123", result.Id);
        //    Assert.NotNull(result.OtherParameter);
        //    Assert.Equal(new List<int> { 1, 2 }, result.OtherParameter.OtherParameter4[0]);
        //    Assert.Equal(new List<int> { 3, 4 }, result.OtherParameter.OtherParameter4[1]);
        //}

        [Fact]
        public void Deserialize_ComplexTypeSampleClass_WithOtherParameter6_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":{\"Parameter1\":\"inner\",\"Parameter2\":99}}";
            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

            var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Equal("inner", result.OtherParameter.OtherParameter6.Parameter1);
            Assert.Equal(99, result.OtherParameter.OtherParameter6.Parameter2);
        }

        [Fact]
        public void Deserialize_ComplexTypeSampleClass_WithOtherParameter_Null_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":null}";
            var options = new JsonSerializerOptions { Converters = { new ComplexTypeConverter() } };

            var result = JsonSerializer.Deserialize<ComplexTypeSampleClass>(json, options);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Null(result.OtherParameter);
        }

        // 2. SimpleStringTypeSampleClass
        [Fact]
        public void Serialize_SimpleStringTypeSampleClass_ShouldWork()
        {
            var sample = new SimpleStringTypeSampleClass
            {
                Id = "123",
                OtherParameter = "test"
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":\"test\"", json);
        }

        [Fact]
        public void Serialize_SimpleStringTypeSampleClass_Null_ShouldWork()
        {
            var sample = new SimpleStringTypeSampleClass
            {
                Id = "123",
                OtherParameter = null
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":null", json);
        }

        [Fact]
        public void Deserialize_SimpleStringTypeSampleClass_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":\"test\"}";

            var result = JsonSerializer.Deserialize<SimpleStringTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Equal("test", result.OtherParameter);
        }

        [Fact]
        public void Deserialize_SimpleStringTypeSampleClass_Null_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":null}";

            var result = JsonSerializer.Deserialize<SimpleStringTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Null(result.OtherParameter);
        }

        // 3. SimpleIntTypeSampleClass
        [Fact]
        public void Serialize_SimpleIntTypeSampleClass_ShouldWork()
        {
            var sample = new SimpleIntTypeSampleClass
            {
                Id = "123",
                OtherParameter = 42
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":42", json);
        }

        [Fact]
        public void Serialize_SimpleIntTypeSampleClass_Null_ShouldWork()
        {
            var sample = new SimpleIntTypeSampleClass
            {
                Id = "123",
                OtherParameter = null
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":null", json);
        }

        [Fact]
        public void Deserialize_SimpleIntTypeSampleClass_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":42}";

            var result = JsonSerializer.Deserialize<SimpleIntTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Equal(42, result.OtherParameter);
        }

        [Fact]
        public void Deserialize_SimpleIntTypeSampleClass_Null_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":null}";

            var result = JsonSerializer.Deserialize<SimpleIntTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Null(result.OtherParameter);
        }

        // 4. SimpleListStringTypeSampleClass
        [Fact]
        public void Serialize_SimpleListStringTypeSampleClass_EmptyList_ShouldWork()
        {
            var sample = new SimpleListStringTypeSampleClass
            {
                Id = "123",
                OtherParameter = new List<string>()
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":[]", json);
        }

        [Fact]
        public void Serialize_SimpleListStringTypeSampleClass_ShouldWork()
        {
            var sample = new SimpleListStringTypeSampleClass
            {
                Id = "123",
                OtherParameter = new List<string> { "one", "two" }
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":[\"one\",\"two\"]", json);
        }

        [Fact]
        public void Serialize_SimpleListStringTypeSampleClass_Null_ShouldWork()
        {
            var sample = new SimpleListStringTypeSampleClass
            {
                Id = "123",
                OtherParameter = null
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":null", json);
        }

        [Fact]
        public void Deserialize_SimpleListStringTypeSampleClass_EmptyList_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":[]}";

            var result = JsonSerializer.Deserialize<SimpleListStringTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Empty(result.OtherParameter);
        }

        [Fact]
        public void Deserialize_SimpleListStringTypeSampleClass_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":[\"one\",\"two\"]}";

            var result = JsonSerializer.Deserialize<SimpleListStringTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Contains("one", result.OtherParameter);
            Assert.Contains("two", result.OtherParameter);
        }

        [Fact]
        public void Deserialize_SimpleListStringTypeSampleClass_Null_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":null}";

            var result = JsonSerializer.Deserialize<SimpleListStringTypeSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Null(result.OtherParameter);
        }

        // 5. SimpleObjectSampleClass
        [Fact]
        public void Serialize_SimpleObjectSampleClass_ShouldWork()
        {
            var sample = new SimpleObjectSampleClass
            {
                Id = "123",
                OtherParameter = new OtherParameterInnerClass { Parameter1 = "innerTest", Parameter2 = 99 }
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":{\"Parameter1\":\"innerTest\",\"Parameter2\":99}", json);
        }

        [Fact]
        public void Serialize_SimpleObjectSampleClass_Null_ShouldWork()
        {
            var sample = new SimpleObjectSampleClass
            {
                Id = "123",
                OtherParameter = null
            };

            string json = JsonSerializer.Serialize(sample);
            Assert.Contains("\"id\":\"123\"", json);
            Assert.Contains("\"otherParameter\":null", json);
        }

        [Fact]
        public void Deserialize_SimpleObjectSampleClass_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":{\"Parameter1\":\"innerTest\",\"Parameter2\":99}}";

            var result = JsonSerializer.Deserialize<SimpleObjectSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.NotNull(result.OtherParameter);
            Assert.Equal("innerTest", result.OtherParameter.Parameter1);
            Assert.Equal(99, result.OtherParameter.Parameter2);
        }

        [Fact]
        public void Deserialize_SimpleObjectSampleClass_Null_ShouldWork()
        {
            string json = "{\"id\":\"123\",\"otherParameter\":null}";

            var result = JsonSerializer.Deserialize<SimpleObjectSampleClass>(json);

            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Null(result.OtherParameter);
        }
    }
}
