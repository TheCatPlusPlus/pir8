x = 42
y = 0b10001000
z = -5629

foo.bar:
	set r0, x + y ^ (3 / 8)
	set r1, r2 ; comment
	set r99, ip
	load 0x245
test:
	some_other_var = x + y + y * 2
.baz:
	blah blah
	qword 53, 0x412, 0b11101042
	meh [r0]
	meh [0x412]