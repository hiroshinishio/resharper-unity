using System;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Plugins.Unity.AsmDef.Daemon.Errors;
using JetBrains.ReSharper.Plugins.Unity.AsmDef.Psi.Resolve;
using JetBrains.ReSharper.Plugins.Unity.JsonNew.Psi.Tree;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.Util;

namespace JetBrains.ReSharper.Plugins.Unity.AsmDef.Feature.Services.Daemon
{
    [ElementProblemAnalyzer(typeof(IJsonNewLiteralExpression),
        HighlightingTypes = new[] { typeof(PreferGuidReferenceWarning) })]
    public class AsmDefPreferGuidReferenceProblemAnalyzer : AsmDefProblemAnalyzer<IJsonNewLiteralExpression>
    {
        protected override void Analyze(IJsonNewLiteralExpression element, ElementProblemAnalyzerData data,
                                        IHighlightingConsumer consumer)
        {
            // Unity prefers GUID references when creating a new file, to guard against accidentally changing the name
            if (element.IsReferenceLiteral() && !element.GetUnquotedText().StartsWith("guid:",
                StringComparison.InvariantCultureIgnoreCase))
            {
                var reference = element.FindReference<AsmDefNameReference>();
                if (reference != null && reference.Resolve().Info.ResolveErrorType == ResolveErrorType.OK)
                    consumer.AddHighlighting(new PreferGuidReferenceWarning(element));
            }
        }
    }
}