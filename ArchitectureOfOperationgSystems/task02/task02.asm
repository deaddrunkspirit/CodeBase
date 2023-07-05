; Variant 16
; Get an array from user and create another array
; with elements that are greater than
; average value of the first array.
; Then output in console both arrays
;


format PE console
entry start

include 'win32a.inc'

;--------------------------------------------------------------------------
section '.data' data readable writable

        strVecSize   db 'Input the size of the vector: ', 0
        strIncorSize db 'Incorrect size of vector = %d', 10, 0
        strVecElemI  db 'A[%d]: ', 0
        strScanInt   db '%d', 0
        strAverageValue db 'Average = %d', 10, 0
        strVecElemOut   db '[%d] = %d', 10, 0
        strVecAMes      db 'Vector A:', 10, 0
        strVecBMes      db 'Vector B:', 10, 0
        strSep          db '-----------------------------------', 10, 0

        vec_sizeA    dd 0
        vec_sizeB    dd 0
        sum          dd 0
        average      dd 0
        i            dd ?
        tmp          dd ?
        tmpB         dd ?
        tmpStack     dd ?
        vecA         rd 100
        vecB         rd 100

;--------------------------------------------------------------------------
section '.code' code readable executable
start:
; 1) vector input
        call VectorInput
; 2) get vector average and print it in console
        call VectorAverage
; 3) create vector B
        call VectorCreate
; 4) base vector out
        call Separate
        call VectorAOut
; 5) new vector out
        call Separate
        call VectorBOut
        call Separate
finish:
        call [getch]

        push 0
        call [ExitProcess]

;--------------------------------------------------------------------------
Separate:
        ; printing separation sympols in console to make output more readable
        push strSep
        call [printf]
        add esp, 4
        ret
;--------------------------------------------------------------------------
VectorInput:
; Fills vector A with user's input
        push strVecSize
        call [printf]
        add esp, 4

        push vec_sizeA
        push strScanInt
        call [scanf]
        add esp, 8

        mov eax, [vec_sizeA]
        cmp eax, 0
        jg getVector
        jne invalidInput
        push vec_sizeA
        push strIncorSize
        call [printf]
        push 0
        call [ExitProcess]
invalidInput:
        ; message if size is incorrect
        push eax
        push strIncorSize
        call [printf]
        add esp, 8
        jmp start
        ret
; else continue...
getVector:
        xor ecx, ecx            ; ecx = 0
        mov ebx, vecA            ; ebx = &vec
getVecLoop:
        mov [tmp], ebx
        cmp ecx, [vec_sizeA]
        jge endInputVector       ; to end of loop

        ; input element
        mov [i], ecx
        push ecx
        push strVecElemI
        call [printf]
        add esp, 8

        push ebx
        push strScanInt
        call [scanf]
        add esp, 8

        mov ecx, [i]
        inc ecx
        mov ebx, [tmp]
        add ebx, 4
        jmp getVecLoop
endInputVector:
        ret
;--------------------------------------------------------------------------
VectorAverage:
; Calculates average value among vector elements
        xor ecx, ecx             ; ecx = 0
        mov ebx, vecA            ; ebx = &vec
sumVec:
        cmp ecx, [vec_sizeA]     ; go to the end of the loop if (ecx == vec_sizeA)
        je endAverageVec

        ; add next array element
        mov eax, [sum]
        add eax, [ebx]
        mov [sum], eax
        inc ecx
        add ebx, 4
        jmp sumVec
endAverageVec:
        ; calculte vector average
        ; by dividing the summ of array elements on their count
        mov eax, [sum]
        mov edx, 0
        div [vec_sizeA]
        mov [average], eax
        ; print average in console
        push [average]
        push strAverageValue
        call [printf]
        add esp, 8
        ret
;--------------------------------------------------------------------------
VectorCreate:
        xor ecx, ecx
        mov ebx, vecB
        mov edx, vecA
fillVector:
        mov [tmp], edx
        mov [tmpB], ebx
        mov [i], ecx

        cmp ecx, [vec_sizeA]    ; end of loop  if (ecx == vecc_sizeA)
        je endFill

        add ecx, 1
        mov eax, [edx]

        cmp eax, [average]
        jg addElement
        mov edx, [tmp]
        add edx, 4
        mov ecx, [i]
        inc ecx
        jmp fillVector
addElement:
        inc [vec_sizeB]
        mov ebx, [tmpB]
        mov [ebx], eax
        add ebx, 4
        mov edx, [tmp]
        add edx, 4
        mov ecx, [i]
        inc ecx
        jmp fillVector
endFill:
        ret
;--------------------------------------------------------------------------
VectorBOut:
        ; printing info about vector we are printing
        push strVecBMes
        call [printf]
        add esp, 4

        mov [tmpStack], esp
        xor ecx, ecx             ; ecx = 0
        mov ebx, vecB            ; ebx = &vec
putArrLoop:
        mov [tmp], ebx

        cmp ecx, [vec_sizeB]    ; go to end of the loop if (ecx == vec_sizeB)
        je endOutputVector
        mov [i], ecx

        ; output element
        push dword [ebx]
        push ecx
        push strVecElemOut
        call [printf]
        add esp, 12
        mov ecx, [i]
        inc ecx
        mov ebx, [tmp]
        add ebx, 4
        jmp putArrLoop
endOutputVector:
        mov esp, [tmpStack]
        ret
;--------------------------------------------------------------------------
VectorAOut:
        ; printing info about vector we are printing
        push strVecAMes
        call [printf]
        add esp, 4

        mov [tmpStack], esp
        xor ecx, ecx            ; ecx = 0
        mov ebx, vecA           ; ebx = &vec
putVecLoop:
        mov [tmp], ebx
        cmp ecx, [vec_sizeA]    ; go to the end of the loop if (ecx == vec_sizeA)
        je endOutputArray
        mov [i], ecx

        ; output element
        push dword [ebx]
        push ecx
        push strVecElemOut
        call [printf]
        add esp,12
        mov ecx, [i]
        inc ecx
        mov ebx, [tmp]
        add ebx, 4
        jmp putVecLoop
endOutputArray:
        mov esp, [tmpStack]
        ret
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