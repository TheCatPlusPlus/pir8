define pir8

element pir8.reg
element f? : pir8.reg + 0
element s? : pir8.reg + 1
element x? : pir8.reg + 2
element y? : pir8.reg + 3
element a? : pir8.reg + 4
element b? : pir8.reg + 5
element c? : pir8.reg + 6
element d? : pir8.reg + 7

; directives

macro origin? offset*
	db offset dup 0
end macro

macro dw_be value*
	db ((value shr 8) and 0xFF)
	db (value and 0xFF)
end macro

; jumps

macro pir8.jump bits*, dest*
	db (0001'0'000b or bits)
	dw_be dest
end macro

macro jmpz? dest*
	pir8.jump 000b, dest
end macro

macro jmpp? dest*
	pir8.jump 001b, dest
end macro

macro jmpg? dest*
	pir8.jump 010b, dest
end macro

macro jmpc? dest*
	pir8.jump 011b, dest
end macro

macro jmzg? dest*
	pir8.jump 100b, dest
end macro

macro jmzl? dest*
	pir8.jump 101b, dest
end macro

macro jmpl? dest*
	pir8.jump 110b, dest
end macro

macro jump? dest*
	pir8.jump 111b, dest
end macro

; data

define @reg1
define @reg2

macro pir8.get_register_bits ns, operand
	; fasm syntax almost as bad as nab's labels

	if ~1 metadataof operand relativeto pir8.reg
		err 'Operand must be a general register'
	end if

	ns.bits = operand metadata 1 - pir8.reg
end macro

macro load? dest*, src*
	pir8.get_register_bits @reg1, dest

	match [addr], src
		db (0010'0'000b or @reg1.bits)
		dw_be addr
	else match imm, src
		db (0001'1'000b or @reg1.bits)
		db imm
	end match
end macro

macro save? dest*, src*
	pir8.get_register_bits @reg1, src

	match [addr], dest
		db (0010'1'000b or @reg1.bits)
		dw_be addr
	else
		err 'Destination must be an address'
	end match
end macro

macro move? dest*, src*
	pir8.get_register_bits @reg1, dest
	pir8.get_register_bits @reg2, src

	db (01'00'0000b or (@reg2.bits shl 3) or @reg1.bits)
end macro

macro pir8.stack dir_bits*, reg1*, reg2*
	pir8.get_register_bits @reg1, reg1
	pir8.get_register_bits @reg2, reg2
	
	local pair_bits

	if reg1 eq a & reg2 eq b
		pair_bits = 0
	else if reg1 eq c & reg2 eq d
		pair_bits = 1
	else
		err 'Invalid register pair: must be A/B or C/D'
	end if

	db (1111'10'00b or (dir_bits shl 1) or pair_bits)
end macro

macro push? reg1*, reg2*
	pir8.stack 0b, reg1, reg2
end macro

macro pop? reg1*, reg2*
	pir8.stack 1b, reg1, reg2
end macro

macro in? dest*
	pir8.get_register_bits @reg1, dest
	db (1110'1'000b or @reg1.bits)
end macro

macro out? src*
	pir8.get_register_bits @reg1, src
	db (1110'0'000b or @reg1.bits)
end macro

macro comp? reg*
	pir8.get_register_bits @reg1, reg
	db (1111'0'000b or @reg1.bits)
end macro

; alu

macro pir8.alu bits*
	db (0011'0000b or bits)
end macro

macro pir8.alu_shift dir_bits*, shift_bits*
	pir8.alu (1'0'00b or (dir_bits shl 2) or shift_bits)
end macro

macro add?
	pir8.alu 0000b
end macro

macro sub?
	pir8.alu 0001b
end macro

macro not?
	pir8.alu 0010b
end macro

macro or?
	pir8.alu 0100b
end macro

macro xor?
	pir8.alu 0101b
end macro

macro and?
	pir8.alu 0110b
end macro

macro lsfl?
	pir8.alu_shift 1b, 00b
end macro

macro lsfr?
	pir8.alu_shift 0b, 00b
end macro

macro asfl?
	pir8.alu_shift 1b, 01b
end macro

macro asfr?
	pir8.alu_shift 0b, 01b
end macro

macro rtcl?
	pir8.alu_shift 1b, 10b
end macro

macro rtcr?
	pir8.alu_shift 0b, 10b
end macro

macro rtwl?
	pir8.alu_shift 1b, 11b
end macro

macro rtwr?
	pir8.alu_shift 0b, 11b
end macro

; misc

macro clrf?
	db 1111'1110b
end macro

macro halt?
	db 1111'1111b
end macro

format binary as 'p8b'
