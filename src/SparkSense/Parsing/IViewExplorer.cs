using System;
using System.Collections.Generic;
using Spark.Compiler;

namespace SparkSense.Parsing
{
    public interface IViewExplorer
    {
        IList<string> GetRelatedPartials();
        IList<string> GetPossibleMasterLayouts();
        IList<string> GetPossiblePartialDefaults(string partialName);
        IList<string> GetGlobalVariables();
        IList<string> GetLocalVariables();
        IList<string> GetContentNames();
        IList<string> GetLocalMacros();
        IList<string> GetMacroParameters(string macroName);
        IList<string> GetMembers();
        void InvalidateView(string newContent);
        TypeNavigator GetTypeNavigator();
        IEnumerable<LocalVariableChunk> GetLocalVariableChunks();
        IEnumerable<ViewDataChunk> GetViewDataVariableChunks();
        IEnumerable<AssignVariableChunk> GetAssignedVariableChunks();
    }
}
