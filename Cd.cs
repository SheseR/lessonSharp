using System;
using System.IO;

namespace Cmd
{
    public class Cd:Command
    {
        private const string strGoToParent = "..";
        public Cd(string command)
            : base(command)
        {
        }
        protected override string GetValueCommand()
        {
            string[] word = StrCommand.Split(' ');

            if(word.Length != 2)
                return ErrorCommand;

            return word[1];
        }
        public override void Execute()
        {
            var strValue = GetValueCommand();
            if (strValue == ErrorCommand)
            {
                ShowErrorCommand();
                return;
            }
            try
            {
                if (strValue == strGoToParent)
                {
                    GoToParentDirectory();
                    return;
                }

                if (strValue[1] == ':')
                    GoToRootDisk(strValue);
                else
                    GoToChildDirectory(strValue);
            }
            catch (DirectoryNotFoundException dirException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found " + dirException);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }
        private static void GoToParentDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Directory.GetParent(currentDirectory).ToString());    
        }
        private static void GoToChildDirectory(string child)
        {         
            try
            {
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"\" + child);
            }
            catch (DirectoryNotFoundException dirException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }      
        private static void GoToRootDisk(string valueDirectory)
        {
            Directory.SetCurrentDirectory(valueDirectory + @"\");
        }
    }
}
