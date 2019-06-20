
namespace TeamCityGate
{
    public static class Constants
    {
        public static class Options
        {
            public const char TeamCityURL_u = 'u';
            public const string TeamCityURL = "Specify the TeamCity URL. example: https://build.binckbank.nv";

            public const char TCBuildConfID_i = 'i';
            public const string TCBuildConfID = "Specify the teamcity build config id to be used. example: Topline_T1_Build";

            public const char VCRevision_r = 'r';
            public const string VCRevision = "Specify the version control revision that will be checked. example: 159172 ";
        }
    }
}
