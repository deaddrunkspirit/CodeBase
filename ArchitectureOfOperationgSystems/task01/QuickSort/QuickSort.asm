format PE console 4.0
entry start
include 'win32a.inc'

section '.data' data readable writeable
result1 db 'Result 1: %d:',0
result2 db 'Result 2: %d:',0
buffer rb 255

align 16
RandomSeed dd 1318699, 1015727, 1235239, 412943

paramA dd 0
paramB dd 0
align 8
dVal dq 4294967295.0

fmtr db 'test: %d',0
tmp dq 0
align 16
fixer dw 0fc01h,0,0,0,0,0,0,0

fmtf db '%d . %d',0
dbgt dq 0

fmth db '%x %x %x',0
str1 dd 0,0,0,0
fhex db '%x  > %x  ',0

ttest db '%x : %x : %x',10,13,0

align 16
sseseed dq 1111111111111111h
        dq 12134567778abbf0h
        dq 0ababcabababdabah
        dq 7654321546174353h
_fmth db ' %X ',0

RandomArray dd 0
TestArray dd 1000BBBBh, 99AABBCCh, 1000BBB1h, 100h, 250h
section '.code' code readable executable
start:

call MakeSeed
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        push    40000000 ;;40million bytes 10million DWORDS
        call    MakeArray
        mov     [RandomArray], eax
        push    10000000 ;;DWORD size
        push    eax ;;ARRAY MEM
        call    FillArray



;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        call    [GetCurrentProcess] ;returns -1
        push    100h
        push    eax
        call    [SetPriorityClass]
        call    [GetCurrentThread];;returns -2
        push    15
        push    eax
        call    [SetThreadPriority]

    push 0
    push 0
    push 0
    push 0
    call [MessageBox]
;---------------------------------------
    mov esi,01h
    call [GetTickCount]
    mov edi,eax
    jmp tst1
align 16
tst1:
        push    10000000
        push    dword[RandomArray]
        call    RadixSortUint32
    dec esi
    jnz tst1
    push eax
    push _fmth
    call [printf]
    call [GetTickCount]
    sub eax,edi
    push eax
    push result1
    call [printf]

    mov esi,01h
    call [GetTickCount]
    mov edi,eax
    jmp tst2
align 16
tst2:
        push    10000
        push    dword[RandomArray]
        call    RadixSortUint32
    dec esi
    jnz tst2
    push eax
    push _fmth
    call [printf]
    call [GetTickCount]
    sub eax,edi
    push eax
    push result2
    call [printf]
;+++++++++++++++++++++++++++++++++++++++++++++
     push 0
     push buffer
     push buffer
     push 0
     call [MessageBox]
     push 0
     call [ExitProcess]


;;IN size
;;IN array addr
RadixSortUint32:
     mov ecx,[esp+8];;size DWORDs
     push ebp
     push ebx
     push esi
     push edi
     mov esi,[esp+20];;array
     mov ebp,ecx ;;copy sizeDWORDs
     shl ecx,2;;*4 sizeBYTEs
     push ecx ;;size
     call MakeArray
     mov edx,ebp ;;copy back dword size
     mov edi,eax ;;shadow array
     sub esp,256 * 4 ;;count array
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;ITERATION 1
;;;;;;;;;;;;;;;;;;;;zero count array
     xor eax,eax
     mov ecx,255
  .lpc1:
     mov dword[esp+ecx*4],eax
     mov dword[esp+ecx*4-4],eax
     mov dword[esp+ecx*4-8],eax
     mov dword[esp+ecx*4-12],eax
     mov dword[esp+ecx*4-16],eax
     sub ecx,5
     jnz .lpc1
     mov dword[esp],eax
;++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;get counts
     mov ecx,edx ;;dword size -1
     dec ecx
  .lpg1:
     movzx eax,byte[esi+ecx*4] ;;lowest byte first
     inc dword[esp+eax*4]
     dec ecx
     jns .lpg1

;++++++++++++++++++++++++++++
;;;;;change counts to indexes into shadow array
     xor ecx,ecx
     xor ebx,ebx
  .lpm1:
     mov eax, dword[esp+ecx*4]
     mov dword[esp+ecx*4], ebx
     add ebx, eax
     add ecx,1
     cmp ecx,256
     jne .lpm1
