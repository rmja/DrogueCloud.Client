namespace DrogueCloud.Client.Models.Registry;

public class DeviceCredentials : List<ICredential>
{
    public bool IsValidPassword(string password)
    {
        foreach (var credential in this.OfType<PassCredential>())
        {
            if (credential.Pass.IsValidPassword(password))
            {
                return true;
            }
        }
        return false;
    }
}
