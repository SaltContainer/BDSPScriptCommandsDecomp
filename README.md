# BDSPScriptCommandsDecomp

This is a decompilation of the Script Commands used in Pokémon Brilliant Diamond and Shining Pearl's ev_script script language.
This is meant as reference, and will not be executable.
<br><br>
Important to note that this is based on a Ghidra decomp of **Brilliant Diamond 1.1.1**.
<br><br>
What you're most likely gonna be looking at is **RunEvCmd()** in **Dpr/EvScript/EvDataManager.cs**.
<br><br>
Every time a float-typed argument is used, assume that the float conversion is already done and that it is read properly (if it's not explicitely detailed). There is a lot of casting that is skipped over in this decomp to simplify it.
