# Simple Banking

Simple Banking is what it sounds like. A simple banking application designed to allow a user to track accounts and account owners across multiple banks. Each type of account (Checking, Corporate Investment, and Individual Investment) support deposit, withdraw and transfer to any other account. Depending on the type of account some withdraw restrictions may be in place and no account is able to be overdrawn.

This is just the backend of the app and could easily have a console application UI added on later. The app currently holds an IAccount Interface that each type of account implements to ensure all accounts meet certain criteria. Each POCO (Bank, 3 different accounts, and Clients) are stored in their own repository to simulate the use of a database with individual tables. This project could be converted to something like an ASP.NET Web API to utilize Entity Framework and and actual database as well.
