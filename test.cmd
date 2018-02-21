@echo off
setlocal
cd %~dp0
cd PIR8.ISA\Assembly
java -jar %~dp0\antlr.jar -o Java -no-visitor -no-listener -Dlanguage=Java Grammar.g4
cd Java
set CLASSPATH=%~dp0\PIR8.ISA\Assembly\Java;%~dp0\antlr.jar
javac *.java
cd %~dp0
java org.antlr.v4.gui.TestRig Grammar %*
