using Bridge.Abstractions;
using Bridge.Interfaces;
using Bridge.Realizations;

// Interface which declares all logic in realizations
ITakeClasses classes = new ArchitectureClass();

// Abstraction injects instance of an realization interface
var student = new DmytroHutsuliak(classes, "Dima", "Hutsuliak");

student.Learn();