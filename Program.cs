using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCitySharp;
using TeamCitySharp.Locators;

namespace TeamCityGate
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            try
            {
                timer.Start();
                Options options = new Options();
                if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
                {
                    if (ParameterValidation.ParameterContentValid(options))
                    {
                        EchoParameters(options);
                        //Orchestrator orchestrator = new Orchestrator();
                        //orchestrator.Start();
                    }
                }
                else
                {
                    ConsoleHelper.WriteLine("Unknown syntax...", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine("Exception: " + ex.Message, ConsoleColor.Red);
            }
            finally
            {
                //HousKeeping housKeeping = new HousKeeping();
                //StaticData staticData = StaticData.GetInstance();
                //housKeeping.CleanUp(staticData.WorkSpaceName, staticData.WorkSpaceBaseDir);
            }

            ConsoleHelper.WriteLine(Environment.NewLine);
            ConsoleHelper.WriteLine("Run duration : " + timer.Stop());
            ConsoleHelper.WriteLine("Application will terminate");
            ConsoleHelper.WriteLine(Environment.NewLine + "Press any key to continue...", ConsoleColor.Green);
            Console.ReadKey();
        }
        
        private static void EchoParameters(Options options)
        {
            ConsoleHelper.WriteLine(Environment.NewLine + "Received parameters: ");
            ConsoleHelper.WriteLine(Constants.Options.TeamCityURL_u + " : " + options.TeamCityUrl);
            ConsoleHelper.WriteLine(Constants.Options.TCBuildConfID_i + " : " + options.TCBuildConfID);
        }
    }
}
