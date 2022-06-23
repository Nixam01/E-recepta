@echo "Removing existing image"
@docker rmi uaimpw/patient-client-application-http
@echo "Building new image"
@cd ..\Microservices\UiPatientApp
@docker build -t uaimpw/patient-client-application-http .
@echo "Pushing new image"
@docker push uaimpw/patient-client-application-http
@echo "New image has been built and pushed"