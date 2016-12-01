using System;
using System.IO;

namespace Cmd
{
    public class Dir:Command
    {
        public Dir(string command)
            : base(command)
        {
        }

        private static void ShowConsistDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("\nСодержимое папки {0}", currentDirectory);

            var files = Directory.GetFiles(currentDirectory);
            var countFiles = files.Length;
            Console.WriteLine("\n Files {0}\n", countFiles);
            for (var i = 0; i < countFiles; i++)
            {
                var sections = files[i].Split('\\');
                var fileName = sections[sections.Length - 1];
                Console.WriteLine(fileName);
            }

            var directories = Directory.GetDirectories(currentDirectory);
            var countDirectories = directories.Length;
            Console.WriteLine("\n Folders {0}\n", countDirectories);
            foreach (var dir in directories)
            {
                var sections = dir.Split('\\');
                var dirName = sections[sections.Length - 1];
                Console.WriteLine(dirName);
            }
/*

            var directories = string.Join(Environment.NewLine, Directory.GetDirectories(currentDirectory));
            var files = string.Join(Environment.NewLine, Directory.GetFiles(currentDirectory));
 */
        }

        protected override string GetValueCommand()
        {
            return StrDir == StrCommand ? String.Empty : ErrorCommand;
        }
        public override void Execute()
        {
            if(GetValueCommand() == String.Empty)
                ShowConsistDirectory();
            else
                ShowErrorCommand();
        }
    }
}
