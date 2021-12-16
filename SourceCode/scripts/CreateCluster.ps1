# Main Environment settings.
$appName = "weatherapp"
$resourceGroup = $appName + "dev"
$location = "westeurope"
$sonarqaciname = "sonart" + $resourceGroup
$acrname = "acr" + $resourceGroup
$appServicePlan = $appName + "serviceplan"



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
    az container create -g $($resourceGroup) --name $sonarqaciname --image  sonarqube --ports 9000 --dns-name-label $sonarqaciname'dns' --cpu 2 --memory 3.5
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