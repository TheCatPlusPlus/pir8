load rA, [0x123]
load rA, 0x123
save [0x123], rB
save 0x123, rB ; shouldn't match
