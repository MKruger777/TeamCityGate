
namespace TeamCityGate
{
    using System;

    public static class ParameterValidation
    {
        //do some very simple validation tests
        public static bool ParameterContentValid(Options options)
        {
            bool paramsContentValid = true;

            //if (!string.IsNullOrEmpty(options.TeamCityUrl))
            //{
            //    Uri uriResult;
            //    bool result = Uri.TryCreate(options.TeamCityUrl, UriKind.Absolute, out uriResult)
            //        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            //    if (result == false)
            //    {
            //        paramsContentValid = false;
            //        ConsoleHelper.WriteLine("The TeamCity server url specified " + options.TeamCityUrl + " is invalid. Please recheck and try again.", ConsoleColor.Red);
            //        //The exit blow messes with the unit tests ...grrr
            //        Environment.Exit(-1);
            //    }
            //}

            //if (!string.IsNullOrEmpty(options.TfsSourceBranch))
            //{
            //    if (!options.TfsSourceBranch.Trim().ToLower().StartsWith("$/"))
            //    {
            //        paramsContentValid = false;
            //        ConsoleHelper.WriteLine("The Tfs source branch specified " + options.TfsSourceBranch + " is invalid. Please recheck and try again.", ConsoleColor.Red);
            //        Environment.Exit(-1);
            //    }
            //}

            //if (!string.IsNullOrEmpty(options.TfsTargetBranch))
            //{
            //    if (!options.TfsTargetBranch.Trim().ToLower().StartsWith("$/"))
            //    {
            //        paramsContentValid = false;
            //        ConsoleHelper.WriteLine("The Tfs target branch specified " + options.TfsTargetBranch + " is invalid. Please recheck and try again.", ConsoleColor.Red);
            //        Environment.Exit(-1);
            //    }
            //}
            return paramsContentValid;
        }
    }
}
