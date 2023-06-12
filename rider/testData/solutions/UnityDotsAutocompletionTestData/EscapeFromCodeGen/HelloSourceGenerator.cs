﻿using Microsoft.CodeAnalysis;

namespace SourceGenerator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var typeName = "UserAspect";

            string source = $@"// <auto-generated/>
using Unity.Entities;
using Unity.Mathematics;

public readonly partial struct {typeName} : IAspect
{{
        private readonly ComponentLookup<UserComponentData> UserAspect___userComponentData;
    
        public void PublicVoidMethod()
        {{
        }}

        public static void PublicStaticMethod()
        {{
        }}

        public static void __codegen_PublicCodeGenMethod()
        {{
        }}
}}


public static class StaticCodeGenClass
{{
        public static void StaticMethod(){{}}
}}
";
            // Add the source code to the compilation
            context.AddSource($"{typeName}.g.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}