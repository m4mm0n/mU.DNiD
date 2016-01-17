DNiD [modified by mammon] README:
---------------------------------
Basically the exact same tool as Rue once wrote, however;
his tool was outdated on many things such as no way to add
new signatures and so forth :(

So here is a new, modified version of his amazing tool with
a new twist; it now has the ability to load external databases
without much fuzz to it - it also includes a brand new byte-search
engine which allows true wildcard searches ;)

Included is a sample-database, from which you can see how you
can add new signatures ;)

Also, the design is written to resemble PEiD as much as possible of
one simple reason; simplicity of the mind, thus only the theme is
basically the difference between DNiD and PEiD ;)


TODO:
+Add complete x64 & x86 plugin support... (not PEiD ones, or native ones...)
+Add possibility of using different pattern-finder engines... (thx mr.eXodia for the idea)
+Add a simple disassembly-view window...
+Add a simple hex-view window...
+Add a simple error-handler window/control...
+++Got suggestions? Good, send them to me!+++



VERSION

[2016/01/17] - 2.0.2.0: (by mammon)
=======================
+Added complete PEiD plugin(s) support... (this is a bit buggy!)
*Fixed "Open File" issue... (thx Apuromafo)
*Changed the binary-search algorithm to now be
 part of main-assembly... (less size!)
*Changed alot of the "foreach" loops with "Parallel"'s, instead...

[2016/01/14] - 2.0.1.0: (by mammon)
=======================
!!FIRST PUBLIC VERSION!!
*Changed search-engine algorithm to use multi-CPU,
 which makes it waaaaay faster...

[2016/01/12] - 2.0.0.0: (by mammon)
=======================
*Re-coded from scratch by mammon...
+Added new search-engine... (faster...)
+Re-added external signature support...
+Added signature:
-> ConfuserEx

[2011/07/08] - 1.0: (by Rue)
=======================
+Added an icon...
-Removed external signature support...
+Added Multi-Scan form...
+Added Error reporting...
+Implimented shell extensions...
*Eazfuscator false-positive on CryptoObfuscator should be gone...
*You can now rescan dragged files...
+Added "Rescan" context item to signature textbox...
+Added signatures:
-> Yano v1.X
-> Maxtocode v3.X
-> Maxtocode v3.X Runtime
-> SmartAssembly v6.X
-> Codewall v4.X Evaluation
-> Codewall v4.X
-> ReNET-Pack
-> PECompact .NET v2.0 - v3.X (fixed)

[2011/01/08] - 0.12B: (by Rue)
=======================
-Removed broken ElecKey signature...

[2011/01/08] - 0.12A: (by Rue)
=======================
*Improved scan time with native C dll and added scan time section...
+Added signatures:
-> DotNet Reactor v3.X [Native]
-> Adept Protector v1.X
-> Adept Protector v2.1
-> Sixxpack v2.2
-> Sixxpack v2.4
-> Crypto Obfuscator For .Net v5.X
-> ElecKey [AnyCPU] (thanks High6)

[2010/12/30] - 0.10A: (by Rue)
=======================
*First public release...

(c)2010-2016 Rue, and mammon