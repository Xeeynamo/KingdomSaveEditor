![Kingdom Save Editor](docs/banner.png)

---

This is the repository for a Windows application that allows to modify decrypted saves of commercial video games.

If you use Windows 7 SP1 or Windows 8.1, you just need [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-web-installer) to make it work.

| Game                           | Console      | Region |
|--------------------------------| -------------|--------|
| Kingdom Hearts I               | PS2/PS3/PS4  | All    |
| Kingdom Hearts Re: CoM         | PS2/PS4      | All    |
| Kingdom Hearts II              | PS2/PS3/PS4  | US/EU/FM |
| Kingdom Hearts: Birth By Sleep | PSP/PS3/PS4  | FM     |
| Kingdom Hearts: Dream Drop Distance | 3DS     | All    |
| Kingdom Hearts 0.2             | PS4          | All    |
| Kingdom Hearts III             | PS4          | All    |
| Final Fantasy VII Remake       | PS4          | All    |
| Persona 5, Persona 5 Royal     | PS3/PS4      | US/EU  |

[![Download](https://img.shields.io/github/downloads/xeeynamo/kh3saveeditor/total.svg?)](https://github.com/Xeeynamo/KH3SaveEditor/releases)*
![Last commit](https://img.shields.io/github/last-commit/xeeynamo/kh3saveeditor.svg)
![Tests status](https://github.com/xeeynamo/kh3saveeditor/workflows/Tests/badge.svg)

<sub><sup>*download count does not include download from Microsoft Store.</sup></sub>

## Donations

My GitHub is open to a [sponsor program](https://github.com/sponsors/Xeeynamo). If you feel that the editor helped you in some way or you would like to support it, you can consider to [donate me](https://github.com/sponsors/Xeeynamo).

## User guide

You need to decrypt your save before opening it with Kingdom Save Editor. Please refer to [this guide](docs/decryption.md) to know how to decrypt your save.

## Contribution

### Contribute to make it better

This software is **free and open-source**, and every contribution is more than welcome!

If you want to add missing names, improve it or add new offsets, just clone the repository, do your change, test if it does work and create a pull request: we will review your change (no needs to be scared here) and we will merge it to this repo! Do not be shy on contribute, even for the smallest thing 😃

### Issues or feature requests

For every issue or feature request, please refer to [the issue page on GitHub](https://github.com/Xeeynamo/KH3SaveEditor/issues). Be as detailed as possible when creating an issue as it will help me to dig into the problem.

### Build guide

The project is structured into libraries and GUI. Libraries are written in .Net Core and they are cross-platform (eg. Linux and MacOS are supported). Although, the GUI is heavily depentant from Windows and you need Visual Studio 2019 or later.

When you clone this repository, remember to launch the script `setup.bat` if you are on Windows or `setup.sh` if you are on Linux, to set-up the minimum requirements to build the project.

The script `pack.bat` uses WinRAR's self-extracting archive to create a single executable file ready to be distributed.

## License

The code itself, the interface and the codes inside it are protected by GPL 3.0 license, unless specified differently in the root of a specific folder. In short, that means that for every change you made or code that you take from here, you need to make it open source somewhere, adding the original copyright statement and specify where the original code has been taken.

If you have more doubts about the GPL license, have a read to the following links:

[LICENSE info](https://tldrlegal.com/license/gnu-general-public-license-v3-(gpl-3))

[LICENSE Wikipedia](https://simple.wikipedia.org/wiki/GNU_General_Public_License)

## Privacy

The application will have full access to the file you will open by using "File\Open" in order to be able to modify your save game data and it will send the version of the save editor to provide customized messages at the home page to suggest what changes you will find in an eventual new version of this tool.

Few information such as name of the operating system, name of the game you choose to access to and crash reports will be send for diagnostic purpose and to improve the save editing functionalities. By knowing which games are modified the most, I can take knowledge of it and target them to add new editing features. You can also choose to send those reports anonymously. When not anonymous, a cookie will be send which represents a totally random number generated the very first time you open the Save Editor. The code is open source and there is absolute transparency on [which information are sent](KHSave.SaveEditor/Services/ReporterService.cs).
