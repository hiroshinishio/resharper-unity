using System.Collections.Generic;
using JetBrains.Application.UI.Controls.BulbMenu.Anchors;
using JetBrains.Application.UI.Controls.BulbMenu.Items;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Feature.Services.Intentions;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Daemon.Errors;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Daemon.Stages.ContextSystem;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Daemon.Stages.PerformanceCriticalCodeAnalysis.ContextSystem;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Feature.Services.QuickFixes;
using JetBrains.ReSharper.Plugins.Unity.Resources;
using JetBrains.ReSharper.Plugins.Unity.UnityEditorIntegration.Api;
using JetBrains.ReSharper.Plugins.Unity.Utils;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.Util;
using JetBrains.ReSharper.Resources.Resources.Icons;
using JetBrains.TextControl;
using JetBrains.TextControl.CodeWithMe;

#nullable enable

namespace JetBrains.ReSharper.Plugins.Unity.CSharp.Daemon.Stages.Highlightings.IconsProviders
{
    [SolutionComponent]
    public class TypeDetector : UnityDeclarationHighlightingProviderBase
    {
        private readonly UnityApi myUnityApi;

        public TypeDetector(ISolution solution, IApplicationWideContextBoundSettingStore settingsStore, UnityApi unityApi, PerformanceCriticalContextProvider contextProvider)
            : base(solution, settingsStore, contextProvider)
        {
            myUnityApi = unityApi;
        }

        public override bool AddDeclarationHighlighting(IDeclaration node, IHighlightingConsumer consumer, IReadOnlyCallGraphContext context)
        {
            if (!(node is IClassLikeDeclaration element))
                return false;

            var typeElement = element.DeclaredElement;
            if (typeElement != null)
            {
                if (typeElement.DerivesFromMonoBehaviour())
                {
                    AddMonoBehaviourHighlighting(consumer, element, Strings.TypeDetector_AddDeclarationHighlighting_Script, Strings.TypeDetector_AddDeclarationHighlighting_Unity_script, context);
                }
                else if (typeElement.DerivesFrom(KnownTypes.Editor) || typeElement.DerivesFrom(KnownTypes.EditorWindow))
                {
                    AddEditorHighlighting(consumer, element, Strings.TypeDetector_AddDeclarationHighlighting_Editor, Strings.TypeDetector_AddDeclarationHighlighting_Custom_Unity_editor, context);
                }
                else if (typeElement.DerivesFromScriptableObject())
                {
                    AddMonoBehaviourHighlighting(consumer, element, Strings.TypeDetector_AddDeclarationHighlighting_Scriptable_object, Strings.TypeDetector_AddDeclarationHighlighting_Unity_scriptable_object, context);
                }
                else if (myUnityApi.IsUnityType(typeElement))
                {
                    AddUnityTypeHighlighting(consumer, element, Strings.TypeDetector_AddDeclarationHighlighting_Unity_type, Strings.TypeDetector_AddDeclarationHighlighting_Custom_Unity_type, context);
                }
                else if (UnityApi.IsDotsImplicitlyUsedType(typeElement))
                {
                    //TODO obsolete
                    AddUnityECSHighlighting(consumer, element, Strings.TypeDetector_AddDeclarationHighlighting_ECS_system, Strings.TypeDetector_AddDeclarationHighlighting_Unity_entities_system,
                        context);
                }

                return true;
            }

            return false;
        }

        protected virtual void AddMonoBehaviourHighlighting(IHighlightingConsumer consumer, IClassLikeDeclaration declaration, string text, string tooltip, IReadOnlyCallGraphContext context)
        {
            AddHighlighting(consumer, declaration, text, tooltip, context);
        }

        protected virtual void AddEditorHighlighting(IHighlightingConsumer consumer, IClassLikeDeclaration declaration, string text, string tooltip, IReadOnlyCallGraphContext context)
        {
            AddHighlighting(consumer, declaration, text, tooltip, context);
        }

        protected virtual void AddUnityTypeHighlighting(IHighlightingConsumer consumer, IClassLikeDeclaration declaration, string text, string tooltip, IReadOnlyCallGraphContext context)
        {
            AddHighlighting(consumer, declaration, text, tooltip, context);
        }

        protected virtual void AddUnityECSHighlighting(IHighlightingConsumer consumer, IClassLikeDeclaration declaration, string text, string tooltip, IReadOnlyCallGraphContext context)
        {
            AddHighlighting(consumer, declaration, text, tooltip, context);
        }


        protected override void AddHighlighting(IHighlightingConsumer consumer, ICSharpDeclaration declaration, string text, string tooltip, IReadOnlyCallGraphContext context)
        {
            consumer.AddImplicitConfigurableHighlighting(declaration);
            
            if (!IconProviderUtil.ShouldShowGutterMarkIcon(SettingsStore.BoundSettingsStore))
                return;
            
            consumer.AddHighlighting(new UnityGutterMarkInfo(GetActions(declaration), declaration, tooltip));
        }

        protected override IEnumerable<BulbMenuItem> GetActions(ICSharpDeclaration declaration)
        {
            var result = new List<BulbMenuItem>();
            var textControl = Solution.GetComponent<ITextControlManager>().LastFocusedTextControlPerClient
                .ForCurrentClient();
            if (declaration is IClassLikeDeclaration classLikeDeclaration && textControl != null)
            {
                if (myUnityApi.IsUnityType(classLikeDeclaration.DeclaredElement))
                {
                    var fix = new GenerateUnityEventFunctionsFix(classLikeDeclaration);
                    result.Add(new IntentionAction(fix, Strings.TypeDetector_GetActions_Generate_Unity_event_functions,
                            PsiFeaturesUnsortedThemedIcons.FuncZoneGenerate.Id, BulbMenuAnchors.FirstClassContextItems)
                        .ToBulbMenuItem(Solution, textControl));
                }

                if (UnityApi.IsDerivesFromIComponentData(classLikeDeclaration.DeclaredElement))
                {
                    var fix = new GenerateBakerAndAuthoringActionFix(classLikeDeclaration);
                    result.Add(new IntentionAction(fix, Strings.UnityDots_GenerateBakerAndAuthoring_Name,
                            PsiFeaturesUnsortedThemedIcons.FuncZoneGenerate.Id, BulbMenuAnchors.FirstClassContextItems)
                        .ToBulbMenuItem(Solution, textControl));
                }
            }

            return result;
        }
    }
}
