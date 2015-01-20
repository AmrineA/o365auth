# o365auth
.NET class library to handle Office365 authentication with ADFS integrated authentication or MS online username/password.

This was adapted from the project here: https://github.com/jwillmer/SharePointAuthentication

The o365auth project does not have any silverlight or windows 8 dependencies

O365Auth project contains classes for doing the authentication and receiving the CookieCollection required for subsequent O365 reuests.

O365Auth.Console project contains a console application you may use to to run the O365Auth code.

Sample: O365Auth.Console.exe https://MySharePointURL username password false

Parameters:
1 - the URL of your SharePoint site
2 - the usersname.  If you are using ADFS federated authentication this must inclue "@YourDomain"
3 - the password.  If you are using integrated authentication, this paramter is not used
4 - integrated authentication.  If true, then this will attempt to authenticate the user currently in context, not based on usersname/password combination. (username is still required to determine where to authenticate)

Collaborators: 
 - Adam Amrine
 - Josh Knack

