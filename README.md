AngularJSCORS
=============

Example of Angular JS SPA using ADAL.JS for calling a secure, Azure Active Directory authenticated ASP.Net Web API

<h2>What is this:</h2><br />
This project contains two Visual Studio Soluitions:<br /><br />
<b>WebAPISPAClient:</b> An Angular JS Single Page Application project that uses ADAL.js in order to authenticate against Azure Active Directory.<br /><br />
<b>CorsEnabled3:</b> A Asp.Net Web API project that requires an access token from Azure Active Directory, having enabled CORS for the client project to be able to make calls to it.<br /><br />
<h2>How do I make this work for me?</h2><br />

<b>Step 1: Setup Azure AD</b> <br /><br />
Go to your Azure subscription, Azure Active Directory, and create two <b>web</b> applications (Not native clients. Both these apps are web apps, but from the OAuth perspective, one calls another, that's all).<br />
The first app is the client and the second is the server (give them names that won't confuse you later)

<b>Step 2: Change the manifest of the server application</b> <br /><br />
Go to the server application on Azure AD and download the manifest. Replace the oauth2permissions part with the sample below (<b>remember to use the class ID from the client application you created</b>)<br />

  &quot;oauth2Permissions&quot;: [<br />
    {<br />
      &quot;adminConsentDescription&quot;: &quot;Allow the application full access to the service on behalf of the signed-in user&quot;,<br />
      &quot;adminConsentDisplayName&quot;: &quot;Have full access to the service&quot;,<br />
      &quot;id&quot;: &quot;69a9f159-0771-4d0e-a1c9-25a343b5cd0c&quot;,<br />
      &quot;isEnabled&quot;: true,<br />
      &quot;origin&quot;: &quot;Application&quot;,<br />
      &quot;type&quot;: &quot;User&quot;,<br />
      &quot;userConsentDescription&quot;: &quot;Allow the application full access to the service on your behalf&quot;,<br />
      &quot;userConsentDisplayName&quot;: &quot;Have full access to the service&quot;,<br />
      &quot;value&quot;: &quot;user_impersonation&quot;<br />
    }<br />
  ]<br />
<br />

Upload the manifest back.

<b>Step 3: Update the client app permissions</b> <br /><br />
Go to the client app settings on Azure AD and in the permissions area, add the server app you just configured (that's why you did step 2, so it will show up).

<b>Step 4: Enable implicit flow for the client app</b> <br /><br />
Still at the client app settings on Azure AD, download the app manifest and update the oauth2AllowImplicitFlow property to true. This is not surfaced in the portal UI so has to be done via the manifest as well. Upload the manifest back to the application at the portal.

<b>Step 5: Update client ID and URLs</b> <br /><br />
On both the client and the server, update the client IDs and URLs so they match your client IDs and URLs. There are //TODO comments at the points that need changes.

<b>Step 6: Upload the client and server to separate azure websites</b> <br /><br />
After uploading them, make sure the URLs match what you have in the files (always use HTTPS for the URLs).

<b>Step 7: Set endpoints on ADAL.js initialization</b> <br /><br />
For every resource you access, you need a different access token. Turns out ADAL.js does that for you. Look at the app.js and how it sets an array of endpoints so ADAL knows these will require access tokens and handle that for you.


<b>This you should NOT do:</b> <br /><br />
1-There are many ways you can enable CORS on Web API, from manually adding the headers on web.config to use OWIN cors Nuget or even the Web API one. Pick one, but only one. If you enable it in multiple ways, multiple repeated headers will be generated and it will break JavaScript.<br /><br />
2-Azure Websites have now a new option in the portal in the configuration tab named "authentication/authorization" with a button saying "configure". <b>DON'T ENABLE THIS</b>. It will force all requests to be authenticated and the problem with CORS is that all the preflight requests (method=OPTIONS) will also be redirected to logon which will never work.<br /><br />
3-Don't trust the browser. Clear all cache between attempts or you will never know if your code is working.<br /><br />
4-Don't use "*" in the allowed origins. Be specific about the URLs. Don't ever end an allowed origin URL with "/"<br /><br />
5-The current version of ADAL is blended into Angular JS. Don't fight it. Use Angular and setup the routes accordingly.<br /><br />



