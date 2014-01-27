﻿#region Copyright © 2013 Michael Reukauff
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProtobufWordListProvider.cs" company="Michael Reukauff">
//   Copyright © 2013 Michael Reukauff
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace MichaelReukauff.Protobuf
{
  using System.Collections.Generic;
  using System.Linq;

  internal class ProtobufWordListProvider
  {
    private readonly List<ProtobufToken> list = new List<ProtobufToken>
    {
      // first level keywords (+ service below)
      new ProtobufToken("package", "Use package to prevent name clashes between protocol message types."),

      new ProtobufToken("import", "Importing another protobuf"),
      new ProtobufToken("message", "A protobuf message"),
      new ProtobufToken("enum", "An enumeration"),
      new ProtobufToken("extend", "Extend a message"),

      // field rules
      new ProtobufToken("required", "A well-formed message must have exactly one of this field."),
      new ProtobufToken("optional", "A well-formed message can have zero or one of this field (but not more than one)."),
      new ProtobufToken("repeated", "This field can be repeated any number of times (including zero) in a well-formed message. The order of the repeated values will be preserved."),

      // data types
      new ProtobufToken("double", "A double field"),
      new ProtobufToken("float", "A float field"),
      new ProtobufToken("uint32", "Uses variable-length encoding. 32 bit."),
      new ProtobufToken("uint64", "Uses variable-length encoding. 64 bit."),
      new ProtobufToken("sint32", "Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int32s."),
      new ProtobufToken("sint64", "Uses variable-length encoding. Signed int value. These more efficiently encode negative numbers than regular int64s."),
      new ProtobufToken("int32", "Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint32 instead."),
      new ProtobufToken("int64", "Uses variable-length encoding. Inefficient for encoding negative numbers – if your field is likely to have negative values, use sint64 instead."),
      new ProtobufToken("sfixed32", "Always four bytes."),
      new ProtobufToken("sfixed64", "Always eight bytes."),
      new ProtobufToken("fixed32", "Always four bytes. More efficient than uint32 if values are often greater than 2^28."),
      new ProtobufToken("fixed64", "Always eight bytes. More efficient than uint64 if values are often greater than 2^56."),
      new ProtobufToken("bool", "A boolean field."),
      new ProtobufToken("string", "A string must always contain UTF-8 encoded or 7-bit ASCII text."),
      new ProtobufToken("bytes", "May contain any arbitrary sequence of bytes."),

      // service keywords
      new ProtobufToken("service", "Defines a RPC service."),
      new ProtobufToken("rpc", "Defines a RPC service."),
      new ProtobufToken("returns", "Defines the return message."),

      // keywords
      new ProtobufToken("default", "Default value"),
      new ProtobufToken("public", "This import is public"),
      new ProtobufToken("extensions", "This extend a message"),

      // Literals
      new ProtobufToken("true", "A boolean"),
      new ProtobufToken("false", "A boolean"),

      // options
      new ProtobufToken("option", "An option"),
      new ProtobufToken("allow_alias", "Allow alias in enums"),

      new ProtobufToken("java_package", "The package you want to use for your generated Java classes"),
      new ProtobufToken("java_outer_classname", "The class name for the outermost Java class."),
      new ProtobufToken("optimize_for", "This affects the code generators."),
      new ProtobufToken("SPEED", "The protocol buffer compiler will generate code for serializing, parsing, and performing other common operations on your message types. This code is extremely highly optimized"),
      new ProtobufToken("CODE_SIZE", "The protocol buffer compiler will generate minimal classes and will rely on shared, reflection-based code to implement serialialization, parsing, and various other operations."),
      new ProtobufToken("LITE_RUNTIME", " The protocol buffer compiler will generate classes that depend only on the \"lite\" runtime library."),
      new ProtobufToken("cc_generic_services", "Whether or not the protocol buffer compiler should generate abstract service code."),
      new ProtobufToken("java_generic_services", "Whether or not the protocol buffer compiler should generate abstract service code."),
      new ProtobufToken("py_generic_services", "Whether or not the protocol buffer compiler should generate abstract service code."),
      new ProtobufToken("message_set_wire_format", "If set to true, the message uses a different binary format intended to be compatible with an old format used inside Google called MessageSet. Users outside Google will probably never need to use this option."),
      new ProtobufToken("packed", "If set to true on a repeated field of a basic integer type, a more compact encoding will be used."),
      new ProtobufToken("deprecated", " If set to true, indicates that the field is deprecated and should not be used by new code"),
    };

    #region internal methods
    internal IDictionary<string, string> GetWordsWithDescription()
    {
      return list.ToDictionary(x => x.Name, x => x.Description);
    }
    #endregion internal methods
  }

  #region ProtobufToken
  /// <summary>
  /// The Protobuf Token with description
  /// </summary>
  internal class ProtobufToken
  {
    internal string Name { get; set; }

    internal string Description { get; set; }

    internal ProtobufToken(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
  #endregion ProtobufToken
}
