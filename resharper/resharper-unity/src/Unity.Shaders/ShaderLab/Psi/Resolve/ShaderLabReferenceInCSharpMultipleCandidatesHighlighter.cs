#nullable enable
using System.Collections.Generic;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Plugins.Unity.Shaders.ShaderLab.Daemon.Errors;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Resolve;

namespace JetBrains.ReSharper.Plugins.Unity.Shaders.ShaderLab.Psi.Resolve
{
    [Language(typeof(CSharpLanguage))]
    public class ShaderLabReferenceInCSharpMultipleCandidatesHighlighter : IResolveProblemHighlighter
    {
        private static readonly IEnumerable<ResolveErrorType> ourErrorTypes = new[]
        {
            ShaderLabResolveErrorType.SHADERLAB_SHADER_REFERENCE_MULTIPLE_CANDIDATES_WARNING
        }; 
        
        public IEnumerable<ResolveErrorType> ErrorTypes => ourErrorTypes;
        
        public IHighlighting? Run(IReference reference)
        {
            if (reference is IShaderReference shaderReference)
                return new ShaderLabShaderReferenceMultipleCandidatesWarning(shaderReference);
            return null;
        }
    }
}