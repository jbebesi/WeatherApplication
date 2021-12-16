# Main Environment settings.
$appName = "weatherappjbebesi"
$resourceGroup = $appName + "dev"
$location = "westeurope"
$sonarqaciname = "sonar" + $resourceGroup
$acrname = "acr" + $resourceGroup
$appServicePlan = $appName + "serviceplan"

$devopsprojectexists = $false
$devopsservice = $appName

#### Setup Azure devops

$devopsservice = Read-Host -Prompt 'Type the of URL DevOps with your organization e.g. : https://dev.azure.com/your_orgnization_name'
$env:AZURE_DEVOPS_EXT_PAT ="tvxrvghc7cysmqtsxyruajkubk7u2ngrwv7znqsrjkmodm2niqka"
Write-Host 'Get projectllist from ' + $devopsservice
$a = az devops project list --organization $devopsservice --query value[].name -o tsv
# To validate if the resource already exists
try 
{
    foreach ($item in $a) {
        switch ($item) {
            ($appName)
            { 
                $devopsprojectexists = $true
                Write-Host "project exists:" + $appName
            }
           
        }
    }
}
catch 
{
    Ignore this error
}

# Create a Key Vault to store secrets
Write-Host 'Creating '+ $appName+ ' project if not exists.....' 
if ($devopsprojectexists -eq $false)
{
    az devops project create --name $appName --organization $devopsservice
}


az devops configure --defaults project="DevSecOps" organization=$devopsservice

Write-Host 'Adding security extensions to your Azure DevOps'
az devops extension install --extension-id 'AzSDK-task' --publisher-id 'azsdktm' --detect true
az devops extension install --extension-id 'sonarqube' --publisher-id 'SonarSource' --detect true
az devops extension install --extension-id 'replacetokens' --publisher-id 'qetza' --detect true
az devops extension install --extension-id 'ws-bolt' --publisher-id 'whitesource' --detect true


# Register the network provider
az provider register --namespace Microsoft.Network


##### Setup Azure services
$items = az resource list --query --% "[?contains(name,'weatherapp')].[name]" -o table

#Variables to use during execution
$acrexists = $false
$snrexists = $false
$svcpexists = $false
$appexists = $false
try
{
    foreach($item in $items)
    {
        switch($item)
        {
            ($acrname) {$acrexists = $true}
            ($sonarqaciname) {$snrexists = $true}
            ($appServicePlan) {$svcpexists = $true}
            ($appName){$appexists = $true}
        }
    }
}
catch
{
    #ignore 
}

# Create a ressource groupe
Write-Host 'Running Resource Group .....' 
if ($(az group exists --name $resourceGroup) -eq $false)
{
    az group create --name $resourceGroup --location $location --verbose
    Write-Host 'Ressource groupe : ' + $resourceGroup + ' created '
}
else
{
    Write-Host('resource group already exists');
}

Write-Host 'Running ACR service .....' 
if ($acrexists -eq $false)
{
    az acr create --resource-group $resourcegroup --name $acrname --sku standard --location $location --admin-enabled true
    write-host 'azure container registry : ' + $acrname + ' created '
}else
{
    Write-Host('acr already exists');
}

# Create service SonarQube  in Azure Container Instances
Write-Host 'Running SonarQube .....' 
if ($snrexists -eq $false)
{
    az container create -g $($resourceGroup) --name $sonarqaciname --image  sonarqube:latest --ports 9000 --dns-name-label $sonarqaciname'dns' --cpu 2 --memory 3.5
    Write-Host 'Azure Web App SonarQube : ' + $sonarqaciname + ' created '
}
else
{
    Write-Host('Sonar already exists');
}

# Create service plan for OWASP top 10
Write-Host 'Running service plan .....' 
if ($svcpexists -eq $false)
{
    az appservice plan create -g $resourceGroup -n $appServicePlan --is-linux --number-of-workers 1 --sku f1
    Write-Host 'Azure App Service plan : ' + $appServicePlan + ' created '
}
else
{
    Write-Host 'service plan exists'
}

# Create service WebApp for OWASP top 10
#Write-Host 'Running WebApp .....' 
#if ($appexists -eq $false)
#{
#    $app = $appName + "jbebesi"
#    az webapp create --resource-group $resourceGroup --plan $appServicePlan --name $app  #--deployment-container-image-name demosecops/juice-shop:v9.3.1
#    Write-Host 'Azure Web App : ' + $app + ' created '
#}
#else
#{
#    Write-Host 'app exits'
#}