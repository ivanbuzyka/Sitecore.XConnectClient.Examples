using Sitecore.XConnect.Client;

namespace SitecoreXConnectClient.Examples
{
  public static class GetContactByIdExample
  {
    public static async Task<string> Run(XConnectClient client, string contactId)
    {
      var reference = new Sitecore.XConnect.ContactReference(Guid.Parse(contactId));
      Task<Sitecore.XConnect.Contact> contactTask = client.GetAsync<Sitecore.XConnect.Contact>(reference, new Sitecore.XConnect.ContactExpandOptions() { });
      Sitecore.XConnect.Contact contact = await contactTask;
      Console.WriteLine(contact.Id);

      return "success!";
    }
  }
}
