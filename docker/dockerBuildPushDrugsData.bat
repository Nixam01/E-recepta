@echo "Removing existing image"
@docker rmi uaimpw/drugs-data-microservice
@echo "Building new image"
@cd ..\Microservices\DrugsDataMicroservice\DrugsDataMicroservice
@docker build -t uaimpw/drugs-data-microservice .
@echo "Pushing new image"
@docker push uaimpw/drugs-data-microservice
@echo "New image has been built and pushed"