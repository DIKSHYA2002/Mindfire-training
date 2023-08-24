# ASPNET:Tent House Rentals

An Inventory Management System for tent house suppplies for rent.It provides a User a place to manage transactions and stock related to their business
## 1-IIS Configuration
### Add Host to your Host File(C:\Windows\System32\drivers\etc) 
```Eg -127.0.0.1    www.TentHouseRentals.com``` 

![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/3a07bd16-b063-4c98-b405-fb22e6747198)

## 2 -Open Visual Studio.
~~~
1- Open Visual Studio.
2- On the start window, select Clone a repository.
3- Enter or type the repository location, and then select the Clone button.
4- You might be asked for your user sign-in information in the Git User Information dialog box
5- From the Git menu, select Clone Repository. [https://github.com/DIKSHYA2002/Mindfire-training/edit/main/Csharp/TentHouseRentals.Website]
~~~
## 3 - IIS Configurations-(Add Website)
~~~
1- Go to IIS Manager
2- Add  a Default Website
3- Add the path of the folder of webconfig (webforms) TentHouseRentals.Web
4 - Add Application Pool
5 - Add Domain to the Path
6 - Add site name - same as Domain name 
~~~
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/9593505d-9abf-457e-9924-745d3b93f13f)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/9cb2074e-e50e-40af-8af7-e3c3c22b3a4d)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/b86592e6-bc04-43db-b196-2ba4ea081434)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/298a2f4b-b147-47c9-a6d5-7863133ecf77)

## 4 - Database Connection
```
1- SQL SERVER NAME -DIKSHYAA-WIN10\SQLEXPRESS
2- USER NAME - Id from sql authentication
3- PASSWORD - Password Set During SQL authentication
```
~~~
<configuration>
<connectionStrings>
		<add name="TentHouseRentalEntities" connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=[SQL SERVER NAME];initial catalog=TentHouseRental;user id=[USER NAME];password=[PASSWORD];MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
	</connectionStrings>
</configuration>
~~~
##   5 - Build the project
```(ctrl+shift+ B) (Vs)```
###  6 - Browse 
```http://TentHouseRentals.com```
##  Sections:
## 1-Login Up
[Only Admin] [email = User@gmail.com , password  = user123]
## Initialise Button
it will initialise the tables-products,customers with 4 to 5 values and transactions will be  empty
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/508ddc14-4526-421c-8135-247f2ab09970)
## 2-Product (List)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/a1bfb1dc-b721-4e6f-a4c5-797f8c9aaf92)
## 3-Product Add
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/291ca266-9568-40fe-b6c0-532f9fc243b1)
## 4-Customers Add(List)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/5fef6f32-a1ca-4af3-a5c7-5a1da3475411)
## 5-Transactions(OUT)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/12f0955b-656e-4d7e-9bf3-b9dcd42bdf5c)
## 5-Transactions(IN)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/8ee5983a-becd-4542-bc12-b1a882966169)

## 6-Reports(Product,Detailed Transaction Report)(Download in the form of pdf)
![image](https://github.com/DIKSHYA2002/Mindfire-training/assets/78462004/f34a0118-cd91-41a9-af78-0d1ff5766d30)

## 7- 




