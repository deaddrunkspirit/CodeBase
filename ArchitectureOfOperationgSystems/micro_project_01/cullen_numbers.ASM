format PE console
entry start

include 'win32a.inc'

;--------------------------------------------------------------------------
section '.data' data readable writable

        strCullenNumberCount   db 'Count of CullenNumbers: %d', 0

        cullenNumber      dd 0
        prevCullen        dd 1
        i                 dd 0
        power             dd 1

;--------------------------------------------------------------------------
section '.code' code readable executable
start:
        jmp CountCullenNumbers
finish:
        call [getch]

        push 0
        call [ExitProcess]

;--------------------------------------------------------------------------
Output:
        ; because we count cullen numbers from i = 0, we adds 1 extra number
        mov eax, [i]
        inc eax
        mov [i], eax
        ; now we do output in console
        push [i]
        push strCullenNumberCount
        call [printf]
        add esp, 8
        jmp finish
;--------------------------------------------------------------------------
CountCullenNumbers:
        ; i++
        mov eax, [i]
        inc eax
        mov [i], eax
        ; increse calculate 2^i
        mov ebx, [power]
        shl ebx, 1
        mov [power], ebx
        ; calculate current cullen number: i*(2^i) + 1
        mul ebx
        add eax, 1
        ; save last cullen number to check if number is greater than double dword
        cmp eax, [prevCullen]
        jl Output
        mov [prevCullen], eax
        jmp CountCullenNumbers
;-------------------------------third act - including HeapApi--------------------------
                                                 
section '.idata' import data readable
    library kernel, 'kernel32.dll',\
            msvcrt, 'msvcrt.dll',\
            user32,'USER32.DLL'

include 'api\user32.inc'
include 'api\kernel32.inc'
    import kernel,\
           ExitProcess, 'ExitProcess',\
           HeapCreate,'HeapCreate',\
           HeapAlloc,'HeapAlloc'
  include 'api\kernel32.inc'
    import msvcrt,\
           printf, 'printf',\
           scanf, 'scanf',\
           getch, '_getch'