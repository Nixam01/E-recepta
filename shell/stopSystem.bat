@echo "Stopping system"
@npx kill-port 5024 && npx kill-port 5043 && ^
npx kill-port 5053 && npx kill-port 5187 && ^
npx kill-port 5204 && npx kill-port 5243 && ^
npx kill-port 5263 && npx kill-port 5169 && ^
echo "System has been stopped"