# HotelWorldTechChallenge

Pre-requisite for using the test scripts: 

Please update the required configuration values in appSettings.json file before starting any tests.

  Exercise 1:
It is assumed that the text file is fed to the test with the said format i.e. Line Number <tab> Random number. 
The text file is created manually looking at the constraint that if a programmed text file is entered to the test then it will never generate a fail case i.e. all the line number will be pass case. 
User have to provide the location of the input file random_numbers.txt and output file Test_Result.log. 
The Automated test script doesn’t handle the below cases:
Testcase 1: The serial number is in ascending order or not.
Testcase 2: The serial number is not more than 50.
Testcase 3: Check if there is a tab between the serial number and random number
Testcase 4: Check if there is no white space/ special character between two line
Testcase 5: Check if the test file is generated and present at the mentioned location or not. 
The Automated test script handle the below scenarios:
Testcase 1: Check if the random number is between 100-500
Testcase 2 : Check if the random number is numeric
Testcase 3: Check if the random number is not negative.
Testcase 4: Check of the random number is in integer format.


Exercise 2:
The user’s machine need to have Chrome driver as the web driver type is hardcoded or change is required in the script depending on the user’s choice. 
User have to provide the desired City in appSettings.json to be searched in the script manually.
The test steps of Automated test script are as below scenarios:
Test Step1: Navigate to the url “https://www.hostelworld.com”
Test step 2: Enter the desired city to be searched. 
Test step 2: Enter on “Lets go”.
Test Step 3: Navigate to next page.
Test Step 4: Validate the landing page is showing the rest of the entered city.
The Automated test script doesn’t handle the below cases:
Testcase 1: Check the error message if any invalid city is entered.
Testcase 2: Check if the populated result in the result page is showing correct result or not. 




Exercise 3:
It is assumed that the user will create one gist at time.
In create gist test script, only one gist is validated
Lists all the gists and compare main fields (not all) only as per the gist api doc.
Deletes gist and asserts the response, you need to set the gistid in appSettings.json file.


