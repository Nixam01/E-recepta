@echo "Removing existing image"
@docker rmi uaimpw/prescription-data-microservice
@echo "Building new image"
@cd ..\Microservices\PrescriptionDataMicroservice\PrescriptionDataMicroservice
@docker build -t uaimpw/prescription-data-microservice .
@echo "Pushing new image"
@docker push uaimpw/prescription-data-microservice
@echo "New image has been built and pushed"