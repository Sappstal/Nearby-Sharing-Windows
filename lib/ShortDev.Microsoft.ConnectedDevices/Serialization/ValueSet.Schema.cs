﻿// <auto-generated />

namespace ShortDev.Microsoft.ConnectedDevices.Serialization;

public enum PropertyType
{
    PropertyType_Empty = unchecked((int)0),
    PropertyType_Int32 = unchecked((int)4),
    PropertyType_UInt32 = unchecked((int)5),
    PropertyType_UInt64 = unchecked((int)7),
    PropertyType_String = unchecked((int)39),
    PropertyType_GuidArray = unchecked((int)15),
    PropertyType_UInt8Array = unchecked((int)20),
    PropertyType_UInt32Array = unchecked((int)24),
    PropertyType_UInt64Array = unchecked((int)26),
    PropertyType_StringArray = unchecked((int)40),
}

[global::Bond.Schema]
public partial class UUID
{
    [global::Bond.Id(0)]
    public uint Data1 { get; set; }

    [global::Bond.Id(1)]
    public ushort Data2 { get; set; }

    [global::Bond.Id(2)]
    public ushort Data3 { get; set; }

    [global::Bond.Id(3)]
    public ulong Data4 { get; set; }

    public UUID()
        : this("ShortDev.Microsoft.ConnectedDevices.Serialization.UUID", "UUID")
    { }

    protected UUID(string fullName, string name)
    {

    }
}

[global::Bond.Schema]
public partial class PropertyValue
{
    [global::Bond.Id(0), global::Bond.Required]
    public PropertyType Type { get; set; }

    [global::Bond.Id(103)]
    public int Int32Value { get; set; }

    [global::Bond.Id(104)]
    public uint UInt32Value { get; set; }

    [global::Bond.Id(106)]
    public ulong UInt64Value { get; set; }

    [global::Bond.Id(114)]
    public List<UUID> GuidArrayValue { get; set; }

    [global::Bond.Id(119)]
    public string StringValue { get; set; }

    [global::Bond.Id(200)]
    public List<byte> UInt8ArrayValue { get; set; }

    [global::Bond.Id(204)]
    public List<uint> UInt32ArrayValue { get; set; }

    [global::Bond.Id(206)]
    public List<ulong> UInt64ArrayValue { get; set; }

    [global::Bond.Id(219)]
    public List<string> StringArrayValue { get; set; }

    public PropertyValue()
        : this("ShortDev.Microsoft.ConnectedDevices.Serialization.PropertyValue", "PropertyValue")
    { }

    protected PropertyValue(string fullName, string name)
    {
        Type = PropertyType.PropertyType_Empty;
        GuidArrayValue = new List<UUID>();
        StringValue = "";
        UInt8ArrayValue = new List<byte>();
        UInt32ArrayValue = new List<uint>();
        UInt64ArrayValue = new List<ulong>();
        StringArrayValue = new List<string>();
    }
}

[global::Bond.Schema]
public partial class ValueSet
{
    [global::Bond.Id(1), global::Bond.Type(typeof(Dictionary<global::Bond.Tag.wstring, PropertyValue>))]
    public Dictionary<string, PropertyValue> Entries { get; set; }

    public ValueSet()
        : this("ShortDev.Microsoft.ConnectedDevices.Serialization.ValueSet", "ValueSet")
    { }

    protected ValueSet(string fullName, string name)
    {
        Entries = new Dictionary<string, PropertyValue>();
    }
}
