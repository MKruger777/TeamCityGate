
namespace TeamCityGate
{
    using CommandLine;

    public class Options
        {
            [Option(Constants.Options.TeamCityURL_u, Required = true, HelpText = Constants.Options.TeamCityURL)]
            public string TeamCityUrl { get; set; }

            [Option(Constants.Options.TCBuildConfID_i, Required = true, HelpText = Constants.Options.TCBuildConfID)]
            public string TCBuildConfID { get; set; }

            //[Option(Constants.Options.TfsSourceBranch_s, Required = true, HelpText = Constants.Options.TfsSourceBranch)]
            //public string TfsSourceBranch { get; set; }

            //[Option(Constants.Options.TfsTargetBranch_t, Required = true, HelpText = Constants.Options.TfsTargetBranch)]
            //public string TfsTargetBranch { get; set; }
        }
    }
