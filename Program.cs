using System;

namespace TeamCityGate
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            //bool vcRevisionBuildStatus = false;

            try
            {
                timer.Start();
                Options options = new Options();
                if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
                {
                    if (ParameterValidation.ParameterContentValid(options))
                    {
                        EchoParameters(options);
                        BuildValidator buildValidator = new BuildValidator();
                        buildValidator.TeamCityUrl = options.TeamCityUrl;
                        buildValidator.TeamCityBuildConfID = options.TCBuildConfID;
                        buildValidator.Validate(options.VCRevision);
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

            ConsoleHelper.WriteLine(Environment.NewLine);
            ConsoleHelper.WriteLine("Run duration : " + timer.Stop());
            ConsoleHelper.WriteLine("Application will terminate");
            ConsoleHelper.WriteLine(Environment.NewLine + "Press any key to continue...", ConsoleColor.Green);
            Console.ReadKey();
            //return vcRevisionBuildStatus;
        }
        
        private static void EchoParameters(Options options)
        {
            ConsoleHelper.WriteLine(Environment.NewLine + "Received parameters: ");
            ConsoleHelper.WriteLine(Constants.Options.TeamCityURL_u + " : " + options.TeamCityUrl);
            ConsoleHelper.WriteLine(Constants.Options.TCBuildConfID_i + " : " + options.TCBuildConfID);
            ConsoleHelper.WriteLine(Constants.Options.VCRevision_r + " : " + options.VCRevision);
        }
    }
}
