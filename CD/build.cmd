
REM set BOOT=[BOOT]\Boot-NoEmul.img
set LABEL=GBPFRE_EN_DV1

set SOURCE=cdroot
set DEST=Bluepill-GBPFRE_EN_DV1.iso
REM set DATE=1/30/2020,12:33:00
REM  -t%DATE% -b%BOOT%

CDIMAGE.EXE -xx -o -os -m -a -g -j1 -l%LABEL% %SOURCE% %DEST%