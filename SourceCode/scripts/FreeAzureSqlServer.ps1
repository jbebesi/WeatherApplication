$sqlServerName = "wettadev-sql"
$desiredLocation = "westeurope"
$resourceGroup = "WettaDev"
$DatabaseName = "WettaDb"


$userPassword = ConvertTo-SecureString -String "ASDF123dsvh!" -AsPlainText -Force
$sqlAdminCredential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList "testadmin", $userPassword



#$sqlAdminCredential= New-Object -TypeName System.Management.Automation.PsCredential;
#$sqlAdminCredential.UserName("testadmin")
#$sqlAdminCredential.PassWord("ASDF123dsvh$$!")
#$DatabaseName ="wettaSql"
Connect-AzureRmAccount 
 
 $sqlServer = New-AzureRmSqlServer -ServerName $sqlServerName -Location $desiredLocation -ResourceGroupName $resourceGroup -SqlAdministratorCredentials $sqlAdminCredential -ErrorAction Stop -Verbose
    
 New-AzureRmSqlDatabase -DatabaseName $DatabaseName  -ServerName $sqlServer.ServerName -ResourceGroupName $resourceGroup -Edition 'Free' -RequestedServiceObjectiveName 'Free'