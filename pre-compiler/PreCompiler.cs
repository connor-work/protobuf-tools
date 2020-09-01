using Google.Protobuf.Reflection;

namespace Work.Connor.Protobuf.PreCompiler
{
    /// <summary>
    /// Tool that annotates elements in protobuf FileDescriptor messages (parsed .proto files),
    /// to simply the implementation of protoc (protobuf compiler) plug-ins.
    /// </summary>
    public class PreCompiler
    {
        /// <summary>
        /// Pre-compiles a parsed protobuf file (FileDescriptor message) by annotating elements with custom options:
        /// TODO describe annotations
        /// </summary>
        /// <param name="protoFile">The FileDescriptor message, which is modified in-place</param>
        public void PreCompile(FileDescriptorProto protoFile)
        { 
        }
    }
}
