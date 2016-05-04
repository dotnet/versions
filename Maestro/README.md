# Maestro

A simple WebAPI service that listens for [GitHub Web Hooks](https://developer.github.com/webhooks/) "Push" requests 
to {rootUrl}/CommitPushed. When invoked, Maestro will inspect the commit that was pushed, and if it
matches any event subscriptions in the "subscriptions.json" file, it kicks off the appropriate action.

## GitHub Web Hooks

Currently, this web service is hooked up to https://github.com/dotnet/versions, which holds current build version
information for various .NET repos in the 'build-info' directory. When build information changes in the 'build-info'
directory, this web service is invoked. More GitHub repos can be added by adding Maestro's 

## Available actions

For now, VSO builds can be triggered by Maestro. The VSO builds can do anything it wants.

There may be more "action" types in the future, if the need presents itself.

## subscriptions.json

This JSON file holds the subscription information of which action to run when a specified file changes. The format
of the file is as follows:

- actions - A list of actions that can be performed in a build definitions that can be referenced in an event handler. Each object can have the
following properties:
 - vsoInstance (required) - The domain name where the VSO tenant is hosted.
 - vsoProject (required) - The project the build defintion is contained in.
 - buildDefinitionId (required) - The integer id of the build defintion 

- subscriptions - The array of subscription objects which reference the file to watch, and the list of actions or "handlers"
to invoke whenever that file is updated. Each subscription object can have the following properties:
 - path (required) - The file that will trigger actions when it is updated.
 - handlers (required) - The array of subscription handler objects that will be triggered when the files changes.
 
 Each subscription handler can have the following properties:
 - maestroAction (required) - The name of the Action object which contains the necessary information to
 queue a new VSO build.
 - Any other properties defined on the handler will be passed as variables to the queued VSO build using
 the name of the property as the name of the variable and the value of the property as the value of the variable.
   - In order to make the json file more readable, Maestro supports the value of the property to be an array of strings that
   get appended together to make up one long variable value string.
