@echo "Starting system"
@echo "Starting data applications"

@start cmd /k  "cd ..\Microservices\doctorsdatamicroservice\doctorsdatamicroservice && dotnet run --urls=http://localhost:5024/;https://localhost:7024/"
@start cmd /k  "cd ..\Microservices\drugsdatamicroservice\drugsdatamicroservice && dotnet run --urls=http://localhost:5187/;https://localhost:7187/"
@start cmd /k  "cd ..\Microservices\patientdatamicroservice\patientdatamicroservice && dotnet run --urls=http://localhost:5043/;https://localhost:7043/"
@start cmd /k  "cd ..\Microservices\prescriptiondatamicroservice\prescriptiondatamicroservice && dotnet run --urls=http://localhost:5053/;https://localhost:7053/"

@echo "Starting service applications"
@start cmd /k  "cd ..\Microservices\patientapplicationmicroservice\patientapplicationmicroservice && dotnet run --urls=http://localhost:5243/;https://localhost:7243/"
@start cmd /k  "cd ..\Microservices\doctorapplicationmicroservice\doctorapplicationmicroservice && dotnet run --urls=http://localhost:5204/;https://localhost:7204/"

@echo "Starting client applications"
@start cmd /k  "cd ..\Microservices\UiPatientApp\UiPatientApp && dotnet run --urls=http://localhost:5263/;https://localhost:7263/"
@start cmd /k  "cd ..\Microservices\UiDoctorApp\UiDoctorApp && dotnet run --urls=http://localhost:5169/;https://localhost:7169/"

@echo "The browser window will open automatically after 20 seconds"
@timeout 20
@echo "Opening browser for Patient client application"
@.\UiPatientApp-5236.url
@echo "Opening browser for Doctor client application"
@.\UiDoctorApp-5169.url
@echo "System started"