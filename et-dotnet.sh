set -e

docker_build() {
    
    if [ -z $REVDEBUG_RECORD_SERVER_ADDRESS ]
    then
        echo "Missing essential env variable, list:"
        echo "REVDEBUG_RECORD_SERVER_ADDRESS=$REVDEBUG_RECORD_SERVER_ADDRESS"
        echo "Exiting..."
        exit 1
    else 
        echo "Running build, Record Server: $REVDEBUG_RECORD_SERVER_ADDRESS"
    fi    
    sudo docker build --pull --build-arg REVDEBUG_RECORD_SERVER_ADDRESS=$REVDEBUG_RECORD_SERVER_ADDRESS -t et-dotnet .

    echo "EndpointTest dotNet application container has been created and started."
}

docker_start() {
    sudo docker run -d -p 6015:5000 --name et-dotnet et-dotnet:latest
}

docker_reload() {
    sudo docker cp ./et-dotnet/app/. et-dotnet:/app/
    sudo docker stop et-dotnet
    sudo docker start et-dotnet
}

docker_stop() {
    sudo docker stop et-dotnet
    sudo docker rm et-dotnet

    echo "EndpointTest dotNet container has been stopped and removed."
}

case "$1" in
build)
    docker_build
    ;;
start)
    docker_start
    ;;
stop)
    docker_stop
    ;;
restart)
    docker_stop
    docker_start
    ;;
reload)
    docker_reload
    ;;
build_em_all)
    docker_stop
    docker_build
    docker_start
    ;;
*)
    echo "Usage: ${0##*/} {build|start|stop|restart|reload|build_em_all}"
    exit 1
    ;;
esac