;++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;; first copy
     xor ecx,ecx
  .lpr1:
     movzx eax, byte[esi+ecx*4] ;; first byte
     mov ebx, dword[esp+eax*4]
     inc dword[esp+eax*4] ;++
     mov eax, dword[esi+ecx*4]
     mov dword[edi+ebx*4], eax
     add ecx,1
     cmp ecx,edx
     jne .lpr1
;+++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;; flip shadow and array ptrs
     push esi
     push edi
     pop esi
     pop edi
;++++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;ITERATION 2
;;;;;;;;;;;;;;;;;;;;zero count array
     xor eax,eax
     mov ecx,255
  .lpc2:
     mov dword[esp+ecx*4],eax
     mov dword[esp+ecx*4-4],eax
     mov dword[esp+ecx*4-8],eax
     mov dword[esp+ecx*4-12],eax
     mov dword[esp+ecx*4-16],eax
     sub ecx,5
     jnz .lpc2
     mov dword[esp],eax
;++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;get counts
     mov ecx,edx ;;dword size -1
     dec ecx
  .lpg2:
     movzx eax,byte[esi+ecx*4+1] ;;2nd lowest byte
     inc dword[esp+eax*4]
     sub ecx,1
     jns .lpg2
;++++++++++++++++++++++++++++
;;;;;change counts to indexes into shadow array
     xor ecx,ecx
     xor ebx,ebx
  .lpm2:
     mov eax, dword[esp+ecx*4]
     mov dword[esp+ecx*4], ebx
     add ebx, eax
     add ecx,1
     cmp ecx,256
     jne .lpm2
;++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;; second copy
     xor ecx,ecx
  .lpr2:
     movzx eax, byte[esi+ecx*4+1] ;; second byte
     mov ebx, dword[esp+eax*4]
     inc dword[esp+eax*4] ;++
     mov eax, dword[esi+ecx*4]
     mov dword[edi+ebx*4], eax
     add ecx,1
     cmp ecx,edx
     jne .lpr2
;+++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;; flip shadow and array ptrs
     push esi
     push edi
     pop esi
     pop edi
;++++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;ITERATION 3
;;;;;;;;;;;;;;;;;;;;zero count array
     xor eax,eax
     mov ecx,255
  .lpc3:
     mov dword[esp+ecx*4],eax
     mov dword[esp+ecx*4-4],eax
     mov dword[esp+ecx*4-8],eax
     mov dword[esp+ecx*4-12],eax
     mov dword[esp+ecx*4-16],eax
     sub ecx,5
     jnz .lpc3
     mov dword[esp],eax
;++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;get counts
     mov ecx,edx ;;dword size -1
     dec ecx
  .lpg3:
     movzx eax,byte[esi+ecx*4+2] ;;third lowest byte
     inc dword[esp+eax*4]
     sub ecx,1
     jns .lpg3
;++++++++++++++++++++++++++++
;;;;;change counts to indexes into shadow array
     xor ecx,ecx
     xor ebx,ebx
  .lpm3:
     mov eax, dword[esp+ecx*4]
     mov dword[esp+ecx*4], ebx
     add ebx, eax
     add ecx,1
     cmp ecx,256
     jne .lpm3
;++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;; third copy
     xor ecx,ecx
  .lpr3:
     movzx eax, byte[esi+ecx*4+2] ;; third byte
     mov ebx, dword[esp+eax*4]
     inc dword[esp+eax*4] ;++
     mov eax, dword[esi+ecx*4]
     mov dword[edi+ebx*4], eax
     add ecx,1
     cmp ecx,edx
     jne .lpr3
;+++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;; flip shadow and array ptrs
     push esi
     push edi
     pop esi
     pop edi
;++++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;ITERATION 4
;;;;;;;;;;;;;;;;;;;;zero count array
     xor eax,eax
     mov ecx,255
  .lpc4:
     mov dword[esp+ecx*4],eax
     mov dword[esp+ecx*4-4],eax
     mov dword[esp+ecx*4-8],eax
     mov dword[esp+ecx*4-12],eax
     mov dword[esp+ecx*4-16],eax
     sub ecx,5
     jnz .lpc4
     mov dword[esp],eax
;++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;get counts
     mov ecx,edx ;;dword size -1
     dec ecx
  .lpg4:
     movzx eax,byte[esi+ecx*4+3] ;;last byte
     inc dword[esp+eax*4]
     sub ecx,1
     jns .lpg4
