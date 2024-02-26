using JetBrains.Application.DataContext;
using JetBrains.ReSharper.Feature.Services.Generate.Actions;
using JetBrains.ReSharper.Feature.Services.Generate.Workflows;
using JetBrains.ReSharper.Plugins.Unity.CSharp.Daemon.Stages.Dots;
using JetBrains.ReSharper.Plugins.Unity.Resources;
using JetBrains.ReSharper.Plugins.Unity.Resources.Icons;

namespace JetBrains.ReSharper.Plugins.Unity.CSharp.Feature.Services.Generate.Dots;

public class GenerateComponentReferencesWorkflow() : GenerateCodeWorkflowBase(
    GeneratorUnityKinds.UnityGenerateComponentReferences, LogoIcons.Unity.Id,
    Strings.UnityDots_GenerateComponentReference_Unity_Component_Fields_Title, GenerateActionGroup.CLR_LANGUAGE,
    Strings.UnityDots_GenerateComponentReference_Unity_Component_Fields_WindowTitle,
    Strings.UnityDots_GenerateComponentReference_Unity_Component_Fields_Description, "Generate.ComponentReferences")
{
    public override double Order => 100;

    public override bool IsAvailable(IDataContext dataContext)
    {
        return DotsUtils.IsUnityProjectWithEntitiesPackage(dataContext) && base.IsAvailable(dataContext);
    }
}