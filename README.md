# Sitecore.XConnectClient.Examples

## Intro

This repo contains usage examples of the XConnect and Reference Data OData endpoints uising appropriate Client libraries.

## Actual OData requests

Below I would lilke to describe how the underlying OData requests looks like. I used Feedler for preparing this information.

### Legend

1. I used my local hostnames for RefData and XConnect collection, please use your ones
2. **Note** that I have XConnect single instance, therefore XConnect  Collection and Reference Data examples have the same host name.
3. Both XConnect and RefData endpoints use the same client certificate authentication

### Pagination Example ```PaginationExample.cs```

Method: ```POST```

Endpoint: ```https://fxmdemo.xconnect-secondary/odata/Interactions/Sitecore.XConnect.Search```

**Request Body Example 1** (only skip/take, without search condition):

```json

{
  "SearchQueryJson": "{\"Domain\":\"Interactions\",\"Predicate\":{\"$type\":\"Sitecore.XConnect.Search.Queries.MatchAllNode, Sitecore.XConnect.Search\",\"NodeType\":\"MatchAll\"},\"ResultOptions\":{\"UsesPagingCursor\":false,\"IncludeCount\":true,\"Skip\":2,\"Top\":2,\"Sort\":[],\"PagingCursor\":null}}"
}

```

**Request Body Example 2** (skip/take, with search condition - get interactions where WebVisit facets ```Browser.BrowserMajorName``` property is equal to ```Chrome``` has ):

```json

{
    "SearchQueryJson": "{\"Domain\":\"Interactions\",\"Predicate\":{\"$type\":\"Sitecore.XConnect.Search.Queries.FieldEqualsNode, Sitecore.XConnect.Search\",\"Field\":{\"Path\":[\"WebVisit\",\"Browser\",\"BrowserMajorName\"],\"ConstantType\":\"String\",\"NodeType\":\"Field\"},\"Value\":{\"ConstantType\":\"String\",\"Value\":\"Chrome\",\"NodeType\":\"Constant\"},\"NodeType\":\"FieldEquals\"},\"ResultOptions\":{\"UsesPagingCursor\":false,\"IncludeCount\":true,\"Skip\":2,\"Top\":2,\"Sort\":[],\"PagingCursor\":null}}"
  }

```

Response example:

```json
{
  "@odata.context": "https://fxmdemo.xconnect/odata/$metadata#Interactions",
  "@odata.count": 7,
  "value": [
    {
      "StartDateTime": "2022-07-28T07:27:03.5597185Z",
      "EndDateTime": "2022-07-28T07:27:32.2360864Z",
      "Duration": "PT28.6763679S",
      "ChannelId": "b418e4f2-1013-4b42-a053-b6d4dca988bf",
      "Initiator": "Contact",
      "UserAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49",
      "Id": "eb98205c-5e21-0000-0000-067a78ed61d5",
      "ConcurrencyToken": "410cb336-6b54-40f7-a4b6-dd449b5fc522",
      "LastModified": "2022-07-28T07:27:39.9765213Z",
      "Contact": {
        "@odata.id": "/Contacts(eb98205c-5e21-0000-0000-067a78ec7721)"
      },
      "DeviceProfile": {
        "@odata.id": "/DeviceProfiles(3ec15bad-dda9-443e-9817-ca1e9a715348)"
      },
      "Events": [
        {
          "@odata.type": "#Sitecore.XConnect.Collection.Model.PageViewEvent",
          "CustomValues": [],
          "DefinitionId": "9326cb1e-cec8-48f2-9a3e-91c7dbb2166c",
          "ItemId": "110d559f-dea5-42ea-9c1c-8a5df7e70ef9",
          "Id": "0a14aee6-86d2-4325-9101-05b3481bfadf",
          "Timestamp": "2022-07-28T07:27:03.5597185Z",
          "Duration": "PT24.326S",
          "ItemLanguage": "en",
          "ItemVersion": 1,
          "Url": "/",
          "SitecoreRenderingDevice": {
            "Id": "fe5d7fdf-89c0-4d99-9aa3-b5fbd009c9f3",
            "Name": "Default"
          }
        },
        {
          "@odata.type": "#Sitecore.XConnect.Collection.Model.PageViewEvent",
          "CustomValues": [],
          "DefinitionId": "9326cb1e-cec8-48f2-9a3e-91c7dbb2166c",
          "ItemId": "110d559f-dea5-42ea-9c1c-8a5df7e70ef9",
          "Id": "9233a92e-61e7-432a-8d15-fbddccf7bc39",
          "Timestamp": "2022-07-28T07:27:27.8861560Z",
          "Duration": "PT0.275S",
          "ItemLanguage": "en",
          "ItemVersion": 1,
          "Url": "/",
          "SitecoreRenderingDevice": {
            "Id": "fe5d7fdf-89c0-4d99-9aa3-b5fbd009c9f3",
            "Name": "Default"
          }
        },
        {
          "@odata.type": "#Sitecore.XConnect.Collection.Model.PageViewEvent",
          "CustomValues": [],
          "DefinitionId": "9326cb1e-cec8-48f2-9a3e-91c7dbb2166c",
          "ItemId": "110d559f-dea5-42ea-9c1c-8a5df7e70ef9",
          "Id": "207d79c1-fff2-4a7f-9d79-8d134ac86e66",
          "Timestamp": "2022-07-28T07:27:28.1618441Z",
          "ItemLanguage": "en",
          "ItemVersion": 1,
          "Url": "/",
          "SitecoreRenderingDevice": {
            "Id": "fe5d7fdf-89c0-4d99-9aa3-b5fbd009c9f3",
            "Name": "Default"
          }
        },
        {
          "@odata.type": "#Sitecore.XConnect.Collection.Model.PageViewEvent",
          "CustomValues": [],
          "DefinitionId": "9326cb1e-cec8-48f2-9a3e-91c7dbb2166c",
          "Id": "e331b871-06dc-446e-9d84-5d53df8c74b3",
          "Timestamp": "2022-07-28T07:27:32.2360864Z",
          "Url": "/flush.aspx",
          "SitecoreRenderingDevice": {
            "Id": "fe5d7fdf-89c0-4d99-9aa3-b5fbd009c9f3",
            "Name": "Default"
          }
        }
      ]
    },
    {
      "StartDateTime": "2022-07-28T07:35:27.5667425Z",
      "EndDateTime": "2022-07-28T07:35:27.5667425Z",
      "ChannelId": "b418e4f2-1013-4b42-a053-b6d4dca988bf",
      "Initiator": "Contact",
      "UserAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49",
      "Id": "d8da538a-49e0-0000-0000-067a7935220e",
      "ConcurrencyToken": "a6060949-8367-416b-9e36-f9cd474595b1",
      "LastModified": "2022-07-28T07:35:30.2030692Z",
      "Contact": {
        "@odata.id": "/Contacts(d8da538a-49e0-0000-0000-067a7934bb9f)"
      },
      "DeviceProfile": {
        "@odata.id": "/DeviceProfiles(77163cba-5531-4255-a607-9201ed580763)"
      },
      "Events": [
        {
          "@odata.type": "#Sitecore.XConnect.Collection.Model.PageViewEvent",
          "CustomValues": [],
          "DefinitionId": "9326cb1e-cec8-48f2-9a3e-91c7dbb2166c",
          "Id": "8c207258-d84c-4ab0-9611-6be145ff1588",
          "Timestamp": "2022-07-28T07:35:27.5667425Z",
          "Url": "/flush.aspx",
          "SitecoreRenderingDevice": {
            "Id": "fe5d7fdf-89c0-4d99-9aa3-b5fbd009c9f3",
            "Name": "Default"
          }
        }
      ]
    }
  ]
}

```

