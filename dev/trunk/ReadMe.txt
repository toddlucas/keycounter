KeyCounter is a tool for the tray-bar that helps you to get statistics about the 
useage of your computers keyboard, mouse and uptime. KeyCounter is NOT (!) intended 
to work as a keylogger, nor is it possible to use it as one without major 
modifications to the source code. Be sure to protect the privacy of all users and 
get their accordance. This program is distributed in the hope that it will be 
useful, but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public 
License for more details.

System requirements:
Windows 2000 SP4 / Windows XP / Windows Server 2003 / Windows Vista
Microsoft .NET Framework 2.0
The binary distributions were compiled using Microsoft Visual C# 2005 Express Edition.

Contact:
If you have any questions, recommendations or comments about KeyCounter, feel free to
send a mail to the development-team: keycounter@gmail.com.

Changelog:

0.10 2007-03-25
-----------------
- options dialog
- balloon tips
- new icons
- improved stability
- many bugfixes

0.9.1 2007-01-15
-----------------
new column for hits per minute in FormDisplay->Per Key
Visual Studio AboutBox replaces FormAbout, THX to UNCLE JAMAL for the nice pic!
some new icons for the tray-bar context-menu (looks cool with the new AboutBox :-)
fixed bug B1 "uptime standby" with a regular uptime-update (timer in FormMain)
note: the slow timer period causes the uptime to increase in steps of 10s; anyhow, the
internal counter precision is not reduced.
basic support for GPLv2

0.9.0 2007-01-08
-----------------
setting "debugModeEnabled" switched to false -> no debug-windows for users
Fixed summary-tab of FormDisplay ("Average key hits per minute since last reset")
FormAbout shows compilation-date and -time (helper program CompileInfo.exe)