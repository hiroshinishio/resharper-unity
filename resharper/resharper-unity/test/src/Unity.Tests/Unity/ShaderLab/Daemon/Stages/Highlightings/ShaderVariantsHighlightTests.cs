using System.Collections.Generic;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Cpp.Caches;
using JetBrains.ReSharper.FeaturesTestFramework.Daemon;
using JetBrains.ReSharper.Plugins.Tests.UnityTestComponents;
using JetBrains.ReSharper.Plugins.Unity.Shaders.HlslSupport.Daemon.Highlightings;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Cpp.Language;
using NUnit.Framework;

namespace JetBrains.ReSharper.Plugins.Tests.Unity.ShaderLab.Daemon.Stages.Highlightings
{
    [RequireHlslSupport, TestUnity, HighlightOnly(typeof(ImplicitlyEnabledShaderKeywordHighlight), typeof(EnabledShaderKeywordHighlight), typeof(DisabledShaderKeywordHighlight), typeof(SuppressedShaderKeywordHighlight))]
    public class ShaderVariantsHighlightTests : HighlightingTestBase
    {
        private readonly List<string> myEnabledKeywords = new();
        
        protected override PsiLanguageType? CompilerIdsLanguage => CppLanguage.Instance;
        protected override string RelativeTestDataPath => @"ShaderLab\Daemon\Stages\Highlightings";

        public override void SetUp()
        {
            base.SetUp();
            myEnabledKeywords.Clear();
        }

        [Test]
        public void TestImplicitHighlight() => DoTestSolution("ShaderVariants.hlsl", "FooBar.shader");
        
        [Test]
        public void TestSingleKeywordInShader() => DoTestSolution("SingleKeywordInShader.shader");
        
        [Test]
        public void TestPragmaHighlight() => DoTestSolution("FooBar.shader");
        
        [Test]
        public void TestEnabledKeywordsInShader()
        {
            myEnabledKeywords.Add("FOO");
            myEnabledKeywords.Add("B");
            myEnabledKeywords.Add("C");
            DoTestSolution("EnabledKeywordsInShader.shader");
        }

        protected override void DoTest(Lifetime lifetime, IProject project)
        {
            var enabledKeywords = project.GetComponent<TestEnabledShaderKeywordsProvider>().EnabledKeywords;
            enabledKeywords.Clear();
            enabledKeywords.UnionWith(myEnabledKeywords);
            project.GetComponent<CppGlobalCacheImpl>().ResetCache();
            base.DoTest(lifetime, project);
        }
    }
}