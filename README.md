# LibraryManagementSystem
First to do before running the application is to change the connection strings to point to the database you wish to use.
To do this. go to the appsettings.json line 13 "ConnectionStrings" change it accordingly.
Once this is done the application will automatically create needed database and needed objects. Please do not manually create the database. the application will do this.

This project is designed having security in mind. The request and responses can be encrypted by choice.
At the moment the project is accepting and returning requests and responses in plain terms with no encryption.
For you to test endpoints even though they're post or update request. They should be passed as parameters for testing purpose. (see the attached postman collection Link)
The moment you turn on ecryption which should be done on line 37 and 38 of the appsettings.json file, requests and response becomes encrypted.
Requests needs to be encrypted before sending and responses need to be decrypted for viewing.
We all know Get and Delete requests cannot be encrypted. 
To test them we will need to step down the encryption by setting the value of 37 and 38 to false. Only then you will be able to test the two methods called RetrieveAllBooks and DeleteBook. 

For you to test the InsertNewBook and UpdateBookDetails. You can either turn on or off the encryption mechanism. If you turn the encryption to false, you will need to fill the parameters, if you turn the encrytion to true, then you will pass encrypted request as the body
 
Its all in the attached postman collection


To encrypt or decrypt you can use aes-256-cbc-hmac-sha1
Here is a web site we can easily use to encrypt or decryt at will if you dont want to use code
https://encode-decode.com/aes-256-cbc-hmac-sha1-encrypt-online/
the key is h0BaPs9WvUkK7rO3MKLUaI9TcyGe4VJt

https://warped-rocket-9958.postman.co/workspace/forTesting~ba49d4ab-14a2-46db-a16a-7814b4e404ce/collection/2122042-9bde5905-27bf-4a7a-9fc4-97e1c2d8f9a0?action=share&creator=2122042