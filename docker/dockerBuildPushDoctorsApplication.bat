@echo "Removing existing image"
@docker rmi uaimpw/doctor-application-microservice
@echo "Building new image"
@cd ..\Microservices\DoctorApplicationMicroservice\DoctorApplicationMicroservice
@docker build -t uaimpw/doctor-application-microservice .
@echo "Pushing new image"
@docker push uaimpw/doctor-application-microservice
@echo "New image has been built and pushed"