namespace JetBrains.ReSharper.Plugins.Yaml.Resources
{
  using System;
  using JetBrains.Application.I18n;
  using JetBrains.DataFlow;
  using JetBrains.Diagnostics;
  using JetBrains.Lifetimes;
  using JetBrains.Util;
  using JetBrains.Util.Logging;
  using JetBrains.Application.I18n.Plurals;
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public static class Strings
  {
    private static readonly ILogger ourLog = Logger.GetLogger("JetBrains.ReSharper.Plugins.Yaml.Resources.Strings");

    static Strings()
    {
      CultureContextComponent.Instance.Change.Advise(Lifetime.Eternal, args =>
      {
          var instance = args.HasNew ? args.New : null;
          if (instance != null)
          {
            ourResourceManager = new Lazy<JetResourceManager>(
              () =>
              {
                return instance
                  .CreateResourceManager("JetBrains.ReSharper.Plugins.Yaml.Resources.Strings", typeof(Strings).Assembly);
              });
          }
          else
          {
            ourResourceManager = null;
          };
      });
    }
    
    private static Lazy<JetResourceManager> ourResourceManager = null;
    
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    public static JetResourceManager ResourceManager
    {
      get
      {
        var resourceManager = ourResourceManager;
        if (resourceManager == null)
        {
          return ErrorJetResourceManager.Instance;
        }
        return resourceManager.Value;
      }
    }

    public static string Choice(string format, params object[] args)
    {
        var formatter = ResourceManager.ChoiceFormatter;
        if (formatter == null) return "???";
        return string.Format(formatter, format, args);
    }

    public static string CannotResolveSymbolMessage => ResourceManager.GetString("CannotResolveSymbolMessage");
    public static string Message => ResourceManager.GetString("Message");
    public static string YamlLanguageSpecificDaemonBehaviour_InitialErrorStripe_File_s_primary_language_in_not_Yaml => ResourceManager.GetString("YamlLanguageSpecificDaemonBehaviour_InitialErrorStripe_File_s_primary_language_in_not_Yaml");
  }
}