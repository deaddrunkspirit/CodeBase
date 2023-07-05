; FREE.ASM 14 February, 2012
;  Based on FREE32.ASM by L R Holliday
;  Based on FREETEST.ASM by Eric Auer
;
; compile:              fasm free.asm
; (fasm is a free open source Assembler: http://flatassembler.net/)
;
; syntax:               FREE [d:] [?]
; d: is the [optional] drive selection (default is current drive)
; ? displays a help message
; 2/22/2011 - added code to calculate and display values after
;  the decimal point for Kbytes and MBytes
; 2/26/2011 - modified code to use EAX:EDX instead of AX:DX
;  to allow full bytes printouts up to 2 TiB.
; 3/08/2011 - corrected issue with floppy disks
; 3/13/2011 - slightly revised format of results
; 8/23/2011 - converted to all 32-bit
; 9/27/2011 - added MByte output
; 9/28/2011-10/2/2011 - minor output format improvements
; 2012-02-14 - Win32/fasm conversion by Jason Hood
; 2012-03-11 - added percentages for allocated & free.
;  (Display works up to 1000 TB; it will crash from 4096 TiB.)
; 2012-10-09 - test tab after program name; add /Q to suppress output;
;  return percentage free (but help is still 0; error becomes -1).
; 2012-11-09 - minor change to output;
;  don't round up the return value;
;  read the locale info for the thousands & decimal separators.

format PE console 4.0

include 'win32ax.inc'

struc dbs [str]                 ; define a string with size
{                               ;  (straight from the manual)
common
  . db str
  .size = $ - .
}

.code

start:
        invoke  SetErrorMode,1 ;SEM_FAILCRITICALERRORS
        invoke  GetStdHandle,STD_OUTPUT_HANDLE
        mov     [hStdOut],eax

        invoke  GetLocaleInfo,400h,15,tsep,1 ;LOCALE_USER_DEFAULT,LOCALE_STHOUSAND
        invoke  GetLocaleInfo,400h,14,dsep,1 ;LOCALE_SDECIMAL

        sub     esp,MAX_PATH
        mov     ebx,esp
        mov     byte [ebx],0
        invoke  GetCurrentDirectory,MAX_PATH,ebx
        mov     al,[ebx]
        mov     [drvnam],al     ; set drive letter

        xor     ebp,ebp         ; drive, A, B ... or 0 for "current"

        invoke  GetCommandLine
        mov     esi,eax         ; command line arguments
        mov     dl,'"'          ; is it `"prog" args'
        lodsb
        cmp     al,dl
        je      prog            ; yes, search for quote
        mov     dl,' '          ; no, search for space
prog:   lodsb
        cmp     al,dl
        je      cline
        cmp     al,9            ; tab? (invalid in file names, so assume end)
        je      cline
        cmp     al,0
        jne     prog
        dec     esi             ; point back to NUL

cline:  mov     ax,[esi]        ; 2 chars at a time
        inc     esi
        cmp     al,0            ; end?
        jz      main
        cmp     al,'?'
        jz      help
        cmp     al,' '          ; ignore space and control characters
        jbe     cline
        cmp     al,'/'          ; test slashes...
        jz      opt
        cmp     al,'-'          ; ...and dashes
        jz      opt
        cmp     ah,':'          ; is the FOLLOWING char a colon?
        jnz     help            ; else there is a syntax error
        cmp     al,'a'          ; is it lower case?
        jb      nlower
        sub     al,'a'-'A'      ; then make it upper case!
nlower: cmp     al,'A'
        jb      help
        cmp     al,'Z'
        ja      help
        inc     esi             ; skip over the already parsed colon!
        mov     [drvnam],al     ; update drive letter
        movzx   ebp,al          ; store drive letter
        jmp     cline

opt:    cmp     ah,'q'
        je      .q
        cmp     ah,'Q'
        jne     help
.q:     mov     [quiet],1
        inc     esi
        jmp     cline

help:   mov     al,[tsep]
        mov     [hsep1],al
        mov     [hsep2],al
        invoke  WriteFile,[hStdOut],helpmsg,helpmsg.size,written,NULL
        invoke  ExitProcess,0


main:   mov     al,[drvnam]     ; fetch selected drive letter
        mov     [drvchr],al     ; put it into our message

        invoke  GetDiskFreeSpace,drvnam,sectors,sector,frecls,totcls
        test    eax,eax
        jz      bug
        invoke  GetDiskFreeSpaceEx,drvnam,dfree,dtotal,dtfree
        test    eax,eax
        jz      bug

        mov     al,[dsep]
        mov     [dsep1],al
        mov     [dsep2],al
        mov     [dsep3],al
        mov     [dsep4],al
        mov     [dsep5],al
        mov     [dsep6],al
        mov     [dsep7],al
        mov     [dsep8],al

        mov     eax,[sector]
        mul     [sectors]       ; calc cluster size
        mov     [cluster],eax   ; save clust_bytes for translation

        mov     eax,dword [dfree]
        mov     edx,dword [dfree+4]
        mov     esi,free
        call    store_num

        mov     eax,dword [dtotal]
        mov     edx,dword [dtotal+4]
        mov     esi,total
        call    store_num

; determine allocated bytes by difference

;calcdiff:
        mov     eax,dword [dtotal]      ; calculate difference between
        mov     edx,dword [dtotal+4]    ; total sectors and sectors allocated
        sub     eax,dword [dfree]
        sbb     edx,dword [dfree+4]
        mov     esi,diff
        call    store_num

        fild    [dfree]         ; determine the percentage free
        fild    [dtotal]
        fdivp
        fmul    [f100]          ; multiply by 100 to get percentage
        fist    [rc]            ; that's what we exit with
        fstsw   ax              ; did it round up?
        test    ah,2            ; C1
        jz      .ok
        dec     [rc]            ; yes, remove it to truncate
.ok:    cmp     [quiet],0
        jne     done
        fmul    [f100]          ; multiply by 100 again to get two decimals
        fistp   [dfreepc]
        mov     eax,[dfreepc]
        mov     esi,freepc+6
        call    store_pc

        mov     eax,10000       ; subtract free% from 10,000 to
        sub     eax,[dfreepc]   ;  get used%
        mov     esi,diffpc+6
        call    store_pc

        mov     eax,[sectors]   ; retrieve sectors/cluster
        xor     edx,edx
        mov     edi,sectorsa+3  ; storage for printout
        call    TRANSLATE

        mov     eax,[cluster]   ; retrieve bytes/cluster
        xor     edx,edx
        mov     edi,clustera+9  ; storage for printout
        call    TRANSLATE

        invoke  WriteFile,[hStdOut],crlf,crlf.size,written,NULL
done:   invoke  ExitProcess,[rc]

bug:                            ; problems encountered (e.g. no such FAT drive)
        cmp     [quiet],0
        jne     .exit
        invoke  WriteFile,[hStdOut],nomsg,nomsg.size,written,NULL
.exit:  invoke  ExitProcess,-1  ; return -1 (error)


store_num:
        lea    edi,[esi+18]     ; storage for ascii printout
        call   TRANSLATE

        push   eax              ; save bytes
        push   edx

        call   div1024e         ; convert to Kbytes

        lea    edi,[esi+19+16]  ; storage for ascii printout
        call   TRANSLATE

        lea    edi,[esi+19+17+3]
        call   get_dots

        pop    edx              ; recall bytes
        pop    eax

        lea    edi,[esi+19+17+4+11+2] ; storage for tenths & thousandths
        call   div1024sq        ; calculate occupied MBytes

        lea    edi,[esi+19+17+4+10] ; storage for ascii printout
        call   TRANSLATE

        lea    edi,[esi+19+17+4+11+3]
        call   get_dots1

        ret


div1024e:
        mov     ebx,eax         ; divide by 1,024 (DIV overflows at 4TiB)
        and     ebx,1023        ; stripping the high bits gives us the remainder
        mov     [remain32],ebx
        shrd    eax,edx,10      ; shift to divide
        shr     edx,10
        ret

div1024sq:
        mov     ebx,1048576     ; divide bytes by 1,048,576
        div     ebx
        cmp     edx,1048052     ; this equates to 0.9995
        jb      .rem
        xor     edx,edx         ; round up to zero,
        inc     eax             ; bumping the quotient
        mov     word [edi],'00' ; ".0" for no remainder, ".000" if rounded up
.rem:
        mov     [remain32],edx  ; save remainder
        xor     edx,edx         ; clear remainder from EDX
        ret


get_dots:                       ; convert remainder to ASCII
        std
        mov     eax,[remain32]
        test    eax,eax         ; is it zero?
        jnz     chk512          ; if not, goto chk512
        cmp     [sectors],1     ; is it 1 sector/cluster?
        jz      no_dot          ; if eax is zero, but 1 sector/cluster, goto no_dot
        sub     edi,2           ; else if zero, but not 1 sector/cluster
        mov     al," "          ;  then blank ".0"
        stosb
        stosb
        jmp     no_dot          ; and skip all the rest

chk512:
        cmp     eax,512         ; special case
        jnz     nextdot

        mov     byte [edi-2],"5" ; replace "0" with "5"
        jmp     no_dot

nextdot:
        xor     edx,edx
        imul    eax,1000        ; multiply remainder by 1,000
        mov     ebx,1024        ; divide by 1,024
        div     ebx
        cmp     edx,512         ; remainder < 512?
        jb      no_round
        inc     eax             ; round up if edx = 512 or more
no_round:
        xor     edx,edx

        call    TRANSLATE       ; convert to decimal ASCII

no_dot:
        cld
        ret


get_dots1:                      ; convert remainder to ASCII
        std
        mov     eax,[remain32]
        test    eax,eax         ; is it zero?
        jz      no_dot1         ; if so, skip all the rest

        cmp     eax,524288      ; exactly half?
        jne     .rem
        mov     byte [edi-2],'5'
        jmp     no_dot1

.rem:
        xor     edx,edx
        imul    eax,1000        ; multiply remainder by 1,000

; then divide by 1,048,576 (1,024^2)
        mov     ebx,1048576     ; divide by 1,048,576
        div     ebx
        cmp     edx,524288      ; remainder < 524,288? (1/2 of divisor)
        jb      no_round1
        inc     eax             ; round up if edx = 524,288 or more

no_round1:
        xor     edx,edx

        call    TRANSLATE       ; convert to decimal ASCII
        cmp     eax,9           ; is it more than 9?
        ja      no_dot1         ; if so, skip
        mov     byte [edi],'0'

no_dot1:
        cld
        ret


store_pc:                       ; convert a "percentage" to ASCII
        mov     ebx,100         ; the percentage is multiplied by 100 to
        xor     edx,edx         ; provide two decimal places
        div     ebx
        push    edx
        xor     edx,edx
        mov     edi,esi
        call    TRANSLATE
        pop     eax
        lea     edi,[esi+3]
        ;call   TRANSLATE
        ;ret


TRANSLATE:
        std
        push    eax             ; save EAX and EDX for kbyte conversion
        push    edx
        XCHG    EAX,EDX
        MOV     EBX,10          ; Convert to decimal
        PUSH    EBP             ; Use BP for temporary storage
        XOR     ECX,ECX         ; Zero CL counter

NEXT_COUNT:
        CMP     CL,3            ; is it 3?
        JNZ     NO_COMMA        ; if not, go to NO_COMMA
        mov     cl,[tsep]
        MOV     byte [edi],cl   ; put comma
        dec     edi
        XOR     CL,CL           ; and clear counter

NO_COMMA:
        MOV     EBP,EDX         ; save current DX value in BP
        XOR     EDX,EDX         ; clear DX
        DIV     EBX             ; divide by 10
        XCHG    EAX,EBP         ; recall current DX value from BP
                                ; and save current AX value in BP
        DIV     EBX             ; divide by 10
        XCHG    EAX,EDX
        ADD     AL,'0'          ; Convert to ASCII
        STOSB                   ; store result
        INC     CL              ; increment counter
        MOV     EAX,EBP         ; recall current AX value from BP
        OR      EBP,EDX         ; are we done?
        JNZ     NEXT_COUNT      ; If not, continue

        POP     EBP
        pop     edx             ; recall EAX and EDX
        pop     eax
        cld
        RET

.data

hStdOut dd 0
written dd 0

sectors dd 0                    ; sectors/cluster
sector  dd 0                    ; sector size
cluster dd 0                    ; bytes/cluster
frecls  dd 0                    ; free clusters
totcls  dd 0                    ; total clusters

remain32 dd 0

dfree   dq 0                    ; space to store hex free space results
dtotal  dq 0                    ; also total space
dtfree  dq 0                    ; total free bytes

f100    dd 100.0
dfreepc dd 0                    ; free bytes as a "percentage"
rc      dd 0                    ; return code
quiet   dd 0                    ; no output
tsep    db ','                  ; thousands separator
dsep    db '.'                  ; decimal separator

nomsg   dbs "Cannot determine free space.",13,10

helpmsg db  13,10,"Free disk space checker by L R Holliday 10/2/2011 & Jason Hood 2012-11-09",13,10
        db  13,10
        db  "Usage:",13,10
        db  "  FREE [X:] [/Q] [?]",13,10
        db  "Drive spec is optional, default is the current drive.",13,10
        db  "/Q prevents output, to just return the free percentage.",13,10
        db  13,10
        db  "Example: FREE C:",13,10,13,10
        db  "Note: KiBytes = Bytes/1"
hsep1   db  ",024; MiBytes = KiBytes/1"
hsep2   db  ",024",13,10
helpmsg.size = $ - helpmsg


drvnam  db "?:\",0

crlf    db 13,10
drvmsg  db "Drive "
drvchr  db "?:"
        db "             Bytes"
        db "              KiBytes"
        db "           MiBytes"
        db "       Percent",13,10
        db "               ออออออออออออออออออ"
        db "   ออออออออออออออออ"
        db "   ออออออออออออออ"
        db "   อออออออ"
        db 13,10,"Total Space: "
total:  times 19 db " "         ; 19 spaces for ASCII results
        times 17 db " "         ; 17 spaces for ASCII results
dsep1   db ".0  "
        times 11 db " "         ; 11 spaces for ASCII results
dsep2   db ".0  "

        db 13,10," Used Space: "
diff:   times 19 db " "
        times 17 db " "
dsep3   db ".0  "
        times 11 db " "
dsep4   db ".0  "
diffpc: times 7 db " "
dsep5   db ".00"

        db 13,10," Free Space: "
free:   times 19 db " "
        times 17 db " "
dsep6   db ".0  "
        times 11 db " "
dsep7   db ".0  "
freepc: times 7 db " "
dsep8   db ".00"
        db 13,10,13,10

sectorsa db "     Sectors/Cluster"
clustera db "           Bytes/Cluster",13,10
crlf.size = $ - crlf

.end start