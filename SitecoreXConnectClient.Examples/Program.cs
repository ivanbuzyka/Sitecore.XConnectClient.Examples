// See https://aka.ms/new-console-template for more information
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.WebApi;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using Sitecore.Xdb.Common.Web;
using SitecoreXConnectClient.Examples;

// URL of your XConnect instance
var xConnectBaseUrl = "https://fxmdemo.xconnect";
var refDataUrl = "https://fxmdemo.xconnect/";

//The client certificate path and thumbprint here
var xConnectClientCertificateThumbprint = "C041A3331C596492C6C62BE43EAEDE922875ABCA";
// NOTE: don't want to mess up with the cerificate (find the right one, install that one on the right machine etc. etc.)? Go to the XConnect app and comment '<add key="validateCertificateThumbprint"' setting in the AppSettings.config. Of course THAT IS NOT THE GOOD IDEA FOR PRODUCTION!

CertificateHttpClientHandlerModifierOptions options = CertificateHttpClientHandlerModifierOptions.Parse($"StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue={xConnectClientCertificateThumbprint}");

var certificateModifier = new CertificateHttpClientHandlerModifier(options);
List<IHttpClientModifier> clientModifiers = new List<IHttpClientModifier>();
var timeoutClientModifier = new TimeoutHttpClientModifier(new TimeSpan(0, 0, 20));
clientModifiers.Add(timeoutClientModifier);

// This overload takes three client end points - collection, search, and configuration
var collectionClient = new CollectionWebApiClient(new Uri($"{xConnectBaseUrl}/odata"), clientModifiers, new[] { certificateModifier });
var searchClient = new SearchWebApiClient(new Uri($"{xConnectBaseUrl}/odata"), clientModifiers, new[] { certificateModifier });
var configurationClient = new ConfigurationWebApiClient(new Uri($"{xConnectBaseUrl}/configuration"), clientModifiers, new[] { certificateModifier });

var cfg = new XConnectClientConfiguration(new XdbRuntimeModel(CollectionModel.Model), collectionClient, searchClient, configurationClient);

//initializing configuration, that makes OData request GET https://<xconnect-hostname>/configuration/models
await cfg.InitializeAsync();

using (var client = new XConnectClient(cfg))
{
  //Now the client is there and we can use it
  //Want to see how those OData calls look (headers, request body etc.)? Use Fiddler and enable HTTPS decryption https://www.dynatrace.com/support/help/how-to-use-dynatrace/real-user-monitoring/setup-and-configuration/web-applications/troubleshooting/capture-https-sessions-for-debugging-using-fiddler

  var contactIdToLookFor = "D8DA538A-49E0-0000-0000-067A7934BB9F";

  // Example 1 - get contact by ID  
  string result1 = await GetContactByIdExample.Run(client, contactIdToLookFor);

  // Example 2 - Get interactions paginated (using skip and take methods)
  string result2 = await PaginationExample.Run(client);

  // Example 3 - Filtering and expanding example https://doc.sitecore.com/xp/en/developers/92/sitecore-experience-platform/get-contact-with-interactions.html
  string result3 = await FilteringInteractionsExample.Run(client, contactIdToLookFor);

  // Example 4 - Getting batched enumerator https://doc.sitecore.com/xp/en/developers/93/sitecore-experience-platform/paginatingxconnect-search-results.html
  // Note: basically the same as skip take
  string result4 = await DeepPaginationAndBatchingExample.Run(client);
}

// Example 5 - reference data calls. Getting refdata entities by reference data type. Doc https://doc.sitecore.com/xp/en/developers/90/sitecore-experience-platform/reference-data-client-api.html
var result5 = await RefdataExamples.Run(refDataUrl, clientModifiers);