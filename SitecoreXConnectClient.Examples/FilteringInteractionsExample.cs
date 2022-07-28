using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;

namespace SitecoreXConnectClient.Examples
{
  public static class FilteringInteractionsExample
  {
    public static async Task<string> Run(XConnectClient client, string contactId)
    {

      var reference = new Sitecore.XConnect.ContactReference(Guid.Parse(contactId));      
      var contactTask = client.GetAsync<Contact>(reference, new ContactExpandOptions(PersonalInformation.DefaultFacetKey)
      {
        Interactions = new RelatedInteractionsExpandOptions(WebVisit.DefaultFacetKey)
        {
          StartDateTime = DateTime.MinValue,
          Limit = 2
        }
      });

      var contact = await contactTask;
      
      return "Success!";
    }
  }
}
