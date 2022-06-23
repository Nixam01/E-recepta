@echo "Removing existing image"
@docker rmi uaimpw/doctor-client-application-http
@echo "Building new image"
@cd ..\Microservices\UiDoctorApp
@docker build -t uaimpw/doctor-client-application-http .
@echo "Pushing new image"
@docker push uaimpw/doctor-client-application-http
@echo "New image has been built and pushed"