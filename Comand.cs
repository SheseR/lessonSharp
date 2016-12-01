using System;
using System.Collections.Specialized;

namespace Cmd
{ 
    public abstract class Command
    {
        protected string StrCommand;
        protected Command(string command)
        {
            StrCommand = command;
        }
        protected abstract string GetValueCommand();
        public abstract void Execute();
        protected void ShowErrorCommand()
        {
            Console.WriteLine("Command is wrong");
        }

        #region Const string value
        public const string StrCd = "cd";
        public const string StrDir = "dir";
        public const string StrHelp = "help";
        public const string StrExit = "exit";
        public const string StrAlias = "alias";
        public const string ErrorCommand = "error";

        #endregion
    }
}
