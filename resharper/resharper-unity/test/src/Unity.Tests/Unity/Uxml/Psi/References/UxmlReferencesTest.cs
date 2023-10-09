﻿using System.Linq;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.TestFramework;
using JetBrains.Util;
using NUnit.Framework;
using JetBrains.ReSharper.Plugins.Unity.UIElements.Uxml.Psi.References;
using JetBrains.ReSharper.Psi.Xaml.Tree;
using JetBrains.TestFramework.Projects;

namespace JetBrains.ReSharper.Plugins.Tests.Unity.Uxml.Psi.References
{
    [TestUnity(UnityVersion.Unity2022_3), ReuseSolutionScope("UnityUIElementsCompletionTest")]
    public class UxmlReferencesTest : ReferenceTestBase
    {
        protected override string RelativeTestDataPath => @"UnityUIElementsCompletionTest";
        
        protected override string SolutionFileName => SolutionItemsBasePath.Combine("Solutions/UIElementsDemo/UIElementsDemo.sln").FullPath;
        
        private VirtualFileSystemPath[] Files =>
            VirtualTestDataPath.Combine("Solutions/UIElementsDemo/")
                .GetChildFiles("*", PathSearchFlags.RecurseIntoSubdirectories).ToArray();

        protected override bool AcceptReference(IReference reference) =>
            reference is IUxmlNamespaceReference;

        [Test] public void MainMenuTemplate()
        {
            var mainFile = Files.Single(a => a.Name == "MainMenuTemplate.uxml");
            DoTestSolution(ArrayUtil.Add(mainFile.FullPath, Files.Except(mainFile).Select(a=>a.FullPath).ToArray())); 
        }
    }
    
    [TestUnity(UnityVersion.Unity2022_3), ReuseSolutionScope("UnityUIElementsCompletionTest")]
    public class UxmlReferencesTest2 : ReferenceTestBase
    {
        protected override string RelativeTestDataPath => @"UnityUIElementsCompletionTest";
        
        protected override string SolutionFileName => SolutionItemsBasePath.Combine("Solutions/UIElementsDemo/UIElementsDemo.sln").FullPath;

        private VirtualFileSystemPath[] Files =>
            VirtualTestDataPath.Combine("Solutions/UIElementsDemo/")
                .GetChildFiles("*", PathSearchFlags.RecurseIntoSubdirectories).ToArray();

        protected override bool AcceptReference(IReference reference) =>
            reference is ITypeOrNamespaceReference or IXamlNamespaceAliasReference;

        [Test] public void MainMenuTemplate2()
        {
            var mainFile = Files.Single(a => a.Name == "MainMenuTemplate2.uxml");
            DoTestSolution(ArrayUtil.Add(mainFile.FullPath, Files.Except(mainFile).Select(a=>a.FullPath).ToArray())); 
        }
    }
}
