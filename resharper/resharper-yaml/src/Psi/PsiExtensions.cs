using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.Yaml.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.Yaml.Psi
{
  public static class PsiExtensions
  {
    [CanBeNull]
    public static string GetPlainScalarText([CanBeNull] this INode node)
    {
      return node is IPlainScalarNode scalar ? scalar.Text.GetText() : null;
    }

    [CanBeNull]
    public static IBlockMappingEntry FindMapEntryBySimpleKey([CanBeNull] this IBlockMappingNode mapNode, string keyName)
    {
      if (mapNode == null)
        return null;

      foreach (var mappingEntry in mapNode.EntriesEnumerable)
      {
        if (mappingEntry.Key.GetPlainScalarText() == keyName)
          return mappingEntry;
      }

      return null;
    }

    [CanBeNull]
    public static IFlowMapEntry FindMapEntryBySimpleKey([CanBeNull] this IFlowMappingNode mapNode, string keyName)
    {
      if (mapNode == null)
        return null;

      foreach (var sequenceEntry in mapNode?.EntriesEnumerable)
      {
        if (sequenceEntry.Key.GetPlainScalarText() == keyName)
          return sequenceEntry;
      }

      return null;
    }
  }
}