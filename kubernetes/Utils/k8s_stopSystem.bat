@echo "Removing client applications"
@kubectl delete deployment patient-client-application-deployment
@kubectl delete service patient-client-application-service

@kubectl delete deployment doctor-client-application-deployment
@kubectl delete service doctor-client-application-service

@echo "Removing service applications"
@kubectl delete deployment patients-application-deployment
@kubectl delete service patients-application-microservice

@kubectl delete deployment doctors-application-deployment
@kubectl delete service doctors-application-microservice

@echo "Removing config map"
@kubectl delete configmap app-configmap

@echo "Removing data applications"
@kubectl delete deployment doctors-data-deployment
@kubectl delete service doctors-data-service

@kubectl delete deployment patients-data-deployment
@kubectl delete service patients-data-service

@kubectl delete deployment drugs-data-deployment
@kubectl delete service drugs-data-service

@kubectl delete deployment prescriptions-data-deployment
@kubectl delete service prescriptions-data-service