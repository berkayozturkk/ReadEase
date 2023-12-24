using System.Reflection;

namespace ReadEase.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly
        = typeof(Assembly).Assembly;
}
