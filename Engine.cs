using System;
using System.IO;

namespace Cmd
{

   internal class Engine
   {     
       private string _currentDirectory = Directory.GetCurrentDirectory();
        
       public void MainLoop()
       {
          
            var dones = true;

            while (dones)
            {
                ShowCurrentDirectory();
                var inputString = Console.ReadLine();
                var comand = ParseComand(inputString); 
                switch (comand)
                {
                    case Command.StrExit:
                        dones = false;
                        break;
                    case Command.StrDir:
                      var dir = new Dir(inputString);
                        dir.Execute();
                        break;
                    case Command.StrCd:
                        var cd = new Cd(inputString);
                        cd.Execute();
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;

                }
            }
       }

       private void ShowCurrentDirectory()
       {
            _currentDirectory = Directory.GetCurrentDirectory();
            Console.Write("\n" + _currentDirectory + ">");
       }

       private static string ParseComand(string command)
       {
           if(command.StartsWith("dir"))
               return Command.StrDir;
           if (command.StartsWith("cd "))
               return Command.StrCd;
           if (command.StartsWith("exit"))
               return Command.StrExit;
           
           return Command.ErrorCommand;
        }
   }
}
