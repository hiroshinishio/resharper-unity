#nullable enable
using System.Xml;
using JetBrains.Diagnostics;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.QuickDoc;
using JetBrains.ReSharper.Feature.Services.QuickDoc.Render;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Feature.OnlineHelp;
using JetBrains.ReSharper.Plugins.Unity.Shaders.ShaderLab.Feature.Services.OnlineHelp;
using JetBrains.ReSharper.Plugins.Unity.Shaders.ShaderLab.Psi.DeclaredElements;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Pointers;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.Unity.Shaders.ShaderLab.Feature.Services.QuickDoc
{
    public class ShaderLabCommandQuickDocPresenter : IQuickDocPresenter
    {
        private readonly IElementInstancePointer<IDeclaredElement> myCommandPointer;
        private readonly XmlDocHtmlPresenter myXmlDocHtmlPresenter;
        private readonly string myDescription;
        
        public ShaderLabCommandQuickDocPresenter(IDeclaredElement command, string description, XmlDocHtmlPresenter xmlDocHtmlPresenter)
        {
            Assertion.Assert(command.GetElementType() == ShaderLabDeclaredElementType.Command, "ShaderLabCommandQuickDocPresenter requires ShaderLab command");
            myCommandPointer = command.CreateElementInstancePointer();
            myDescription = description;
            myXmlDocHtmlPresenter = xmlDocHtmlPresenter;
        }

        public QuickDocTitleAndText GetHtml(PsiLanguageType presentationLanguage)
        {
            if (myCommandPointer.Resolve() is not {} commandInstance)
                return QuickDocTitleAndText.Empty;
            var commandElement = commandInstance.Element;
            
            var title = DeclaredElementPresenter.Format(presentationLanguage, DeclaredElementPresenter.FULL_NESTED_NAME_PRESENTER, commandElement);
            
            var details = GetXmlDoc(commandElement);
            var text = myXmlDocHtmlPresenter.Run(details, null,
                commandInstance, presentationLanguage, XmlDocHtmlUtil.NavigationStyle.None,
                XmlDocHtmlUtil.CrefManager);
            
            return new QuickDocTitleAndText(text, title);
        }

        private XmlNode GetXmlDoc(IDeclaredElement element)
        {
            var xmlDocNode = element.GetXMLDoc(true);
            if (xmlDocNode == null)
            {
                var root = new XmlDocument().CreateElement("root");
                root.SetAttribute("name", element.ShortName);
                root.CreateLeafElementWithValue("summary", myDescription);
                xmlDocNode = root;
            }
            else
            {
                // We have XML docs, add our description as an additional node
                ((XmlElement)xmlDocNode).CreateLeafElementWithValue("description", myDescription);
            }

            var solution = element.GetSolution();
            if (solution.TryGetComponent<IXmlDocLinkAppender>() is { } xmlDocLinkAppender)
            {
                var provider = solution.GetComponent<ShaderLabOnlineHelpProvider>();
                var uri = provider.GetUrl(element);
                xmlDocLinkAppender.AppendExternalDocumentationLink(uri, provider.GetPresentableName(element), xmlDocNode);    
            }
            return xmlDocNode;    
        }

        public string? GetId() => myCommandPointer.ElementPointer.FindDeclaredElement() is {} command ? $"ShaderLabKeyword:{command.ShortName}" : null;

        public IQuickDocPresenter? Resolve(string id) => null;

        public void OpenInEditor(string navigationId = "") { }

        public void ReadMore(string navigationId = "") { }
    }
}