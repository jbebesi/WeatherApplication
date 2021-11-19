$resourceGroup = "WettaDev1"
$location = "westeurope"
$appName = "WettaDevTest"

# Create a resource group
az group create --name $resourceGroup --location $location

# Create a container registry
az acr create --resource-group $resourceGroup --name $resourceGroup --sku Basic


# Create a Kubernetes cluster
az aks create \
    --resource-group $resourceGroup \
    --name $appName \
    --node-count 1 \
    --enable-addons monitoring \
    --generate-ssh-keys \
    --kubernetes-version 1.22.2

