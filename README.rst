Steam Group Toolkit
=====

About
-----
SteamGroupToolkit is a (small) toolkit to increase the amount of members of your Steam group.
It currently consists out of 2 modules, which can be accessed through tabs.

- Steam Group Harvester (harvests all members from an other Steam group)
- Steam Group Inviter (invite "harvested" members into your group)

It is coded in C# and should run on every platform, Linux/Mac require Mono.


Requirements
-----
- Visual Studio 2010
- NuGet
- A Steam account with Steam Guard enabled for more than 15 days

How to use
-----

1. Clone this repository:
  git clone https://github.com/awillinger/SteamGroupToolkit.git
2. Change into the newly created directory
3. Open the Harvester.sln with Visual Studio
4. Right click top > Configuration Manager > Select "Release" > Ok
5. Right click top > Select Rebuild all
6. Copy over the settings-template.json to settings.json and edit the settings (only 2 currently)
7. Start the program, use is pretty self-explanatory

License
-----
This program is licensed under the GPLv3. You may redistribute this as long as you license it again with the GPLv3.
If you publish it on your website, please leave a link back to this repository.

Support
-----
In case you got any questions, pull requests or bug Rreports, feel free to open a new issue here.
