@description('Environment')
param environment string

resource configStore 'Microsoft.AppConfiguration/configurationStores@2023-03-01' existing = {
  name: "jmhh-app-configuration"
}

resource configStoreKeyValue 'Microsoft.AppConfiguration/configurationStores/keyValues@2023-03-01' = {
  parent: configStore  
  name: "fixed-item"
  properties: {
    value: "fixed-item-value"
    contentType: "application/json"
    tags: null
  }
}]
