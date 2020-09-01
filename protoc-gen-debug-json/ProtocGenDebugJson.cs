using Google.Protobuf;
using Google.Protobuf.Compiler;
using System;
using System.IO;

namespace Work.Connor.Protobuf.ProtocGenDebugJson
{
    /// <summary>
    /// Plug-in for the protobuf compiler <c>protoc</c> that simply dumps its received
    /// <see cref="CodeGeneratorRequest"/> as a JSON-encoded file.
    /// </summary>
    public class ProtocGenDebugJson
    {
        /// <summary>
        /// File name extension (without leading dot) for JSON-encoded protobuf messages in test data
        /// </summary>
        public static readonly string protobufJsonFileExtension = "pb.json";

        /// <summary>
        /// Name of the generated file that encodes the received request
        /// </summary>
        public static readonly string requestFileName = "protoc-request." + protobufJsonFileExtension;

        /// <summary>
        /// Formatter settings for encoding the received <see cref="CodeGeneratorRequest"/> protobuf message as JSON.
        /// </summary>
        public static readonly JsonFormatter.Settings requestJsonFormatSettings = JsonFormatter.Settings.Default.WithFormatDefaultValues(false).WithFormatEnumsAsIntegers(false);

        public static void Main(string[] args)
        {
            // protoc communicates with the plug-in through stdin and stdout
            using Stream input = Console.OpenStandardInput();
            using Stream output = Console.OpenStandardOutput();
            ProtocGenDebugJson plugIn = new ProtocGenDebugJson();
            CodeGeneratorRequest request = CodeGeneratorRequest.Parser.ParseFrom(input);
            CodeGeneratorResponse response = plugIn.HandleRequest(request);
            response.WriteTo(output);
        }

        /// <summary>
        /// Handles a request from code generation that <c>protoc</c> passed to the plug-in,
        /// by generating a response message.
        /// </summary>
        /// <param name="request">The request from <c>protoc</c></param>
        /// <returns>The response to <c>protoc</c></returns>
        public CodeGeneratorResponse HandleRequest(CodeGeneratorRequest request)
        {
            JsonFormatter jsonFormatter = new JsonFormatter(requestJsonFormatSettings);
            CodeGeneratorResponse response = new CodeGeneratorResponse();
            response.File.Add(new CodeGeneratorResponse.Types.File()
            {
                Name = requestFileName,
                Content = jsonFormatter.Format(request)
            });
            return response;
        }
    }
}
