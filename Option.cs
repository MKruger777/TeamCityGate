
namespace TeamCityGate
{
    using CommandLine;

    public class Options
    {
        [Option(Constants.Options.TeamCityURL_u, Required = true, HelpText = Constants.Options.TeamCityURL)]
        public string TeamCityUrl { get; set; }

        [Option(Constants.Options.TCBuildConfID_i, Required = true, HelpText = Constants.Options.TCBuildConfID)]
        public string TCBuildConfID { get; set; }

        [Option(Constants.Options.VCRevision_r, Required = true, HelpText = Constants.Options.VCRevision)]
        public int VCRevision { get; set; }
    }
}
