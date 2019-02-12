## Product build: cli build 20190117-05-2407083

### .NET Core Runtime Installers and Binaries

| Platform | Build |
|---------|:----------:|
| **Windows (x64)**                         | [Installer][win-x64-installer] ([Checksum][win-x64-installer-checksum]<sup>1</sup>)<br>[zip][win-x64-zip]   ([Checksum][win-x64-zip-checksum]<sup>1</sup>)<br>[Symbols (zip)][win-x64-symbols-zip]   |
| **Windows (x86)**                         | [Installer][win-x86-installer] ([Checksum][win-x86-installer-checksum]<sup>1</sup>)<br>[zip][win-x86-zip]   ([Checksum][win-x86-zip-checksum]<sup>1</sup>)<br>[Symbols (zip)][win-x86-symbols-zip]   |
| **Windows (arm32)**                       |                                                                                        [zip][win-arm-zip]   ([Checksum][win-arm-zip-checksum]<sup>1</sup>)<br>[Symbols (zip)][win-arm-symbols-zip]   |
| **Windows (arm64)**                       |                                                                                        [zip][win-arm64-zip] ([Checksum][win-arm64-zip-checksum]<sup>1</sup>)<br>[Symbols (zip)][win-arm64-symbols-zip] |
| **Mac OS X (x64)**                        | [Installer][osx-installer] ([Checksum][osx-installer-checksum]<sup>1</sup>)<br>[tar.gz][osx-targz]          ([Checksum][osx-targz-checksum]<sup>1</sup>)<br>[Symbols (tar.gz)][osx-symbols-targz]       |
| **Linux (x64)** (for glibc based OS)      |                                                                                        [tar.gz][linux-x64-targz] ([Checksum][linux-x64-targz-checksum]<sup>1</sup>)<br>[Symbols (tar.gz)][linux-x64-symbols-targz] |
| **Linux (armhf)** (for glibc based OS)    |                                                                                        [tar.gz][linux-arm-targz] ([Checksum][linux-arm-targz-checksum]<sup>1</sup>)<br>[Symbols (tar.gz)][linux-arm-symbols-targz] |
| **Linux (arm64)** (for glibc based OS)    |                                                                                        [tar.gz][linux-arm64-targz] ([Checksum][linux-arm64-targz-checksum]<sup>1</sup>)<br>[Symbols (tar.gz)][linux-arm64-symbols-targz] |
| **Ubuntu 14.04 (x64)**                    | [Runtime-Deps][ubuntu-14.04-runtime-deps] ([Checksum][ubuntu-14.04-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Ubuntu 16.04 (x64)**                    | [Runtime-Deps][ubuntu-16.04-runtime-deps] ([Checksum][ubuntu-16.04-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Ubuntu 17.10 (x64)**                    | [Runtime-Deps][ubuntu-17.10-runtime-deps] ([Checksum][ubuntu-17.10-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Ubuntu 18.04 (x64)**                    | [Runtime-Deps][ubuntu-18.04-runtime-deps] ([Checksum][ubuntu-18.04-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Debian 8.2 (x64)**                      | [Runtime-Deps][debian-8.2-runtime-deps]   ([Checksum][debian-8.2-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Debian 9 (x64)**                        | [Runtime-Deps][debian-9-runtime-deps]     ([Checksum][debian-9-runtime-deps-checksum]<sup>1</sup>)<br>[Host][deb-package-host] ([Checksum][deb-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][deb-package-hostfxr] ([Checksum][deb-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][deb-package-sharedfx] ([Checksum][deb-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **CentOS 7.2 (x64)**                      | [Runtime-Deps][centos-7-runtime-deps]      ([Checksum][centos-7-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **RHEL 7.2 (x64)**                        | [Runtime-Deps][rhel-7-runtime-deps]        ([Checksum][rhel-7-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Fedora 26 (x64)**                       | [Runtime-Deps][fedora-26-runtime-deps]     ([Checksum][fedora-26-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Fedora 27 (x64)**                       | [Runtime-Deps][fedora-27-runtime-deps]     ([Checksum][fedora-27-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **OpenSuSE 42.3 (x64)**                   | [Runtime-Deps][opensuse-42-runtime-deps]  ([Checksum][opensuse-42-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **Oracle Linux 7 (x64)**                  | [Runtime-Deps][oraclelinux-7-runtime-deps] ([Checksum][oraclelinux-7-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **SuSE Linux Enterprise Server 12(x64)**  | [Runtime-Deps][sles-12-runtime-deps] ([Checksum][sles-12-runtime-deps-checksum]<sup>1</sup>)<br>[Host][rpm-package-host] ([Checksum][rpm-package-host-checksum]<sup>1</sup>)<br>[Host FX Resolver][rpm-package-hostfxr]       ([Checksum][rpm-package-hostfxr-checksum]<sup>1</sup>)<br>[Shared Framework][rpm-package-sharedfx]       ([Checksum][rpm-package-sharedfx-checksum]<sup>1</sup>)<br> |
| **RHEL 6**                                |                                                                                        [tar.gz][rhel-6-targz]                    ([Checksum][rhel-6-targz-checksum]<sup>1</sup>)|
| **Linux Musl**                            |                                                                                        [tar.gz][musl-x64-targz]                ([Checksum][musl-x64-targz-checksum]<sup>1</sup>)|

[win-x64-installer]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x64.exe
[win-x64-installer-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x64.exe.sha512
[win-x64-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x64.zip
[win-x64-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x64.zip.sha512
[win-x64-symbols-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-win-x64.zip

[win-x86-installer]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x86.exe
[win-x86-installer-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x86.exe.sha512
[win-x86-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x86.zip
[win-x86-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-x86.zip.sha512
[win-x86-symbols-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-win-x86.zip

[win-arm-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-arm.zip
[win-arm-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-arm.zip.sha512
[win-arm-symbols-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-win-arm.zip

[win-arm64-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-win-arm64.zip
[win-arm64-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-win-arm64.zip.sha512
[win-arm64-symbols-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-win-arm64.zip

[osx-installer]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-osx-x64.pkg
[osx-installer-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-osx-x64.pkg.sha512
[osx-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-osx-x64.tar.gz
[osx-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-osx-x64.tar.gz.sha512
[osx-symbols-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-osx-x64.tar.gz

[linux-x64-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-x64.tar.gz
[linux-x64-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-x64.tar.gz.sha512
[linux-x64-symbols-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-linux-x64.tar.gz
[linux-arm-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-arm.tar.gz
[linux-arm-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-arm.tar.gz.sha512
[linux-arm-symbols-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-linux-arm.tar.gz
[linux-arm64-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-arm64.tar.gz
[linux-arm64-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-arm64.tar.gz.sha512
[linux-arm64-symbols-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-symbols-2.2.2-linux-arm64.tar.gz

[ubuntu-14.04-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.14.04-x64.deb
[ubuntu-14.04-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.14.04-x64.deb.sha512

[ubuntu-16.04-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.16.04-x64.deb
[ubuntu-16.04-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.16.04-x64.deb.sha512

[ubuntu-17.10-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.17.10-x64.deb
[ubuntu-17.10-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.17.10-x64.deb.sha512

[ubuntu-18.04-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.18.04-x64.deb
[ubuntu-18.04-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-ubuntu.18.04-x64.deb.sha512

[debian-8.2-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-debian.8-x64.deb
[debian-8.2-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-debian.8-x64.deb.sha512

[debian-9-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-debian.9-x64.deb
[debian-9-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-debian.9-x64.deb.sha512

[centos-7-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-centos.7-x64.rpm
[centos-7-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-centos.7-x64.rpm.sha512

[rhel-7-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-rhel.7-x64.rpm
[rhel-7-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-rhel.7-x64.rpm.sha512

[fedora-26-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-fedora.26-x64.rpm
[fedora-26-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-fedora.26-x64.rpm.sha512

[fedora-27-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-fedora.27-x64.rpm
[fedora-27-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-fedora.27-x64.rpm.sha512

[opensuse-42-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-opensuse.42-x64.rpm
[opensuse-42-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-opensuse.42-x64.rpm.sha512

[oraclelinux-7-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-oraclelinux.7-x64.rpm
[oraclelinux-7-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-oraclelinux.7-x64.rpm.sha512

[sles-12-runtime-deps]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-sles.12-x64.rpm
[sles-12-runtime-deps-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-deps-2.2.2-sles.12-x64.rpm.sha512

[deb-package-host]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-host-2.2.2-x64.deb
[deb-package-host-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-host-2.2.2-x64.deb.sha512
[deb-package-hostfxr]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-hostfxr-2.2.2-x64.deb
[deb-package-hostfxr-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-hostfxr-2.2.2-x64.deb.sha512
[deb-package-sharedfx]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-x64.deb
[deb-package-sharedfx-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-x64.deb.sha512

[rpm-package-host]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-host-2.2.2-x64.rpm
[rpm-package-host-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-host-2.2.2-x64.rpm.sha512
[rpm-package-hostfxr]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-hostfxr-2.2.2-x64.rpm
[rpm-package-hostfxr-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-hostfxr-2.2.2-x64.rpm.sha512
[rpm-package-sharedfx]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-x64.rpm
[rpm-package-sharedfx-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-x64.rpm.sha512

[rhel-6-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-rhel.6-x64.tar.gz
[rhel-6-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-rhel.6-x64.tar.gz.sha512

[musl-x64-targz]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-musl-x64.tar.gz
[musl-x64-targz-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/Runtime/2.2.2/dotnet-runtime-2.2.2-linux-musl-x64.tar.gz.sha512

> **1**: These .NET Core Runtime checksums are generated by the orchestration infrastructure during installer publish. They are only available once that publish step completes: `installers.semaphore`. See [publish.md#checksum-generation](https://github.com/dotnet/core-eng/blob/master/Documentation/Orchestrated-Build/Api/publish.md#checksum-generation).


### Windows Hosting Bundle Installer

Platform              | Build
----------------------|---------------------
Windows               | [Installer (exe)][dotnet-hosting-win-exe] ([Checksum][dotnet-hosting-win-exe-checksum]<sup>1</sup>)

[dotnet-hosting-win-exe]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/dotnet-hosting-2.2.2-win.exe
[dotnet-hosting-win-exe-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/dotnet-hosting-2.2.2-win.exe.sha512


### ASP.NET Core Runtime Installers and Binaries

Platform              | Build
----------------------|---------------------
Windows (x64)         | [Installer (exe)][aspnetcore-win-x64-exe] ([Checksum][aspnetcore-win-x64-exe-checksum]<sup>1</sup>)<br>[Archive (zip)][aspnetcore-win-x64-zip] ([Checksum][aspnetcore-win-x64-zip-checksum]<sup>1</sup>)
Windows (x86)         | [Installer (exe)][aspnetcore-win-x86-exe] ([Checksum][aspnetcore-win-x86-exe-checksum]<sup>1</sup>)<br>[Archive (zip)][aspnetcore-win-x86-zip] ([Checksum][aspnetcore-win-x86-zip-checksum]<sup>1</sup>)
macOS (x64)           | [Archive (tar.gz)][aspnetcore-osx-x64-tar] ([Checksum][aspnetcore-osx-x64-tar-checksum]<sup>1</sup>)
Linux (x64)           | [Archive (tar.gz)][aspnetcore-linux-x64-tar] ([Checksum][aspnetcore-linux-x64-tar-checksum]<sup>1</sup>)
Linux Musl (x64)      | [Archive (tar.gz)][aspnetcore-linux-musl-x64-tar] ([Checksum][aspnetcore-linux-musl-x64-tar-checksum]<sup>1</sup>)
Debian/Ubuntu (x64)   | [Installer (deb)][aspnetcore-debian-x64-deb] ([Checksum][aspnetcore-debian-x64-deb-checksum]<sup>1</sup>)
RedHat/Fedora (x64)   | [Installer (rpm)][aspnetcore-redhat-x64-rpm] ([Checksum][aspnetcore-redhat-x64-rpm-checksum]<sup>1</sup>)

[aspnetcore-win-x64-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x64.zip
[aspnetcore-win-x64-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x64.zip.sha512
[aspnetcore-win-x64-exe]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x64.exe
[aspnetcore-win-x64-exe-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x64.exe.sha512

[aspnetcore-win-x86-zip]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x86.zip
[aspnetcore-win-x86-zip-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x86.zip.sha512
[aspnetcore-win-x86-exe]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x86.exe
[aspnetcore-win-x86-exe-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-win-x86.exe.sha512

[aspnetcore-linux-x64-tar]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-linux-x64.tar.gz
[aspnetcore-linux-x64-tar-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-linux-x64.tar.gz.sha512

[aspnetcore-linux-musl-x64-tar]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-linux-musl-x64.tar.gz
[aspnetcore-linux-musl-x64-tar-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-linux-musl-x64.tar.gz.sha512

[aspnetcore-osx-x64-tar]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-osx-x64.tar.gz
[aspnetcore-osx-x64-tar-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-osx-x64.tar.gz.sha512

[aspnetcore-debian-x64-deb]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-x64.deb
[aspnetcore-debian-x64-deb-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-x64.deb.sha512

[aspnetcore-redhat-x64-rpm]: https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/assets/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-x64.rpm
[aspnetcore-redhat-x64-rpm-checksum]: https://dotnetclichecksums.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.2/aspnetcore-runtime-2.2.2-x64.rpm.sha512

> **1**: These ASP.NET Core Runtime checksums are generated by the orchestration infrastructure during installer publish. They are only available once that publish step completes: `installers.semaphore`. See [publish.md#checksum-generation](https://github.com/dotnet/core-eng/blob/master/Documentation/Orchestrated-Build/Api/publish.md#checksum-generation).


### Isolated NuGet Blob Feed
https://dotnetfeed.blob.core.windows.net/orchestrated-release-2-2/20190117-05/final/index.json

### Built Repositories
 * aspnet 2.2.2 on 'internal/release/2.2' (522705f9a27b99ca4ad261f2e89fe51a77b2338e) build 2.2.2-servicing-10034
 * aspnet-extensions 2.2.2 on 'internal/release/2.2' (9b0bb18b33821f2de291556483ed3c9022219c22) build 2.2.2-servicing-19068-01+pb-20190117-05
 * cli build 20190117-05-2406969
 * cli 2.2.104 on 'release/2.2.1xx' (73f036d4ac69e0c4421ca67727e900df90066d9c) build 2.2.104
 * coreclr on 'release/2.2-MSRC' (24ac8c378b4e96c70c9129098950413945be427d) build 20190117-07
 * corefx on 'release/2.2-MSRC' (67aa312f4461a767cbe61d6fe0b7e1f9aca36717) build 20190118-02
 * core-setup 2.2.2 on 'release/2.2-MSRC' (a4fd7b2c84454bfb3d2992eb04821972f911834b) build 20190118-01
