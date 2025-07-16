# LibraryManagementSystem
First to do before running the application is to change the connection strings to point to the database you wish to use.
To do this. go to the appsettings.json line 13 "ConnectionStrings" change it accordingly.
Once this is done the application will automatically create needed database and needed objects. Please do not manually create the database. the application will do this.

This project is designed having security in mind. The request and responses can be encrypted by choice.
At the moment the project is accepting and returning requests and responses in plain terms with no encryption.
For you to test endpoints even though they're post or update request. They should be passed as parameters for testing purpose. (see the attached postman collection)
The moment you turn on ecryption which should be done on line 37 and 38 of the appsettings.json file, requests and response becomes encrypted.
Requests needs to be encrypted before sending and responses need to be decrypted for viewing.
Its all in the attached postman collection
