# MenuTools

Extended context menu tools
<p>
<img src="https://img.shields.io/github/issues/xCONFLiCTiONx/MenuTools" alt="GitHub release">
<img src="https://img.shields.io/github/forks/xCONFLiCTiONx/MenuTools" alt="GitHub release">
<img src="https://img.shields.io/github/stars/xCONFLiCTiONx/MenuTools" alt="GitHub release">
<img src="https://img.shields.io/github/license/xCONFLiCTiONx/MenuTools" alt="GitHub release">
</p>

## Recent changes:
Open with notepad: Uses the program set as default for opening .txt files.
Added Windows Terminal to list of Command Lines in Directory Background
**For Terminal to open in the currect directory you must set your settings as follows:**
```json
 "profiles":
    {
        "defaults":
        {
            // Put settings here that you want to apply to all profiles.
        },
        "list":
        [
          {
            // Make changes here to the powershell.exe profile.
            "guid": "{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
            "name": "Windows PowerShell",
            "commandline": "powershell.exe",
            "hidden": false,
            "startingDirectory": "."
          },
          {
            // Make changes here to the cmd.exe profile.
            "guid": "{0caa0dad-35be-5f56-a8ff-afceeeaa6101}",
            "name": "Command Prompt",
            "commandline": "cmd.exe",
            "hidden": false,
            "startingDirectory": "."
          },
          {
            "guid": "{b453ae62-4e3d-5e58-b989-0a998ec441b8}",
            "hidden": false,
            "name": "Azure Cloud Shell",
            "source": "Windows.Terminal.Azure"
          }
        ]
    },
```
**Note the `"startingDirectory": "."` which is all that needs to change.**

![ScreenShot1](https://raw.githubusercontent.com/mikeyhalla/MenuTools/master/Screenshot.jpg)

*SharpShell Credits:*
===================  
*Assembly Company: Dave Kerr* | *Assembly Product: SharpShell* | *Assembly Copyright: Copyright © Dave Kerr 2013* | *Assembly Webiste: https://github.com/dwmkerr/sharpshell*
