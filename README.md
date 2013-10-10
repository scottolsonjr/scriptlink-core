ScriptLink Core
===============

ScriptLink Core is a C# framework support the creation of Netsmart Avatar ScriptLink-compatible SOAP Web Services. This Class Library code would be compiled into a DLL and imported into your ScriptLink Project.


Project Goals
=============

- Provide a library of functions that could be used in any Netsmart Avatar ScriptLink implementation.
- Include commonly used functions that would aid in the adoption of ScriptLink
- Create an optionObject wrapper that would aid in common actions related to the object, such as search, error message assignment, and so on.
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
