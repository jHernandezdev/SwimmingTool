@description('Specifies the name of the App Configuration store.')
param configStoreName string

@description('Specifies the names of the key-value resources. The name is a combination of key and label with $ as delimiter. The label is optional.')
param keyValueNames array

@description('Specifies the values of the key-value resources. It\'s optional')
param keyValueValues array

@description('Specifies the content type of the key-value resources. For feature flag, the value should be application/vnd.microsoft.appconfig.ff+json;charset=utf-8. For Key Value reference, the value should be application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8. Otherwise, it\'s optional.')
param contentType string = 'application/json'

@description('Adds tags for the key-value resources. It\'s optional')
param tags object = {}

@description('Environment')
param environment string

resource configStore 'Microsoft.AppConfiguration/configurationStores@2023-03-01' existing = {
  name: configStoreName
}

resource configStoreKeyValue 'Microsoft.AppConfiguration/configurationStores/keyValues@2023-03-01' = [for (item, i) in keyValueNames: {
  parent: configStore  
  name: item
  properties: {
    value: keyValueValues[i]
    contentType: contentType
    tags: tags
  }
}]
