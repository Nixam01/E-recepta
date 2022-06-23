@echo "Removing existing image"
@docker rmi uaimpw/doctors-data-microservice
@echo "Building new image"
@cd ..\Microservices\DoctorsDataMicroservice\DoctorsDataMicroservice
@docker build -t uaimpw/doctors-data-microservice .
@echo "Pushing new image"
@docker push uaimpw/doctors-data-microservice
@echo "New image has been built and pushed"