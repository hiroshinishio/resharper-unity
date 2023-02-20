using JetBrains.Application.DataContext;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.DataContext;
using JetBrains.ReSharper.Feature.Services.Generate.Actions;
using JetBrains.ReSharper.Feature.Services.Generate.Workflows;
using JetBrains.ReSharper.Plugins.Unity.Core.ProjectModel;
using JetBrains.ReSharper.Plugins.Unity.Resources;
using JetBrains.ReSharper.Plugins.Unity.Resources.Icons;
using JetBrains.ReSharper.Plugins.Unity.UnityEditorIntegration.Packages;

namespace JetBrains.ReSharper.Plugins.Unity.CSharp.Feature.Services.Generate.Dots
{
    public class GenerateBakerAndAuthoringActionWorkflow : GenerateCodeWorkflowBase
    {
        public GenerateBakerAndAuthoringActionWorkflow()
            : base(GeneratorUnityKinds.UnityGenerateBakerAndAuthoring, LogoIcons.Unity.Id, Strings.UnityDots_GenerateBakerAndAuthoring_Unity_Component_Fields_Title, GenerateActionGroup.CLR_LANGUAGE,
                Strings.UnityDots_GenerateBakerAndAuthoring_Unity_Component_Fields_WindowTitle, Strings.UnityDots_GenerateBakerAndAuthoring_Unity_Component_Fields_Description, "Generate.BakerAndAuthoring")
        {
        }

        public override double Order => 100;

        // Hides the menu item if it's not a Unity project
        public override bool IsAvailable(IDataContext dataContext)
        {
            var solution = dataContext.GetData(ProjectModelDataConstants.SOLUTION);
            if (solution == null || !solution.HasUnityReference())
                return false;

            var project = dataContext.GetData(ProjectModelDataConstants.PROJECT);
            if (project != null && !project.IsUnityProject())
                return false;

            var packageManager = solution.GetComponent<PackageManager>();
            if (!packageManager.HasPackage(PackageManager.UnityEntitiesPackageName))
                return false;
            
            return base.IsAvailable(dataContext);
        }
    }
}