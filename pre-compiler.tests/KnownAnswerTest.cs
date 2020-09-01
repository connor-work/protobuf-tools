using Google.Protobuf.Reflection;
using System.Collections.Generic;
using Xunit;

namespace Work.Connor.Protobuf.PreCompiler.Tests
{
    public class KnownAnswerTest
    {
        [Theory]
        [MemberData(nameof(KnownPrecompiledFiles))]
        public void PerformsExpectedPrecompilation(FileDescriptorProto input, FileDescriptorProto expectedOutput)
        {

        }

        public static IEnumerable<object[]> KnownPrecompiledFiles()
        {
            yield return new object[] {null, null};
        }
    }
}
