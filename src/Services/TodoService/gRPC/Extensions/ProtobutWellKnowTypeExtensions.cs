using Google.Protobuf.WellKnownTypes;

namespace Services.Todo.gRPC.Extensions;

public static class ProtobutWellKnowTypeExtensions
{
    public static Timestamp ConvertToTimestamp(this DateTime toConvertDate)
    {
        return toConvertDate.ToUniversalTime().ToTimestamp();
    }
}