**Note**, if you would like to get Contacts instead of interactions, consider using appropriate ```Domain``` parameter in the ```SearchQueryJson``` object of request body.

### ReferenceData. Ensure definition type exists (get definition type ID by name)

In case you have only reference type name, e.g. ```Sitecore XP Goal```, you can easilly get the ID of that type using following request:

Method: ```PUT```

Endpoint: ```https://fxmdemo.xconnect/refdata/definitiontype/ensure```

Request Body Example:

```"Sitecore XP Goal"```

Response example:

```json
{"Id":"f75fc6c9-0af1-45dc-ac6d-05aca95878e1"}
```

### ReferenceData. Getting definition by ID and type

Following example can be used for getting the Reference information by reference ID (Moniker) and Reference Type.

Method: ```POST```

Endpoint: ```https://fxmdemo.xconnect/refdata/definition/get?latestActiveOnly=False```

Request body example:

```json
[
  {
    "Moniker": "66722f52-2d13-4dcc-90fc-ea7117cf2298",
    "TypeKey": { "Id": "f75fc6c9-0af1-45dc-ac6d-05aca95878e1" },
    "Version": null,
    "Culture": null
  }
]
```

**Note**: ```Culture``` and ```Version``` properties can be used to get language/version specific information

Response example:

```json
[
  {
    "CommonData": "eyJFbmdhZ2VtZW50VmFsdWVQb2ludHMiOjAsIklzTGl2ZUV2ZW50IjpmYWxzZSwiU2hvd0luWGZpbGVBc0xhdGVzdEV2ZW50Ijp0cnVlLCJTaG93SW5YZmlsZUV2ZW50c0xpc3QiOnRydWUsIklzU3lzdGVtIjpmYWxzZSwiQ3VzdG9tVmFsdWVzIjp7fSwiQ2xhc3NpZmljYXRpb25zIjp7fSwiQWxpYXMiOiJMb2dpbiJ9",
    "CultureData": {
      "en": "eyJOYW1lIjoiTG9naW4iLCJEZXNjcmlwdGlvbiI6IlVzZXIgaGFzIGxvZ2dlZCBvbiIsIkNyZWF0ZWREYXRlIjoiMjAwOC0xMi0xMVQwODo1NDozOFoiLCJDcmVhdGVkQnkiOiJzaXRlY29yZVxcQWRtaW4iLCJMYXN0TW9kaWZpZWRCeSI6InNpdGVjb3JlXFxBZG1pbiIsIkxhc3RNb2RpZmllZERhdGUiOiIyMDExLTA1LTI0VDEzOjMxOjAzLjk1MjI0ODhaIn0="
    },
    "DataTypeRevision": 1,
    "Key": "NjY3MjJmNTItMmQxMy00ZGNjLTkwZmMtZWE3MTE3Y2YyMjk4:f75fc6c9-0af1-45dc-ac6d-05aca95878e1:1",
    "TypeKey": { "Id": "f75fc6c9-0af1-45dc-ac6d-05aca95878e1" },
    "IsActive": true,
    "LastModified": "2022-07-29T10:22:35Z"
  }
]
```

**Note:** ```CommonData```  and ```CultureData``` is Base64-encoded data. if you would liek to get the information, do Base64-decode. For example above, the decoded value of ```CultureData``` will be following:

```json
{"Name":"Login","Description":"User has logged on","CreatedDate":"2008-12-11T08:54:38Z","CreatedBy":"sitecore\\Admin","LastModifiedBy":"sitecore\\Admin","LastModifiedDate":"2011-05-24T13:31:03.9522488Z"}
```

//TBD: Describe more calls for ReferenceData: e.g. get all definitions by type, get definition types etc.
