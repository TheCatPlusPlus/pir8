@echo off
setlocal
cd %~dp0
cd PIR8.ISA\Assembly
java -jar %~dp0\antlr.jar -o Gen -visitor -no-listener -package PIR8.ISA.Assembly.Gen Grammar.g4
