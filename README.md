# WebService Employee
#### Show all employees in a company example:

* ROUTE: https://localhost:5001/api/employee/123
* REQUEST TYPE: GET

#### Delete an employee example:

* ROUTE: https://localhost:5001/api/employee/2
* REQUEST TYPE: DELETE



#### Create an employee example:

* ROUTE: https://localhost:5001/api/employee
* REQUEST TYPE: POST
* JSON:
```json
{
  "name": "Alex",
  "surname": "Calls",
  "phone": "216812",
  "companyId": 123,
  "passport":  
  {
    "type": "rus",
    "number": "2683121"
  } 
}
```


#### Edit an employee example:

* ROUTE: https://localhost:5001/api/employee/2
* REQUEST TYPE: PUT
* JSON:
```json
{
  "name": "Alexandra",
  "companyId": 123
}
```

---

### Selected database: MySQL.
* To set up a database connection edit "DataBase" in appsettings.json
