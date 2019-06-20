using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using TeamCitySharp;

namespace TeamCityGate
{
    public class BuildValidator
    {
        public string TeamCityUrl { get; set; }
        public string TeamCityBuildConfID { get; set; }

        public bool Validate(int max_vc_rev_num_to_merge)
        {
            // this function expects the biggest cs numer in the range that is up for auto merge 
            //The idea here will be to pass the greatst of revision number you have.
            // Let us assume you have the following changsets which is up for mwerge:
            // 1235
            // 1246
            // 1247
            // 1255
            //For each of these there will be a build. This means that if we take the satus of the build for the largest of these
            //we will get an indication that should tell us if all is wel after these were checked in
            int last_successfull_build_vc_rev = GetLastSuccessfulVCRev();
            if (last_successfull_build_vc_rev >= max_vc_rev_num_to_merge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetLastSuccessfulVCRev()
        {
            var client = new TeamCityClient(TeamCityUrl, true);
            string buildConfigId = TeamCityBuildConfID;
            try
            {
                client.Connect(@"un", @"pw");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //retrieve latest successfull build
            TeamCitySharp.DomainEntities.Build b = client.Builds.LastSuccessfulBuildByBuildConfigId(buildConfigId, null);
            string lastSuccessfullBuildId = b.Id;
            string build_status = b.Status;

            //now get the build info
            var buildinfo = client.Builds.ById(b.Id);
            var buildNumber = buildinfo.Number;

            //The version control revision is not allways present in the build info - especialy in the way the TC templates is structured within Binck
            //Now get the SnapshotDependencies build resource link...
            string bldSnapshotDepHref = buildinfo.SnapshotDependencies.Build[0].Href;
            string snapshotBuildDepTypeId = buildinfo.SnapshotDependencies.Build[0].BuildTypeId;

            //Now use the link isolated in the SnapshotDependencies to locate the change that was used in the compile
            string vc_revision = RetrieveVCRevisionUsed(bldSnapshotDepHref);

            Console.WriteLine(Environment.NewLine + "Last successfull build for {0} is build number:{1} (build id:{2})", buildConfigId, buildNumber, lastSuccessfullBuildId);
            Console.WriteLine("For build id:{0} the linked VC revision is:{1}", lastSuccessfullBuildId, vc_revision);
            Console.WriteLine("The status of build id:{0} was: {1}", lastSuccessfullBuildId, build_status);
            return int.Parse(vc_revision);
        }

        private string RetrieveVCRevisionUsed(string resource)
        {
            string change_vcrevision = string.Empty;
            var client = new RestClient(@"https://" + TeamCityUrl);
            client.Authenticator = new HttpBasicAuthenticator(@"un", @"pw");

            var request = new RestRequest(resource, Method.GET, DataFormat.Json);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);

            JObject jObject = JObject.Parse(response.Content);
            JObject changes = (JObject)jObject.SelectToken("lastChanges");
            JArray buildChange = (JArray)changes.SelectToken("change");  //works

            int buildChangesCount = buildChange == null ? 0 : buildChange.Count;
            Console.WriteLine(Environment.NewLine + "The number of changes in the build = " + buildChangesCount);

            if (buildChangesCount == 1)
            {
                foreach (JToken signInName in buildChange)
                {
                    string change_id = (string)signInName.SelectToken("id");
                    change_vcrevision = (string)signInName.SelectToken("version");
                    string change_username = (string)signInName.SelectToken("username");
                    string change_date = (string)signInName.SelectToken("date");
                    string change_href = (string)signInName.SelectToken("href");
                    string change_webUrl = (string)signInName.SelectToken("webUrl");

                    Console.WriteLine(Environment.NewLine + "Change details retrived are:");
                    Console.WriteLine("Linked build change = " + change_id);
                    Console.WriteLine("Version Control revision = " + change_vcrevision);
                    Console.WriteLine("Change made by user = " + change_username);
                    Console.WriteLine("Change date = " + change_date);
                    Console.WriteLine("Change href = " + change_href);
                    Console.WriteLine("Change webUrl = " + change_webUrl);
                }
            }
            else
            {
                Console.WriteLine("The number of changes in the build = " + buildChangesCount + "is unexpected - please investigate. 1 change per build is expected");
            }
            return change_vcrevision;
        }
    }
}
