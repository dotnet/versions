## Legacy (2.1 and prior) Build Information

**This information is no longer regularly updated post .NET Core 2.1**

The directory that holds information about the builds that are available for each repo.

### Structure

At the top-level, the directories are organized in the same way GitHub organizes repos. Here is the pattern:

`/build-info/<owner>/<repo>`

ex. `/build-info/dotnet/corefx`

Underneath the `<repo>`, we list the `<channel>` for the build.

#### Channels

At a high-level, a channel is a place to store the outputs of a build. A product defines a set of channels
that it produces outputs for, and then as builds are executed, the build outputs are put into one or more
channels.

Examples of channels using the `dotnet/corefx` repo:

- master
- release/1.0.0
- release/1.0.0-rc2
- release/1.0.1
- etc

Consumers can subscribe to a channel of a repo, and consume the outputs.

It is important to recognize that while channels usually map closely to official branches in a repo, they
are not in a one-to-one relationship. One goal of the channel concept is that consumers of your repo are
agnostic to your underlying branch structure. Normally consumers will want to consume a version "x.y.z"
build outputs, they don't care what branch they come from. And furthermore, the branch they come from often changes,
especially at the end of a release. For example, at one point the `dotnet/corefx` `master` branch was producing
builds for the "1.0.0" release, while the "1.0.0-rc2" release was stabilizing. But then later, when the "1.0.0" release
was stabilizing, a new branch `release/1.0.0` was created and that branch started producing builds for that channel.
Consumers don't want to have to switch channels, just because a repo switched branches.

This reasoning shows why it is possible for a single branch to put its builds into multiple channels. If a consumer
always wanted to track the "latest and greatest" builds from the `dotnet/corefx` repo, they could subscribe to the
`master` channel, and they would always get the newest builds with the latest code and all the bug fixes. However,
there are other consumers that want to strictly get the "current stabilizing release + 1" bits from `dotnet/corefx`,
but not necessarily always from `master`. For example, while "1.0.0-rc2" is stabilizing, I want to consume the "1.0.0"
release bits and continue to consume them even when "1.0.0" branches into a release branch.

#### Build Pointers

Each channel directory contains files about each build it wants to track. This can be referred to as "Build Pointers".
Typical builds that are tracked are:

- Latest
- LKG (or Last Known Good)
- Release (The build that was released from this channel)

But each owner/repo/channel can define builds and build names that make sense for them to track.