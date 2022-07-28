using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;

namespace SitecoreXConnectClient.Examples
{
  public static class DeepPaginationAndBatchingExample
  {
    public static async Task<string> Run(XConnectClient client)
    {
      var allInteractions = new List<Interaction>();
      var results = client.Interactions.Where(x => x.GetFacet<WebVisit>(CollectionModel.FacetKeys.WebVisit).Browser.BrowserMajorName == "Chrome");
      var enumerator = await results.GetBatchEnumerator(4);

      var numberOfBatches = 0;

      while (await enumerator.MoveNext())
      {
        numberOfBatches++;

        foreach (var interaction in enumerator.Current)
        {
          // do something for each interaction
          allInteractions.Add(interaction);
        }
      }

      return "Success!";

    }
  }
}
