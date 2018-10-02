# Avoiding SSL Warning for invalid certificate
##############################################
add-type @"
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    public class TrustAllCertsPolicy : ICertificatePolicy {
        public bool CheckValidationResult(
            ServicePoint srvPoint, X509Certificate certificate,
            WebRequest request, int certificateProblem) {
            return true;
        }
    }
"@
[System.Net.ServicePointManager]::CertificatePolicy = New-Object TrustAllCertsPolicy
##############################################

# Force TLs 1.2
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

$Header =  @{
'Cache-Control'= 'no-cache'
'Content-Type'= 'application/xml'
'Postman-Token'= '645abd85-a5cb-480b-8fa7-192902acb80c'
}

$BodyStart = @'
{
    "Host":"www.google.com",
    "Port":80,
    "Connections":30,
}
'@

Invoke-RestMethod -Uri http://localhost:54985/api/SocketStart -Method Post -Body $BodyStart -ContentType "application/json"

Invoke-RestMethod -Uri http://localhost:54985/api/Socket -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/GetStatus -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/Stop -Method Get -ContentType "application/json"





Invoke-RestMethod -Uri http://localhost:54985/api/Socket -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/Start -Method Post -Body $BodyStart -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/ReconnectSocket -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/Stop -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://localhost:54985/api/Socket/GetNames -Method Get -ContentType "application/json"

Invoke-RestMethod -Uri http://localhost:54985/api/Socket/GetTest -Method Get -ContentType "application/json"

Invoke-RestMethod -Uri http://localhost:54985/api/Socket -Method Get -ContentType "application/json"

Invoke-RestMethod -Uri http://localhost:54985/api/SocketStop -Method Get -ContentType "application/json"



Invoke-RestMethod -Uri http://localhost:54985/api/Session2 -Method Get -ContentType "application/json"



$BodyStart = @'
{
    "Host":"www.google.com",
    "Port":80,
    "Connections":1240,
}
'@



Invoke-RestMethod -Uri http://vwswebapp-snat.azurewebsites.net/api/Socket -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://vwswebapp-snat.azurewebsites.net/api/Socket/Start -Method Post -Body $BodyStart -ContentType "application/json"
Invoke-RestMethod -Uri http://vwswebapp-snat.azurewebsites.net/api/Socket/ReconnectSocket -Method Get -ContentType "application/json"
Invoke-RestMethod -Uri http://vwswebapp-snat.azurewebsites.net/api/Socket/Stop -Method Get -ContentType "application/json"



