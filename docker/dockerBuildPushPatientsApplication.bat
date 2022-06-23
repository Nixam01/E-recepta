@echo "Removing existing image"
@docker rmi uaimpw/patient-application-microservice
@echo "Building new image"
@cd ..\Microservices\PatientApplicationMicroservice\PatientApplicationMicroservice
@docker build -t uaimpw/patient-application-microservice .
@echo "Pushing new image"
@docker push uaimpw/patient-application-microservice
@echo "New image has been built and pushed"