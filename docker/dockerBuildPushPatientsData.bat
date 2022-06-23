@echo "Removing existing image"
@docker rmi uaimpw/patient-data-microservice
@echo "Building new image"
@cd ..\Microservices\PatientDataMicroservice\PatientDataMicroservice
@docker build -t uaimpw/patient-data-microservice .
@echo "Pushing new image"
@docker push uaimpw/patient-data-microservice
@echo "New image has been built and pushed"