#!/bin/bash
docker build -f ./Source/Dockerfile -t shipos/timeseries-kyma . --build-arg CONFIGURATION="Debug"
iotedgehubdev start -d deployment.json -v