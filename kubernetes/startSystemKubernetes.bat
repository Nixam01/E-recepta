@echo "Starting system with Kubernetes"
@call Utils\k8s_startSystem.bat
@echo "System is starting, the browser window will open automatically after 10 seconds"
@timeout 10
@Utils\UiPatientApp-30006.url
@Utils\UiDoctorApp-30007.url