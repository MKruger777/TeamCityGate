
namespace TeamCityGate
{
    public class Credential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; }

        public Credential()
        {
            Valid = true;
        }
    }
}
