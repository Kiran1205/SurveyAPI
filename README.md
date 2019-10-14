# Prod

Currently Survey Shrike hosted on http://www.surveyshrike.somee.com Private Cloud server

we can create new user or use the sample credential provided below.<br />
User Name : kiran1205<br />
Password : kiran@1234<br />

given sample survey created and below are the url to access<br />

event
http://www.surveyshrike.somee.com/#/anonymossurvey?survey=031200e2-da0a-4e7d-9bf3-33c285bcb43f

traning 
http://www.surveyshrike.somee.com/#/anonymossurvey?survey=1b0f6b41-f8d1-40f4-a47f-307d4145456e


# Enviorment Setup
Pre-requiste:
following softwares need to installed on devlopment machine.

Dotnet Core 2.2 <br />
Visula studio 2017 with .Net Core Development <br />
SQl Server 2016 <br />
NodeJS <br />
NPM <br />
Visual studio code front end devlopment <br />

# Database setup
create data base name SurveyDB

execute the following scripts fto setup sql server data base tables.all scripts available path
https://github.com/Kiran1205/SurveyAPI/blob/master/DBScript.sql

# Clinet Project Setup
check out the master branch from repository  https://github.com/Kiran1205/SurveyClient

open the project in command prompt and run npm install

the above command will install all depedent package for running front end application 

to run application in dev machine ,run the following command

npm start

the above command will launch  application under http://localhost:4200

# Server Project setup
check out the master branch from repository  https://github.com/Kiran1205/SurveyAPI

open project in visual studio in admin mode and run mange nuget package manger .

change connection settings to local data base 

build the project and run it will run under  http://localhost:50366

# Authentication and authorization

JWt Token used for authentication and authorization and  every login session will expires in 15 mins.

used hashkey and salt key for password.


# SurveyShrike 
SurveyShrike help businesses conduct surveys. SurveyShrike believes every customer has different views or comments about services and over all products.
 And every business needs to know right customer mindset to engage customers for long run. 

An authenticated user required to create a survey and display (including results) various surveys created by authenticated user.

# current features
Login <br />
registration <br />
dashboard <br />
Create Survey <br />
	->Add Queston <br />
	->modify created Survey <br />
	->delete the survey<br />
	->generate survey link<br />

Manage Survey
Currently repose count only displaying need to do result analysis

Anonymous user can participate the survey link provided by authenticated user

Every survey has expiry date or close data if you click the link after that it wont work

# Pending
valaidations<br />
Response Analaysis	

flow Digram
![alt text](https://github.com/Kiran1205/SurveyClient/blob/master/ArchitectureDigram.jpg)
