# .NET Versions
This repo contains information about the various component versions that ship with .NET Core. 

## build-info
The directory that holds information about the current builds that are available for each repo.

### Structure

The directories are organized in the same way GitHub organizes branches. Here is the pattern:

`/build-info/<owner>/<repo>/<branch>`

ex. `/build-info/dotnet/corefx/master`

Each branch directory contains files about each build it wants to track. Typical builds that are tracked are:
- Latest
- LKG (or Last Known Good)
- Release (The build that was released from this branch)

But each owner/repo/branch can define builds and build names that make sense for them to track. 
Keep in mind that these are public, and consumers will be taking dependencies on these names. You should
consider renaming a build file like you would any other breaking change (it needs plenty of communication). 

### Suggestions

If NuGet packages are being produced by your repo, a suggestion is to list the URL of the myget/nuget feed where
consumers can get those NuGet packages along with the package Ids and Versions. This allows for automation to find
these packages without having to hard-code the feed themselves. 

## Maestro

An application that coordinates between multiple repositories. It has the ability to automate any process
that requires cross-repo communication. For exapmle, when a new LKG build of one repo is avaialble, it can
signal any dependent repos to start using this new build.
 