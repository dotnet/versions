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

- actions - An object containing actions that can be referenced in an event subscription. Each action object
represents a VSO build definition and can have the following properties:
 - vsoInstance (required) - The domain name where the VSO tenant is hosted.
 - vsoProject (required) - The project the build defintion is contained in.
 - buildDefinitionId (required) - The integer id of the build defintion 

- subscriptions - The array of subscription objects which specify the list of files to watch and the action
to invoke whenever any of the files is updated. Each subscription object can have the following properties:
  - triggerPaths (required) - The array of files for which Maestro will trigger the action when any are updated
  (modified, added, or removed).
  - action (required) - The name of the action object that will be triggered when any of the files changes.
  - delay (optional) - The amount of time to wait before triggering the action.
  - actionArguments (optional) - An object containing properties to be passed to the action. For VSO build actions,
  the following properties are supported:
    - vsoSourceBranch (optional) - The source branch for which to queue the build.
    - vsoBuildParameters (optional) - An object containing properties to be passed as variables to the queued VSO
    build using the name of the property as the name of the variable and the value of the property as the value of
    the variable. In order to make the json file more readable, Maestro supports the value of the property to be
    an array of strings that get appended together to make up one long variable value string.
