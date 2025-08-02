Objectively Amazing Program is a refactor of an old BASIC maze-generation program, the original code of which can be found here: https://www.atariarchives.org/basicgames/showpage.php?page=3 (scan) and http://www.vintage-basic.net/bcg/amazing.bas (text).

The first thing to note about the original code is that it is the textbook definition of spaghetti code. For example, note that the only way to hit 660 is from a jump (e.g., line 630), but there's no reason to jump to 660 since it's a simple GOTO statement:

630 IF W(R,S+1)<>0 THEN 660
640 X=INT(RND(1)*2+1)
650 ON X GOTO 820,910
660 GOTO 820

Within this mess was a bug that I only discovered in the process of refactoring.

Speaking of my process, I won't get into details, but here's how it went. I did the inital refactor into structured Visual Basic code several years ago. More recently, I decided that this might be a useful tool to include in games made in Unity (which I'm testing the waters). Unity uses C#, so I refactored the Visual Basic code into object-oriented C# (hence the new name of the program). I have also written numerous unit tests for the code, with some help from GitHub Copilot.

This program compiles and correctly generates mazes (or else informs the user of any problems). I am not aware of any bugs. However, I still consider this a work in progress, in the sense that I have a few unit tests remaining to write, some cleanup to do with the existing tests, and perhaps the occasional polish to the existing code. I am also looking at cleaning up the file/folder names, which reflect the original name of the program.
