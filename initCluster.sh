#!/bin/sh

eval $(minikube docker-env)

cd ./api-gateway
pwd
docker build -t api-gateway:1.0.0 -f ./Dockerfile .

cd ../user-registration-service
pwd
docker build -t user-registration:1.0.0 -f ./Dockerfile .

cd ../loans-service
pwd
docker build -t loan-service:1.0.0 -f ./Dockerfile .

cd ..
pwd
kubectl apply -f ./kubernetes/secrets
kubectl apply -f ./kubernetes/services
kubectl apply -f ./kubernetes/deployments