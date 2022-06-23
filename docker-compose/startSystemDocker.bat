@echo "Starting system with docker compose"
@docker-compose up -d
@echo "System is starting, the browser window will open automatically after 10 seconds"
@timeout 10
@..\shell\UiPatientApp-5236.url
@..\shell\UiDoctorApp-5169.url