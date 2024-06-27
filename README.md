# Documentation

This is a project running on .Net 6 and ASP.net core, intended to prove my potential as a back-end developer to the company Develop.mx, who provided the specifications for this project.

## Considerations

In order to get this project working, it is mandatory to have access to the following link:
https://examentecnico.azurewebsites.net/v3/api/Test/Customer, as it is the data source used.
Once the project is running, you can check the swagger documentation going to the `/swagger/index.html` enpoint

## /API Endpoints

### /Customer

#### Example Request

    curl --location 'https://localhost:7049/api/Customer'

#### Response

##### Status Code: 200

```javascript
{
    "customerId": "string",
    "email": "string",
    "phoneHome": "string",
    "phoneMobile": "string",
    "addresses": [
        {
            "addressId": "string",
            "address1": "string",
            "address2": "string",
            "c_Street_Number": "string",
            "c_BuildingNumber": "string",
            "postalCode": "string",
            "city": "string",
            "stateCode": "string",
            "countryCode": "string",
            "creationDate": "2024-06-27T14:10:54.569Z",
            "phone": "string",
            "preferred": true
        }
    ],
    "birthday": "2024-06-27T14:10:54.569Z",
    "firstName": "string",
    "lastname": "string"
}
```

### /Customer/Addresses

#### Example Request

    curl --location 'https://localhost:7049/api/Customer/Addresses?sort=date&order=desc'

#### Query Parameters

-   #### sort
    **Allowed values:** `address` `date`  
    **Default value:** `address`
-   #### order
    **Allowed values:** `asc` `desc`  
    **Default value:** `asc`

#### Response

##### Status Code: 200

```javascript
[
    {
        addressId: "string",
        address1: "string",
        address2: "string",
        c_Street_Number: "string",
        c_BuildingNumber: "string",
        postalCode: "string",
        city: "string",
        stateCode: "string",
        countryCode: "string",
        creationDate: "2024-06-27T14:26:48.581Z",
        phone: "string",
        preferred: true,
    },
];
```

### /Customer/Addresses/Preferred

#### Example Request

    curl --location 'https://localhost:7049/api/Customer/Addresses/Preferred'

#### Response

##### Status Code: 200

```javascript
{
    "addressId": "string",
    "address1": "string",
    "address2": "string",
    "c_Street_Number": "string",
    "c_BuildingNumber": "string",
    "postalCode": "string",
    "city": "string",
    "stateCode": "string",
    "countryCode": "string",
    "creationDate": "2024-06-27T14:33:09.234Z",
    "phone": "string",
    "preferred": true
}
```

### /Customer/Addresses/PostalCode/{code}

#### Example Request

    curl --location 'https://localhost:7049/api/Customer/Addresses/PostalCode/27258'

#### Response

##### Status Code: 200

```javascript
[
    {
        addressId: "string",
        address1: "string",
        address2: "string",
        c_Street_Number: "string",
        c_BuildingNumber: "string",
        postalCode: "string",
        city: "string",
        stateCode: "string",
        countryCode: "string",
        creationDate: "2024-06-27T14:34:58.692Z",
        phone: "string",
        preferred: true,
    },
];
```
