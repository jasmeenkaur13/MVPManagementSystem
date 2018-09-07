# CarSalesManagementSystem
Vehicle Management system
- To perform CRUD operation for the Advertised cars
- To Add the Enquiry if made any.

## Software Requirements
- Visual Studio 2017 with Web Pack installed
- SQL server 2008 or above
- Google Web extension Postman to test the API

## Design and Implementation
- Use Interface Segregation Principle to implement the API's.
- To cater Future enhancement new service contracts will be introduce and hence the existing code will not be changed.
- User Dependency Injection Pattern to implement loosely couple classes.
- MOQ testing framework used for Unit testing the Business/WebServices layer.
- Global Exception Handling introduced with the help of ExceptionHandler.
- Use of Log4Net to implement logging.
- Used Entity Framework to persist the data
- SQL server is Used to manage the data

## Steps to Run
- Navigate to Web.Config of WebServices Project and Update the connection string for Successful SQL connection.
- Right Click of the Solution and click on Restore Nuget Packages.
- Navigate to Database Folder and Run Tables folder scripts and then Master Data Folder scripts.
- Build the Project and Run it using Postman.
- Enpoints
* 	PUT/DELETE - http://localhost:{ur port}/api/advertisedcar/{id}
*	GET - http://localhost:54732/api/advertisedcar?model=&make=&year=2016
*	POST - http://localhost:{ur port}/api/advertisedcar
*   POST - http://localhost:{ur port}/api/enquiry
- JSON objects
*	Advertised cars
{
  "CarDetails": {
    "ID": 1,
    "Year": "sample string 2",
    "Make": "sample string 3",
    "Model": "sample string 4",
    "AdvertisedPriceType": "sample string 5",
    "ECGAmount": 6.0,
    "DAPAmount": 7.0,
    "AdvertisedAmount": 8.0
  },
  "OwnerDetails": {
    "Id": 1,
    "Name": "",
    "PhoneNumber": "sample string 3",
    "Email": "sample string 4",
    "DealerABN": "sample string 5",
    "OwnerType": "sample string 6",
    "Comments": "sample string 7"
  }
}
*	Enquiry

## Areas of Improvements
- Integration Test cases will be of great help here.
- Implement Logger and UnitOfWork with Interfaces.
- Unit Test cases of Repository classes except the fact that they do not contain any business logic
- Use of Transaction Scope so that if anythings fails any changes done can be reverted.
- Authentication and Authorization is still dependent on the third party tools.
