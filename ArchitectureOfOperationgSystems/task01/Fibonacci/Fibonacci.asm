format PE console
entry start
;----
include "win32a.inc"
;----
section '.rdata' data readable writeable
        ;set console title buffer
        _window_title    db    "Find Fibonacci numbers",0
        ;set a message
        _show_message    db    "Enter a small number for iterations <=32: ",0
 
        ;formatting for text
        _show_shell    db    "[%d]",10,0
        _format_text    db    "%d",0
        _pause    db    "pause",0
 
        ;define first and next value
        _first_value    dd    1
        _next_value    dd    0
 
        ; count to the last value
        _last_value    dd    ?
;----
section '.text' code executable
start:
    ;show console title
    invoke SetConsoleTitle, _window_title
    ;show text console
    invoke printf, _show_message
    ;waiting the count for user
    ;the scanf save this to memory buffer
    invoke scanf, _format_text, _last_value
    ;call math procedure named
    push [_last_value]
    call Fibonacci
    ; use system pause
    invoke system, _pause
    ;normal exit process
    invoke ExitProcess, 0
;----
    proc Fibonacci, limit_value:DWORD
    mov ecx, [limit_value]
    ; point to jump depend rcx 
    for_loop:
    ;use the clean registers
    xor eax, eax
    xor ebx, ebx
 
    ;the math sum for Fibonacci 
    ; eax take _next_value (first is 0)
    mov eax, [_next_value]
    ; sum the _first_value with the value of old eax = _next_value
    add eax, [_first_value]
    ; because the eax need to keep value use :
    ; ebx take _next_value
    mov ebx, [_next_value]
    ; the result of eax is put on _next_value
    mov [_next_value], eax ;_next_value
    ; the result of ebx is put on _first_value
    mov [_first_value], ebx
    ;close loop
 
    ;save value of ecx = ...
    push ecx
    ;print value of _next_value
    invoke printf, _show_shell, [_next_value]
    ; restore the value of ecx = ...
    pop ecx
                
    ;restore value with offset by stack
    ;this allow you to loop the sequence of code eax, ebx with add
    mov ecx, [esp+4]
    ;decrease ecx with -1
    dec ecx
    ;math stop when: if (ecx != 0) jump for_loop
    jnz for_loop
    ;finish the return
    ret
        endp        
;----
section '.idata' data readable import
    ;imports dlls
    library kernel32, 'kernel32.dll',\
            msvcrt, 'msvcrt.dll'
 
    ;imports API
    import kernel32,\
    ExitProcess, 'ExitProcess',\
    SetConsoleTitle, 'SetConsoleTitleA'
 
    ;imports msvcrt.dll
    import msvcrt,\
    printf, 'printf',\
    system, 'system',\
    scanf, 'scanf'