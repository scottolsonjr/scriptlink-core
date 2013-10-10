using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptLinkCore.Objects;

namespace ScriptLinkCore
{
    public partial class ScriptLink
    {
        /// <summary>
        /// Used to create the returning optionObject.
        /// </summary>
        /// <param name="optionObject"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static OptionObject GetReturnOptionObject(OptionObject optionObject, int errorCode = 0, string errorMessage = "")
        {
            OptionObject returnOptionObject = new OptionObject();
            returnOptionObject = CreateOptionObjectHeader(optionObject);
            returnOptionObject = SetErrorCodeAndMessage(returnOptionObject, errorCode, errorMessage);
            return returnOptionObject;
        }

        private static OptionObject CreateOptionObjectHeader(OptionObject optionObject)
        {
            OptionObject returnOptionObject = new OptionObject();
            returnOptionObject.OptionId = optionObject.OptionId;
            returnOptionObject.EntityID = optionObject.EntityID;
            returnOptionObject.EpisodeNumber = optionObject.EpisodeNumber;
            returnOptionObject.Facility = optionObject.Facility;
            returnOptionObject.OptionStaffId = optionObject.OptionStaffId;
            returnOptionObject.OptionUserId = optionObject.OptionUserId;
            returnOptionObject.SystemCode = optionObject.SystemCode;
            return returnOptionObject;
        }

        private static OptionObject SetErrorCodeAndMessage(OptionObject optionObject, int errorCode = 0, string errorMessage = "")
        {
            OptionObject returnOptionObject = new OptionObject();
            returnOptionObject = optionObject;
            returnOptionObject.ErrorCode = errorCode;
            returnOptionObject.ErrorMesg = errorMessage;
            return returnOptionObject;
        }



        /// <summary>
        /// Used to force a error.
        /// </summary>
        /// <param name="testErrorCode"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static int CheckErrorCode(string testErrorCode, out string errorMessage)
        {
            int errorCode;
            if (int.TryParse(testErrorCode, out errorCode))
            {
                if (errorCode == 0)
                {
                    errorCode = 3;
                    errorMessage = "Return code 0 is one that indicates success.";
                }
                else if (errorCode >= 1 && errorCode < 5)
                {
                    errorMessage = "Error Test Successful. You have received error code " + errorCode + ".";
                }
                else if (errorCode == 5)
                {
                    errorMessage = "http://api.rcskids.org/ErrorFive.aspx";
                }
                else
                {
                    errorMessage = "Error code " + errorCode + " is not a valid return code.";
                    errorCode = 1;
                }
            }
            else
            {
                errorCode = 1;
                errorMessage = "Error code '" + testErrorCode + "' is not a valid return code.";
            }
            return errorCode;
        }



        /// <summary>
        /// Used to parse the received parameter.
        /// </summary>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        public static string[] SplitDelimitedParameter(string delimitedParameter)
        {
            char[] delimiters = new char[] { ',', '.' };
            string[] tempString = delimitedParameter.Split(delimiters);
            string[] splitString = new string[10];

            try { splitString[0] = tempString[0]; }
            catch (Exception ex) { splitString[0] = " "; }

            try { splitString[1] = tempString[1]; }
            catch (Exception ex) { splitString[1] = " "; }

            try { splitString[2] = tempString[2]; }
            catch (Exception ex) { splitString[2] = " "; }

            try { splitString[3] = tempString[3]; }
            catch (Exception ex) { splitString[3] = " "; }

            try { splitString[4] = tempString[4]; }
            catch (Exception ex) { splitString[4] = " "; }

            try { splitString[5] = tempString[5]; }
            catch (Exception ex) { splitString[5] = " "; }

            try { splitString[6] = tempString[6]; }
            catch (Exception ex) { splitString[6] = " "; }

            try { splitString[7] = tempString[7]; }
            catch (Exception ex) { splitString[7] = " "; }

            try { splitString[8] = tempString[8]; }
            catch (Exception ex) { splitString[8] = " "; }

            try { splitString[9] = tempString[9]; }
            catch (Exception ex) { splitString[9] = " "; }

            return splitString;
        }
    }
}
