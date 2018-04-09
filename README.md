# Credilikeme bootcamp example project

This is an example project of a lender company for the credilikeme bootcamp talks. 

To run this project you need to have [Docker](https://docs.docker.com/install/) and [Minikube](https://kubernetes.io/docs/tasks/tools/install-minikube/) installed.

You can use the initCluster.sh script to add all required objects to the cluster or run the next commands manually:

```
eval $(minikube docker-env)

cd ./api-gateway
docker build -t api-gateway:1.0.0 -f ./Dockerfile .

cd ../user-registration-service
docker build -t user-registration:1.0.0 -f ./Dockerfile .

cd ../loans-service
docker build -t loan-service:1.0.0 -f ./Dockerfile .

cd ..
kubectl apply -f ./kubernetes/secrets
kubectl apply -f ./kubernetes/services
kubectl apply -f ./kubernetes/deployments
```
