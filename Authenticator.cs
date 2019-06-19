
namespace TeamCityGate
{
    public static class Authenticator
    {
        public static bool Authenticate(string username, string password)
        {
            bool Authenticated = false;
            return Authenticated;
        //    Credential credential = new Credential();
        //    if (username == null || password == null)
        //    {
        //        credential = GetCredentials();
        //    }
        //    else
        //    {
        //        credential.UserName = username;
        //        credential.Password = password;

            //        if (!AuthenticateToAD(credential))
            //        {
            //            credential.Valid = false;
            //        }
            //    }

            //    if(credential.Valid)
            //    {
            //        StaticData staticData = StaticData.GetInstance();
            //        staticData.TeamCityUserName = credential.UserName;
            //        staticData.TeamCityPassword = credential.Password;
            //        Authenticated = true;
            //    }
            //    return Authenticated;
            //}

            //public static Credential GetCredentials()
            //{
            //    Credential credential = new Credential();
            //    ConsoleHelper.WriteLine("Do you wish to run the process as the current user? " + Environment.UserName, ConsoleColor.White);
            //    ConsoleHelper.WriteLine("Yes [y] or [n] to enter a different account...", ConsoleColor.White);
            //    string response = Console.ReadLine().Trim().ToLower();
            //    if (response.Equals("y"))
            //    {
            //        credential.UserName = Environment.UserName;
            //    }
            //    else if (response.Equals("n"))
            //    {
            //        ConsoleHelper.WriteLine("Provide a valid domain account.", ConsoleColor.White);
            //        ConsoleHelper.WriteLine("   Enter username:", ConsoleColor.White);
            //        credential.UserName = Console.ReadLine();
            //    }
            //    else
            //    {
            //        ConsoleHelper.WriteLine("Incorrect selection!", ConsoleColor.Red);
            //        credential.Valid = false;
            //        return credential;
            //    }

            //    ConsoleHelper.WriteLine("   Enter password:", ConsoleColor.White);
            //    string password = "";
            //    ConsoleKeyInfo info = Console.ReadKey(true);
            //    while (info.Key != ConsoleKey.Enter)
            //    {
            //        if (info.Key != ConsoleKey.Backspace)
            //        {
            //            password += info.KeyChar;
            //            info = Console.ReadKey(true);
            //        }
            //        else if (info.Key == ConsoleKey.Backspace)
            //        {
            //            if (!string.IsNullOrEmpty(password))
            //            {
            //                password = password.Substring
            //                (0, password.Length - 1);
            //            }
            //            info = Console.ReadKey(true);
            //        }
            //    }

            //    for (int i = 0; i < password.Length; i++) Console.Write("*");
            //    credential.Password = password;

            //    if (!AuthenticateToAD(credential))
            //    {
            //        credential.Valid = false;
            //    }
            //    return credential;
            //}

            //private static bool AuthenticateToAD(Credential credential)
            //{
            //    string domain = ConfigurationManager.AppSettings["Domain"];
            //    bool isValid = false;
            //    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            //    {
            //        isValid = pc.ValidateCredentials(credential.UserName, credential.Password,ContextOptions.Negotiate);
            //        if (!isValid)
            //        {
            //            ConsoleHelper.WriteLine(Environment.NewLine + "Provided credentials failed to authenticate on : " + domain, ConsoleColor.Red);
            //        }
            //    }
            //    return isValid;
            }
        }
}
