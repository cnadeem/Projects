# Projects

Project contain two separate solution file which can be hosted on two different servers.
WebAPI demo contain the web api which communicate with sqlserver to get the product list on the GET request.

WebProduct consume the webapi after user is successfully logged in.

WebAPIDemo
1. Execute the Database Script.txt file from the solution in SQL Server Management Studio. This will create the necessary database,tables etc

2. Update the sql server machine name for connectionstring in web.config for key ProductDBEntities.

3. It uses Microsoft default Account membership to generate the tokens and provide the authentication mechanism.

4. Run the project.

WebProduct
This project contain the web interface which consume the WEBAPI services.
1. Update below key with WEB API service url containing the protocol, machine name and port if any in both Unit test and Web Project solutions App.config and Web.config respectivily.
  <add key="WebApiUrl" value="http://localhost:59961/" />

2. Access /Home/Login - to login with existing username password
cnadeem6@gmail.com
P@ssw0rd
else go to register page to create new user. Both consume web api through Ajax

3. After successful login,user will be navigated to 
Home/ViewProduct
Click on Load Product button to call the web api which will list the product information in table.

