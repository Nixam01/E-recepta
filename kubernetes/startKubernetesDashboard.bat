@echo "Starting Kubernetes Dashboard"
@start cmd /k "kubectl proxy"
@kubectl apply -f Dashboard\dashboard-service-admin.yaml
@kubectl apply -f Dashboard\dashboard-role-binding.yaml
@echo "Your access token is:"
@kubectl -n kubernetes-dashboard create token admin-user
@echo "Copy and paste the above token into appropriate field in the opened browser window"
@echo "The browser window will open automatically after 5 seconds"
@timeout 5
@Utils\KubernetesDashboard.url
pause