;++++++++++++++++++++++++++++
;;;;;change counts to indexes into shadow array
     xor ecx,ecx
     xor ebx,ebx
  .lpm4:
     mov eax, dword[esp+ecx*4]
     mov dword[esp+ecx*4], ebx
     add ebx, eax
     add ecx,1
     cmp ecx,256
     jne .lpm4
;++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;;;;;;;; fourth copy
     xor ecx,ecx
  .lpr4:
     movzx eax, byte[esi+ecx*4+3] ;; fourth byte
     mov ebx, dword[esp+eax*4]
     inc dword[esp+eax*4] ;++
     mov eax, dword[esi+ecx*4]
     mov dword[edi+ebx*4], eax
     add ecx,1
     cmp ecx,edx
     jne .lpr4
;+++++++++++++++++++++++++++++++++++
;;;;;;;;;;;;;;;; flip shadow and array ptrs
     push esi
     push edi
     pop esi
     pop edi
;++++++++++++++++++++++++++++++++++++
     push edi
     call DeleteArray
     add esp,256*4
     pop edi
     pop esi
     pop ebx
     pop ebp
     ret 8


FillArray:
     push ebx
     push esi
     mov ebx,dword[esp+16] ;; count
     mov esi,dword[esp+12] ;; addr
  .lp:
     dec ebx
     js .end
     call Random32
     mov dword[esi+ebx],eax
     jmp .lp
 .end:
     pop esi
     pop ebx
     ret 8

MakeArray:
     mov eax,[esp+4]
     push 4 ;read/write
     push 1000h Or 2000h ;;commit | reserve
     push eax ;;size
     push 0  ;;addr
     push -1 ;;current process
     call [VirtualAllocEx]
     test eax,eax
     jnz .good
     push 0
     call [ExitProcess]
 .good:
     ret 4

DeleteArray:
     mov eax,[esp+4] ;;array addr
     push 8000h ;;release
     push 0 ;;size
     push eax ;;addr
     push -1 ;;this process
     call [VirtualFreeEx]
     ret 4

Random32:
     push ebx
     mov eax,[RandomSeed]
     mov ebx,[RandomSeed+4]
     mov ecx,[RandomSeed+8]
     mov edx,[RandomSeed+12]
     shld ebx,eax,1
     adc eax,0
     ror eax,3
     bswap eax
     shld edx,ecx,1
     adc ecx,0
     bswap ecx
     ror ecx,7
     mov [RandomSeed],eax
     mov [RandomSeed+4],ebx
     mov [RandomSeed+8],ecx
     mov [RandomSeed+12],edx
   xor eax,ecx
     pop ebx
     ret 0

SetSeed:
.seed equ esp+4 ;,+8,+12,+16
     movdqu xmm0,[.seed]
     movntdq dqword[RandomSeed],xmm0
     ret 16

MakeSeed:
     rdtsc
     mov edx,eax
     call [GetTickCount]
     mov ecx,eax
     mul edx
     mov [RandomSeed],eax
     xor edx,ecx
     mov [RandomSeed+4],edx
     bswap ecx
     xor eax,ecx
     mov [RandomSeed+8],eax
     not edx
     bswap edx
     mul edx
     mov [RandomSeed+12],eax
     ret 0



section '.idata' import data readable writeable

  library kernel32,'KERNEL32.DLL',\
          user32,'USER32.DLL',\
          wsock32,'WS2_32.DLL',\
          ntdll,'NTDLL.DLL',\
          msvcrt,'msvcrt.dll'
      include  "api\kernel32.inc"
      include  "api\user32.inc"
      include  "api\wsock32.inc"
      import ntdll,\
        NtAllocateVirtualMemory,'NtAllocateVirtualMemory',\
        NtFreeVirtualMemory,'NtFreeVirtualMemory',\
        NtWriteVirtualMemory,'NtWriteVirtualMemory',\
        NtProtectVirtualMemory,'NtProtectVirtualMemory',\
        NtCreateThread,'NtCreateThread',\
        NtClose,'NtClose',\
        InitializeCS,'RtlInitializeCriticalSection',\
        EnterCS,'RtlEnterCriticalSection',\
        LeaveCS,'RtlLeaveCriticalSection',\
        DeleteCS,'RtlDeleteCriticalSection'
  import msvcrt,\
         printf,'printf'

section '.reloc' fixups data discardable
