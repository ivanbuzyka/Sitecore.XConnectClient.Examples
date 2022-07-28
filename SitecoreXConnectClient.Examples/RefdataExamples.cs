using Microsoft.Extensions.Logging;
using Sitecore.Xdb.Common.Web;
using Sitecore.Xdb.ReferenceData.Client;
using Sitecore.Xdb.ReferenceData.Core;
using Sitecore.Xdb.ReferenceData.Core.Converter;

namespace SitecoreXConnectClient.Examples
{
  public static class RefdataExamples
  {
    public static async Task<string> Run(string refDataUrl, List<IHttpClientModifier> modifiers)
    {
      var converter = new DefinitionEnvelopeJsonConverter();
      var logger = new Logger<ReferenceDataHttpClient>(new LoggerFactory());
      var refDataClient = new ReferenceDataHttpClient(converter, new Uri(refDataUrl), modifiers, logger);

      var definitionType = await refDataClient.EnsureDefinitionTypeAsync("Sitecore XP Goal");

      //The ID of the login Goal
      var criteria = new DefinitionCriteria("66722f52-2d13-4dcc-90fc-ea7117cf2298", definitionType);
      var definition = await refDataClient.GetDefinitionAsync<string, string>(criteria, false);

      //var definitions = await refDataClient.GetDefinitionsByTypeAsync<string, string>(definitionType, true, 1, 10);
      //var pageOneDefinitions = definitions.Definitions;
      //var currentPage = definitions.PageNumber;
      //var currentPageSize = definitions.PageSize;
      //var totalDefinitions = definitions.Total; // Total number of definitions with type 'Sitecore XP Goal'      
      return "Success!";
    }
  }
}
