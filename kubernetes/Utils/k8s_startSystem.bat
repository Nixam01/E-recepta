@echo "Starting data applications"
@kubectl apply -f .\Configuration\doctors-data.yaml
@kubectl apply -f .\Configuration\patients-data.yaml
@kubectl apply -f .\Configuration\drugs-data.yaml
@kubectl apply -f .\Configuration\prescriptions-data.yaml

@echo "Starting configuration map"
@kubectl apply -f .\Configuration\app-configmap.yaml

@echo "Starting service applications"
@kubectl apply -f .\Configuration\patients-application.yaml
@kubectl apply -f .\Configuration\doctors-application.yaml

@echo "Starting client applications"
@kubectl apply -f .\Configuration\patient-client-application.yaml
@kubectl apply -f .\Configuration\doctor-client-application.yaml