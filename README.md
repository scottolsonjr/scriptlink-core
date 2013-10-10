ScriptLink Core
===============

ScriptLink Core is a C# framework support the creation of Netsmart Avatar ScriptLink-compatible SOAP Web Services. This Class Library code would be compiled into a DLL and imported into your ScriptLink Project.


Project Goals
=============

- Provide a library of functions that could be used in any Netsmart Avatar ScriptLink implementation.
- Include commonly used functions that would aid in the adoption of ScriptLink
- Create an optionObject wrapper that would aid in common actions related to the object, such as search, error message assignment, and so on.
- Explore use of enums to provide strongly typed form and field actions
- Explore use of LINQ to optimize searching and updating the optionObject
- Provide the compiled DLL and a starter project via NuGet to help developers get started and keep the ScriptLink Core up-to-date in their projects/solutions.
 

Available Methods
=================

CheckErrorCode(string testErrorCode, out string errorMessage)
Used to force a specific error for testing form behavior. Returns errorCode as int and a confirmation string errorMessage.

GetReturnOptionObject(optionObject optionObject, int errorCode, string errorMessage)
Returns optionObject ensuring all required values are set. It will also integrate your error code and message assignments.

SetRequiredField(optionObject optionObject, string fieldNumber)
Used to set field as required. Returns updated optionObject.

SplitDelimitedParameter(string delimitedParameter)
Returns a string array using common parameter delimiters.


Migrating to ScriptLink Core from the NTST Library
==================================================

The biggest difference between the ScriptLinkCore library and the NTST.ScriptLinkService.Objects is that it uses List<> instead of arrays for Form and Field objects.
What this means is that on the NTST provided library you would have to assign each fieldObject to be modified to a row in an array (e.g. fields[0] = modifiedField;) before you could add to a row. With ScriptLinkCore you can add a field to a row using an Add(). For example, currentRow.Fields.Add(modifiedField).
